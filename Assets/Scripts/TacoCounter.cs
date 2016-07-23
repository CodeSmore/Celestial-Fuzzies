using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class TacoCounter : MonoBehaviour {

	[SerializeField]
	private Text tacoCountText = null;

	private TapPower tapPower;

	private int size = 3;
	private int[] tacosTappedEachSecond = new int[3];
	private int index = 0;
	private float tacoTapTimer = 0;
	private float tacosPerSecond = 0;

	private int tacoCount = 0;

	private DiscardedObjectController discardedObjectController;

	// Use this for initialization
	void Start () {
		discardedObjectController = GameObject.FindObjectOfType<DiscardedObjectController>();
		tacoCount = ProgressController.GetNumberOfTacos();
		tapPower = GameObject.FindObjectOfType<TapPower>();

		UpdateUI();

		for (int i = 0; i < size; i++) {
			tacosTappedEachSecond[i] = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUI();

		tacoTapTimer += Time.deltaTime;

		if (tacoTapTimer > 1) {
			tacoTapTimer = 0;

			index++;

			if (index >= size) {
				index = 0;
			}

			UpdateTacosPerSecond();
			tacosTappedEachSecond[index] = 0;
		}
	}

	private bool ScreenIsTouched () {
		if ( Input.GetMouseButtonDown(0) ) {
			return true;
		} 
		return false;
	}

	private void UpdateUI () {
		tacoCountText.text = tacoCount.ToString();
	}

	public int GetTacoCount () {
		return tacoCount;
	}

	public void SpendTacos (int numSpent) {
		tacoCount -= numSpent;

		ProgressController.UpdateNumberOfTacos(tacoCount);

	}

	public void RecordTap () {
		tacoCount += tapPower.GetTapPower();

		ProgressController.UpdateNumberOfTacos(tacoCount);

		tacosTappedEachSecond[index] += tapPower.GetTapPower();

		discardedObjectController.Spawn(0);
	}

	public void AddTacos (int addedAmount) {
		tacoCount += addedAmount;

		ProgressController.UpdateNumberOfTacos(tacoCount);
	}

	public float GetTacosPerSecond () {
		return tacosPerSecond;
	}

	public void UpdateTacosPerSecond () {
		int total = 0;

		for (int i = 0; i < size; i++) {
			total += tacosTappedEachSecond[i];
		}

		tacosPerSecond = total / size;
	}
}

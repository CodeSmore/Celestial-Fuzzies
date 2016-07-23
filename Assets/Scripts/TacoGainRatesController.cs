using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TacoGainRatesController : MonoBehaviour {
	[SerializeField]
	private Text tapPowerText = null;
	[SerializeField]
	private Text passiveRateText = null;
	[SerializeField]
	private Text cumulativeRateText = null;

	private PassiveSkillController[] allPassiveSkillControllers;
	private TapPower tapPowerController;
	private TacoCounter tacoCounter;

	void Start () {
		UpdatePassiveSkillControllers();
		tapPowerController = GameObject.FindObjectOfType<TapPower>();
		tacoCounter = GameObject.FindObjectOfType<TacoCounter>();
	}

	void Update () {
		float passiveRate = GetCalculatedPassiveRate();
		float tapEarnRate = tacoCounter.GetTacosPerSecond();

		tapPowerText.text = tapPowerController.GetTapPower().ToString() + "/Tap";
		passiveRateText.text = passiveRate.ToString("F") + "/Sec";
		cumulativeRateText.text =  (passiveRate + tapEarnRate).ToString("F") + "/Sec";
	}

	private void UpdatePassiveSkillControllers () {
		allPassiveSkillControllers = GameObject.FindObjectsOfType<PassiveSkillController>();
	}

	private float GetCalculatedPassiveRate () {
		float totalRate = 0;

		foreach (PassiveSkillController passive in allPassiveSkillControllers) {
			totalRate += passive.GetGrowthPerSecond();
		}

		return totalRate;
	}

}

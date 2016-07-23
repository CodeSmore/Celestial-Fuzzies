using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScrollviewController : MonoBehaviour {

	[SerializeField]
	private GameObject skillScrollView = null;
	[SerializeField]
	private GameObject passiveScrollView = null;
	[SerializeField]
	private GameObject exorcismScrollView = null;


	[SerializeField]
	private GameObject skillButton = null;
	[SerializeField]
	private GameObject passiveButton = null;
	[SerializeField]
	private GameObject exorcismButton = null;

	// Use this for initialization
	void Start () {
		skillScrollView.SetActive(false);
		passiveScrollView.SetActive(false);
		exorcismScrollView.SetActive(false);
	}

	public void ActivateSkillScrollView () {
		skillScrollView.SetActive(true);

		DisableButtons();
	}

	public void ActivatePassiveScrollView () {
		passiveScrollView.SetActive(true);

		DisableButtons();
	}

	public void ActivateExocismScrollView () {
		exorcismScrollView.SetActive(true);

		DisableButtons();
	}

	public void CloseScrollView () {
		skillScrollView.SetActive(false);
		passiveScrollView.SetActive(false);
		exorcismScrollView.SetActive(false);

		EnableButtons();
	}

	private void DisableButtons () {
		skillButton.SetActive(false);
		passiveButton.SetActive(false);
		exorcismButton.SetActive(false);
	}

	private void EnableButtons () {
		skillButton.SetActive(true);
		passiveButton.SetActive(true);
		exorcismButton.SetActive(true);
	}
}

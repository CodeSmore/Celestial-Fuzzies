using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TapPower : MonoBehaviour {

	private int tapPowLevel = 1;
	private float tacosPerTap = 1;

	private float statLevelUpAmount;
	private float costLevelUpAmount;

	[SerializeField]
	private Text powerLevelText = null;
	[SerializeField]
	private Text tacosPerTapText = null;
	[SerializeField]
	private Text levelUpStatText = null;
	[SerializeField]
	private Text levelUpCostText = null;

	private TacoCounter tacoCounter;
	private UpgradeButtonController upgradeButtonController;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		tacoCounter = GameObject.FindObjectOfType<TacoCounter>();
		upgradeButtonController = GetComponent<UpgradeButtonController>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		tapPowLevel = ProgressController.GetTapPowerLevel();

		CalculateTapPower();
		UpdateLevelUpData();
		UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUpgradeButton();
	}

	public int GetTapPower () {
		return (int)tacosPerTap;
	}

	public void UpgradeTapPower (int numberOfLevels = 1) {
		if (tacoCounter.GetTacoCount() >= costLevelUpAmount) {
			tacoCounter.SpendTacos((int)costLevelUpAmount);

			tapPowLevel += numberOfLevels;

			tacosPerTap += statLevelUpAmount;

			// alter cost for next level
			UpdateLevelUpData();
			UpdateUI();

			ProgressController.UpdateTapPowerLevel(tapPowLevel);

			// play button sound effect
			soundController.PlayButtonSound();
		}
	}

	private void UpdateUI () {
		powerLevelText.text = "Level " + tapPowLevel;
		tacosPerTapText.text = tacosPerTap.ToString() + " / Tap";
		levelUpStatText.text = "+ " + statLevelUpAmount + " Tap Power";
		levelUpCostText.text = costLevelUpAmount.ToString();
	}

	private void UpdateLevelUpData () {
		// cost modifier will be > stat modifier to create diminishing returns
		statLevelUpAmount = (int)(tapPowLevel * 0.18f);
		if (statLevelUpAmount < 1) {
			statLevelUpAmount = 1;
		}

		costLevelUpAmount = (int)(Mathf.Pow((tapPowLevel), 2.8f) + 5);
	}

	private void CalculateTapPower () {
		tacosPerTap = 0;

		for (int i = 1; i <= tapPowLevel; i++) {
			float levelUpIncrease = (int)(tapPowLevel * 0.18f);
			if (levelUpIncrease < 1) {
				levelUpIncrease = 1;
			}

			tacosPerTap += levelUpIncrease;
		}
	}

	private void UpdateUpgradeButton () {
		if (tacoCounter.GetTacoCount() >= costLevelUpAmount) {
			upgradeButtonController.EnableSprite();
		} else {
			upgradeButtonController.DisableSprite();
		}
	}

	public float GetTapPowerCostAmount () {
		return costLevelUpAmount;
	}
}

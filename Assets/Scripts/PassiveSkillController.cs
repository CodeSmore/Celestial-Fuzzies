using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class PassiveSkillController : MonoBehaviour {

	// TODO adjust modifiers to upgrade slower/ be more expensive than tap upgrades
	[SerializeField]
	private float levelUpStatModifier = 1;
	[SerializeField]
	private float levelUpCostModifier = 1;

	[SerializeField]
	private float secondsBetweenCollections = 0;

	private int passiveLevel = 0;
	private int rateOfGrowth = 0;

	private float statLevelUpAmount;
	private float costLevelUpAmount;

	[SerializeField]
	private Text passiveLevelText = null;
	[SerializeField]
	private Text tacosGainRateText = null;
	[SerializeField]
	private Text levelUpStatText = null;
	[SerializeField]
	private Text levelUpCostText = null;
	[SerializeField]
	private Image ProgressBar = null;

	private TacoCounter tacoCounter;
	private UpgradeButtonController upgradeButtonController;

	private float collectionTimer = 0;

	[SerializeField]
	private int objectIndex = 0;

	private DiscardedObjectController discardedObjectController;
	private SoundController soundController;

	// Use this for initialization
	void Start () {
		tacoCounter = GameObject.FindObjectOfType<TacoCounter>();
		upgradeButtonController = GetComponent<UpgradeButtonController>();
		discardedObjectController = GameObject.FindObjectOfType<DiscardedObjectController>();
		soundController = GameObject.FindObjectOfType<SoundController>();

		passiveLevel = ProgressController.GetPassive1Level();
		Debug.Log(passiveLevel);
		CalculateRateOfGrowth();

		UpdateLevelUpData();
		UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateUpgradeButton();

		if (passiveLevel > 0) {
			collectionTimer += Time.deltaTime;

			ProgressBar.fillAmount = collectionTimer / secondsBetweenCollections;


			if (collectionTimer >= secondsBetweenCollections) {
				// passive collection
				tacoCounter.AddTacos(rateOfGrowth);

				// object appear on-screen
				discardedObjectController.Spawn(objectIndex);

				collectionTimer = 0;
			}

			Debug.Log(DateTime.Now);
		}
	}

	public int GetRateOfGrowth () {
		return (int)rateOfGrowth;
	}

	public void UpgradeSkill (int numberOfLevels = 1) {
		if (tacoCounter.GetTacoCount() >= costLevelUpAmount) {
			tacoCounter.SpendTacos((int)costLevelUpAmount);

			passiveLevel += numberOfLevels;

			rateOfGrowth += (int)statLevelUpAmount;

			// alter cost for next level
			UpdateLevelUpData();
			UpdateUI();

			ProgressController.UpdatePassive1Level(passiveLevel);

			// play button sound effect
			soundController.PlayButtonSound();
		}
	}

	private void UpdateUI () {
		passiveLevelText.text = "Level " + passiveLevel;
		tacosGainRateText.text = rateOfGrowth.ToString() + " / Collection";
		levelUpStatText.text = "+ " + statLevelUpAmount + " Taco";
		levelUpCostText.text = costLevelUpAmount.ToString();
	}

	private void UpdateLevelUpData () {
		// cost modifier will be > stat modifier to create diminishing returns
		statLevelUpAmount = (int)(passiveLevel * 0.18f * levelUpStatModifier);
		if (statLevelUpAmount < 1) {
			statLevelUpAmount = 1;
		}

		costLevelUpAmount = (int)((Mathf.Pow((passiveLevel), 2.8f) + 5) * levelUpCostModifier);
	}

	private void UpdateUpgradeButton () {
		if (tacoCounter.GetTacoCount() >= costLevelUpAmount) {
			upgradeButtonController.EnableSprite();
		} else {
			upgradeButtonController.DisableSprite();
		}
	}

	private void CalculateRateOfGrowth () {
		rateOfGrowth = 0;

		for (int i = 1; i <= passiveLevel; i++) {
			float levelUpIncrease = (int)(passiveLevel * 0.18f * levelUpStatModifier);
			if (levelUpIncrease < 1) {
				levelUpIncrease = 1;
			}

			rateOfGrowth += (int)levelUpIncrease;
		}
	}

	// will be need for interface that tells player TOTAL rate of growth per second
	public float GetGrowthPerSecond () {
		return (rateOfGrowth / secondsBetweenCollections);
	}
}

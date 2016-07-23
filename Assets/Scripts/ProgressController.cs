using UnityEngine;
using System.Collections;

public class ProgressController : MonoBehaviour {
	// Hub for all progress related data (lvls, purchases, stats, etc)
	// PERMANENT DATA IS NOT STORED HERE

	private PlayerPrefsManager playerPrefsManager;

	private static int currentNumberOfTacos = 0;

	private static int tapPowerLevel = 1;

	private static int passive1Level = 0;

	// Pull all stored data from PlayerPrefsManager.cs
	void Awake () {
		currentNumberOfTacos = PlayerPrefsManager.GetNumberOfTacos();
		tapPowerLevel = PlayerPrefsManager.GetTapLevel();
		passive1Level = PlayerPrefsManager.GetPassive1Level();
	}

	private static void UpdatePlayerPrefsManager () {
		PlayerPrefsManager.SaveData(currentNumberOfTacos, tapPowerLevel, passive1Level);
	}

	public static int GetNumberOfTacos () {
		return currentNumberOfTacos;
	}

	public static int GetTapPowerLevel () {
		return tapPowerLevel;
	}

	public static int GetPassive1Level () {
		return passive1Level;
	}

	public static void UpdateNumberOfTacos (int newNumberOfTacos) {
		currentNumberOfTacos = newNumberOfTacos;

		UpdatePlayerPrefsManager();
	}

	public static void UpdateTapPowerLevel (int newTapPowerLevel) {
		tapPowerLevel = newTapPowerLevel;

		UpdatePlayerPrefsManager();
	}

	public static void UpdatePassive1Level (int newPassiveLevel) {
		passive1Level = newPassiveLevel;

		UpdatePlayerPrefsManager();
	}
}

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	private const string NUMBER_OF_TACOS_KEY = "number_of_tacos";
	private const string TAP_LEVEL_KEY = "tap_level";
	private const string PASSIVE1_LEVEL_KEY = "passive1_level";


	public static void SaveData (int numTacos, int tapLevel, int passive1Level) {
		PlayerPrefs.SetInt(NUMBER_OF_TACOS_KEY, numTacos);
		PlayerPrefs.SetInt(TAP_LEVEL_KEY, tapLevel);
		PlayerPrefs.SetInt(PASSIVE1_LEVEL_KEY, passive1Level);
	}

	public static void LoadData () {}

	public static void ResetAllData (int numTacos = 0, int tapLevel = 1, int passive1Level = 0) {
		PlayerPrefs.SetInt(NUMBER_OF_TACOS_KEY, numTacos);
		PlayerPrefs.SetInt(TAP_LEVEL_KEY, tapLevel);
		PlayerPrefs.SetInt(PASSIVE1_LEVEL_KEY, passive1Level);


		LevelManager.ResetLevel();
	}

	public static int GetNumberOfTacos () {
		return PlayerPrefs.GetInt(NUMBER_OF_TACOS_KEY);
	}

	public static int GetTapLevel () {
		return PlayerPrefs.GetInt(TAP_LEVEL_KEY, 1);
	}

	public static int GetPassive1Level () {
		return PlayerPrefs.GetInt(PASSIVE1_LEVEL_KEY);
	}
}

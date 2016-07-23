using UnityEngine;
using System.Collections;

public class SettingsManager : MonoBehaviour {

	[SerializeField]
	private GameObject settingsMenu = null;

	// Use this for initialization
	void Start () {
		settingsMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenSettingsMenu () {
		settingsMenu.SetActive(true);
	}

	public void CloseSettingsMenu () {
		settingsMenu.SetActive(false);
	}

	public void ResetAllData() {
		PlayerPrefsManager.ResetAllData();
	}
}

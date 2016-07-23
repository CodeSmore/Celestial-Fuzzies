using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpgradeButtonController : MonoBehaviour {

	[SerializeField]
	private Sprite enabledSprite = null;
	[SerializeField]
	private Sprite disabledSprite = null;

	[SerializeField]
	private Image buttonBackgroundImage = null;

	public void EnableSprite () {
		buttonBackgroundImage.sprite = enabledSprite;
	}

	public void DisableSprite () {
		buttonBackgroundImage.sprite = disabledSprite;
	}
}

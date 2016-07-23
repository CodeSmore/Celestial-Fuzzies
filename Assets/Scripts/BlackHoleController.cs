using UnityEngine;
using System.Collections;

public class BlackHoleController : MonoBehaviour {
	private SoundController soundController;

	void Start () {
		soundController = GameObject.FindObjectOfType<SoundController>();
	}

	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.tag == "Destructible") {
			Destroy(collider.gameObject);
			soundController.PlayOtherObjectSuckSound();
			
		} else if (collider.tag == "Small Destructible") {
			Destroy(collider.gameObject);
			soundController.PlayHairballSuckSound();
		} else if (collider.tag == "Red Shirt") {
			Destroy(collider.gameObject);
			soundController.PlayRedShirtCatSound();
		}
	}
}

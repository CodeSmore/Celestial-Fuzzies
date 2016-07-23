using UnityEngine;
using System.Collections;

public class DiscardedObjectController : MonoBehaviour {

	[SerializeField]
	private GameObject[] objects = null; 

	private GameObject spawnPoint;

	void Start () {
		spawnPoint = GameObject.Find("Spawn Point");
	}

	public void Spawn (int index) {
		if (objects[index] != null) {
			GameObject spawnedItem = Instantiate (objects[index], spawnPoint.transform.position, Quaternion.identity) as GameObject;

			// add downward force for effect
			spawnedItem.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0, Random.Range(-1, -200)));
		}
	}
}

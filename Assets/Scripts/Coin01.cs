using UnityEngine;
using System.Collections;

public class Coin01 : MonoBehaviour {

	public int pointsToIncrement = 1;

	// Use this for initialization
	void Start () {

		Invoke ("CancelForce", 5f);
	}
	void CancelForce(){
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

		Destroy (GetComponent<Rigidbody2D>());
	}
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D collider){
		Debug.Log (collider.gameObject.tag);
		if (collider.gameObject.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreaseScore", pointsToIncrement);
			//AudioSource.PlayClipAtPoint (itemSoundClip, Camera.main.transform.position, itemSoundVoulume);
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Coin01 : MonoBehaviour {

	public int pointsToIncrement = 1;
	Vector3 finalPosition;
	bool finalPos=false;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {
		if (finalPos)
			transform.position = finalPosition;
	}

	void OnTriggerEnter2D(Collider2D collider){

		if (collider.gameObject.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreaseScore", pointsToIncrement);
			//AudioSource.PlayClipAtPoint (itemSoundClip, Camera.main.transform.position, itemSoundVoulume);
			Destroy (gameObject);
		}
	}

	void OnCollisionStay2D(Collision2D collision){

		if (((collision.gameObject.tag == "Ground"))) {
			Debug.Log ("Destroyin body");
			finalPos=true;
			finalPosition=transform.position;
			Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
			Destroy (GetComponent<Rigidbody2D>());
			//actvivo el trigger y dibujo la moneda siempre la posicion que keda
			GetComponent<Collider2D> ().isTrigger = true;

		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreaseScore", pointsToIncrement);
			Destroy (gameObject);
		}
	}
}

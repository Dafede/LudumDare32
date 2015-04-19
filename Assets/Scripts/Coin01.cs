using UnityEngine;
using System.Collections;

public class Coin01 : MonoBehaviour {

	public int pointsToIncrement = 1;
	bool isEnemy=false;
	// Use this for initialization
	void Start () {

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

	void OnCollisionStay2D(Collision2D collision){

		if ((collision.gameObject.tag == "Ground")&&isEnemy) {
			Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
			Destroy (GetComponent<Rigidbody2D>());
			//actvivo el trigger y dibujo la moneda siempre la posicion que keda
			GetComponent<Collider2D> ().isTrigger = true;
		}
	}

	void OnCollisionEnter2D(Collision2D collision){
		Debug.Log (collision.gameObject.tag);
		if (collision.gameObject.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreaseScore", pointsToIncrement);
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "Enemy") {
			isEnemy=true;
		}
	}
}

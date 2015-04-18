using UnityEngine;
using System.Collections;

public class Coin01 : MonoBehaviour {

	public int pointsToIncrement = 1;
	Vector3 positionEnd;
	bool startPosition=false;
	// Use this for initialization
	void Start () {

		Invoke ("CancelForce", 5f);
	}
	void CancelForce(){
		Rigidbody2D rb = this.GetComponent<Rigidbody2D>();

		Destroy (GetComponent<Rigidbody2D>());

		//actvivo el trigger y dibujo la moneda siempre la posicion que keda
		//positionEnd = transform.position;
		//startPosition = true;
		//GetComponent<Collider2D> ().isTrigger = true;
	}
	// Update is called once per frame
	void Update () {
		if(startPosition)
		transform.position=positionEnd;
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreaseScore", pointsToIncrement);
			//AudioSource.PlayClipAtPoint (itemSoundClip, Camera.main.transform.position, itemSoundVoulume);
			Destroy (gameObject);
		}
		if (collider.gameObject.tag == "Ground") {
			Debug.Log ("COIN GROUND");

		}
	}

	void OnCollisionEnter2D    (Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			NotificationCenter.DefaultCenter ().PostNotification (this, "IncreaseScore", pointsToIncrement);
			//AudioSource.PlayClipAtPoint (itemSoundClip, Camera.main.transform.position, itemSoundVoulume);
			Destroy (gameObject);
		}
		if (collision.gameObject.tag == "Ground") {
			Debug.Log ("COIN GROUND");
		}
	}
		
}

using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {
	GameObject playercito;
	// Use this for initialization
	void Start () {
		playercito = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Coin01")
		{

			if(collider.attachedRigidbody.velocity.y<0){
				GetComponent<BoxCollider2D>().isTrigger=false;
				if(collider.gameObject.tag == "Coin01"){
					//Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
					Destroy ( collider.gameObject.GetComponent<Rigidbody2D>());
					//actvivo el trigger y dibujo la moneda siempre la posicion que keda
					collider.gameObject.GetComponent<Collider2D> ().isTrigger = true;
				}
			}
			//if(transform.position.y < collider.transform.position.y)GetComponent<BoxCollider2D>().isTrigger=false;
		}
	}
	void FixedUpdate(){
		Physics2D.IgnoreCollision(playercito.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>(),playercito.GetComponent<Rigidbody2D>().velocity.y>0.001f);
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Player") {
			if(collision.gameObject.GetComponent<Rigidbody2D>().velocity.y>0){
				GetComponent<BoxCollider2D>().isTrigger=true;
			}
		}
	}

	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.tag == "Player" || collider.gameObject.tag == "Coin01" )
		{	
			if(collider.attachedRigidbody.velocity.y>0)GetComponent<BoxCollider2D>().isTrigger=false;
			//if(transform.position.y < collider.transform.position.y)GetComponent<BoxCollider2D>().isTrigger=false;
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Coin01" )
		{
			GetComponent<BoxCollider2D>().isTrigger=true;
		}
	}
}

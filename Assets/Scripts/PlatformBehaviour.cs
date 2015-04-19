using UnityEngine;
using System.Collections;

public class PlatformBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Player")
		{
			if(collider.attachedRigidbody.velocity.y<0)GetComponent<BoxCollider2D>().isTrigger=false;
			//if(transform.position.y < collider.transform.position.y)GetComponent<BoxCollider2D>().isTrigger=false;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider){
		if (collider.gameObject.tag == "Player")
		{	
			if(collider.attachedRigidbody.velocity.y>0)GetComponent<BoxCollider2D>().isTrigger=false;
			//if(transform.position.y < collider.transform.position.y)GetComponent<BoxCollider2D>().isTrigger=false;
		}
	}

	void OnCollisionExit2D(Collision2D collision){
		if (collision.gameObject.tag == "Player")
		{
			GetComponent<BoxCollider2D>().isTrigger=true;
		}
	}
}

using UnityEngine;
using System.Collections;

public class Platform02Behaviour : MonoBehaviour {
	GameObject playercito;
	// Use this for initialization
	void Start () {
		playercito = GameObject.FindGameObjectWithTag("Player");

	}
	void FixedUpdate(){
		Physics2D.IgnoreCollision(playercito.transform.GetComponent<Collider2D>(), GetComponent<Collider2D>(),playercito.GetComponent<Rigidbody2D>().velocity.y>0);
	}
	// Update is called once per frame
	void Update () {
	
	}
}

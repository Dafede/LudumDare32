using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float Speed = 1f;
	Vector3 EnemyPosition;
	public GameObject coinPrefab;
	GameObject player;
	Vector3 direction1;
	Vector3 direction2;
	float constantY;
	private bool isWalkingRight = false;
	Vector3 facing1,facing2;

	// Use this for initialization
	void Start () {
		facing1.x = 0;
		facing2.x = 0;
		//Invoke ("Explosion", 1);
		player = GameObject.FindGameObjectWithTag("Player");
		//direction1 = transform.position;
		//constantY = direction1.y;
		//direction2 = player.transform.position;
	}
	void FixedUpdate () {
		facing2=transform.position;
		if ((facing1.x  > facing2.x ) && isWalkingRight) {
			Flip ();
		}
		if ((facing1.x  < facing2.x ) && !isWalkingRight) {
			Flip ();
		}
		facing1=transform.position;
	}
	// Update is called once per frame
	void Update () {

		player = GameObject.FindGameObjectWithTag("Player");
		direction1 = transform.position;
		direction2 = player.transform.position;
		//direction1.y = constantY;
		float step = Speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(direction1, direction2, step);

	}
	void Explosion(){
		EnemyPosition = transform.position;
		GameObject coinAux;
		//Coin 1
		coinAux = Instantiate (coinPrefab, EnemyPosition, Quaternion.identity) as GameObject;
		Rigidbody2D rb = coinAux.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2 (-50,500));
		//Coin 2
		coinAux = Instantiate (coinPrefab, EnemyPosition, Quaternion.identity) as GameObject;
		rb = coinAux.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2 (50,500));
		Destroy (gameObject);
	}

	public void Hitted(){
		Destroy (gameObject);
	}

	void Flip() {
		Debug.Log ("FLIP!");
		isWalkingRight = !isWalkingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}

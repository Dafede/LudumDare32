using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public float Speed = 0.01f;
	Vector3 EnemyPosition;
	public GameObject coinPrefab;

	// Use this for initialization
	void Start () {
		Invoke ("Explosion", 1);
	}
	
	// Update is called once per frame
	void Update () {
		EnemyPosition = transform.position;
		EnemyPosition.x -= Speed;
		transform.position = EnemyPosition;
	}
	void Explosion(){
		EnemyPosition = transform.position;
		GameObject coinAux;
		//Coin 1
		coinAux = Instantiate (coinPrefab, EnemyPosition, Quaternion.identity) as GameObject;
		Rigidbody2D rb = coinAux.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2 (-25,500));
		//Coin 2
		coinAux = Instantiate (coinPrefab, EnemyPosition, Quaternion.identity) as GameObject;
		rb = coinAux.GetComponent<Rigidbody2D>();
		rb.AddForce(new Vector2 (25,500));
		Destroy (gameObject);
	}
}

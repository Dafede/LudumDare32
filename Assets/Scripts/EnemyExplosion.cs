using UnityEngine;
using System.Collections;

public class EnemyExplosion : MonoBehaviour {

	public GameObject Coin;

	// Use this for initialization
	void Start () {
		Instantiate(Coin, transform.position, Quaternion.identity);
		ParticleSystem.Particle[] emittedParticles = new ParticleSystem.Particle[this.GetComponent<ParticleSystem>().particleCount];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

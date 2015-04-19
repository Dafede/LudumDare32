using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

    public GameObject enemyPrefab;
    public float timeSpan = 1.0f;

	// Use this for initialization
	void Start () {
        Invoke("GenerateEnemy", timeSpan);
	}
	
    void GenerateEnemy() {
        Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        Invoke("GenerateEnemy", timeSpan);
    }

    public void DecreaseTimeSpan(float n) { 
        if(timeSpan > 0.1)
            timeSpan -= n;
    }

}

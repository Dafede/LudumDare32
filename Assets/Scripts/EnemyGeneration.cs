using UnityEngine;
using System.Collections;

public class EnemyGeneration : MonoBehaviour {

    public GameObject enemyPrefab;
    public bool SpawnActive;
    public float timeSpan = 1.0f;

	// Use this for initialization
	void Start () {
        SpawnActive = true;
        Invoke("GenerateEnemy", timeSpan);
	}
	
    void GenerateEnemy() {
        if (SpawnActive)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            Invoke("GenerateEnemy", timeSpan + Random.RandomRange(-0.1f,0.1f));
        }
    }

    public void DecreaseTimeSpan(float n) { 
        if(timeSpan > 0.1)
            timeSpan -= n;
    }

}

using UnityEngine;
using System.Collections;

public class Nike : MonoBehaviour {

	public int score = 0;
	public TextMesh marcador;

    private GameObject[] enemyGenerators;


	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncreaseScore");		
		marcador.text = "0";
        enemyGenerators = GameObject.FindGameObjectsWithTag("EnemyGenerator");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void IncreaseScore(Notification notification){
		int pointsToIncrement = (int)notification.data;
		score+=pointsToIncrement;
		marcador.text = score.ToString ();

        /*if (score % 10 == 0)
        {
            foreach (GameObject eg in enemyGenerators)
            {
                eg.GetComponent<EnemyGeneration>().DecreaseTimeSpan(0.1f);
            }
        }*/
	}

}

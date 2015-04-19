using UnityEngine;
using System.Collections;

public class Nike : MonoBehaviour {

	public int score = 0;
	public TextMesh marcador;
    public GameObject EndHUD;
    public GameObject Player;

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

    public void StartGameOver() {
        EndHUD.SetActive(true);
        Player.SetActive(false);
        foreach (GameObject eg in enemyGenerators)
        {
            eg.GetComponent<EnemyGeneration>().SpawnActive = false;
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++) {
            Destroy(enemies[i]);
        }

    }

    public void StartGame()
    {
        score = 0;
        EndHUD.SetActive(false);
        Player.SetActive(true);
        foreach (GameObject eg in enemyGenerators)
        {
            eg.GetComponent<EnemyGeneration>().SpawnActive = true;
        }
    }


}

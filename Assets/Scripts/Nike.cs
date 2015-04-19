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

        if (score % 50 == 0)
        {
            foreach (GameObject eg in enemyGenerators)
            {
                eg.GetComponent<EnemyGeneration>().DecreaseTimeSpan(0.1f);
            }
        }
	}

    public void StartGameOver() {
        EndHUD.SetActive(true);
        Player.SetActive(false);
        foreach (GameObject eg in enemyGenerators)
        {
            eg.GetComponent<EnemyGeneration>().SetSpawnActive(false);
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemies.Length; i++) {
            Destroy(enemies[i]);
        }

    }

    public void StartGame()
    {
        Player.GetComponent<CharacterMovement>().actualLives = Player.GetComponent<CharacterMovement>().TotalLives;

        score = -1;
        NotificationCenter.DefaultCenter().PostNotification(this, "IncreaseScore", 1);
        EndHUD.SetActive(false);
        Player.SetActive(true);
        foreach (GameObject eg in enemyGenerators)
        {
            eg.GetComponent<EnemyGeneration>().SetSpawnActive(true);
        }

        GameObject[] list = GameObject.FindGameObjectsWithTag("Life");
        foreach (GameObject l in list)
        {
            Color n = l.GetComponent<SpriteRenderer>().color;
            n.a = 1.0f;
            l.GetComponent<SpriteRenderer>().color = n;
        }
        
    }


}

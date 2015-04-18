using UnityEngine;
using System.Collections;

public class Nike : MonoBehaviour {

	public int score = 0;
	public TextMesh marcador;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter ().AddObserver (this, "IncreaseScore");					
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void IncreaseScore(Notification notification){
		int pointsToIncrement = (int)notification.data;
		score+=pointsToIncrement;
		marcador.text = score.ToString ();
	}

}

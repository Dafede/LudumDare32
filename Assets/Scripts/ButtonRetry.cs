using UnityEngine;
using System.Collections;

public class ButtonRetry : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown(){
		GameObject.Find ("Nike").GetComponent<Nike> ().StartGame ();
	}
}

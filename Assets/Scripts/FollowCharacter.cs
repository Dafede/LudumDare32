using UnityEngine;
using System.Collections;

public class FollowCharacter : MonoBehaviour {

	public GameObject character;
	Vector3 cameraPos;
	float zCam=0f;

	// Use this for initialization
	void Start () {
		zCam = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		cameraPos = character.transform.position;
		cameraPos.z = zCam;
		cameraPos.y = cameraPos.y +2.5f;
		transform.position=cameraPos;
	}
}

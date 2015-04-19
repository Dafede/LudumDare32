using UnityEngine;
using System.Collections;

public class FollowCharacter : MonoBehaviour {

	public GameObject character;
	Vector3 cameraPos;
	float zCam=0f;
	bool focusChar=true;

	// Use this for initialization
	void Start () {
		zCam = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		/*
			if ((character.transform.position.x < -19.66)||(character.transform.position.x > 19.66)) {
				cameraPos = character.transform.position;
				cameraPos.z = zCam;
				cameraPos.y = cameraPos.y + 2.2f;
				transform.position = cameraPos;
			} else { 
				cameraPos = character.transform.position;
				cameraPos.z = zCam;
				cameraPos.y = cameraPos.y + 2.2f;
				transform.position = cameraPos;
			}
		*/
		if ((character.transform.position.x < -19.66)||(character.transform.position.x > 19.66)) {
			cameraPos = transform.position;
			cameraPos.y = character.transform.position.y +0.85f;
			transform.position = cameraPos;
		} else {
			cameraPos = transform.position;
			cameraPos.x = character.transform.position.x;
			cameraPos.y = character.transform.position.y + 0.85f;
			transform.position = cameraPos;

			/*cameraPos = character.transform.position;
			cameraPos.z = zCam;
			cameraPos.y = cameraPos.y + 2.2f;
			transform.position = cameraPos;*/
		}

	}
}

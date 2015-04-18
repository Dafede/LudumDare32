using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float Speed = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float horizontalTranslation = Input.GetAxis("Horizontal") * Speed;
        transform.Translate(horizontalTranslation, 0, 0);
	}
}

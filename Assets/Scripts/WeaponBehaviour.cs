using UnityEngine;
using System.Collections;

public class WeaponBehaviour : MonoBehaviour {

    // Make damage to the game object collided with
    public void BeginAttackEvent(){
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void EndAttackEvent()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }

	void OnTriggerEnter2D(Collider2D collider){
		if (collider.gameObject.tag == "Enemy")
			collider.gameObject.GetComponent<EnemyBehaviour>().Hitted();
	}
}

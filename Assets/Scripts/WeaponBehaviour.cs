using UnityEngine;
using System.Collections;

public class WeaponBehaviour : MonoBehaviour {

    // Make damage to the game object collided with
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
            col.gameObject.AddComponent<EnemyBehaviour>().Hitted();
    }

    public void BeginAttackEvent(){
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void EndAttackEvent()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
    }
}

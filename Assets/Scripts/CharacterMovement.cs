using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    public float Speed = 1.0f;
    public float JumpHeight = 5000.0f;
    private Animator _animator;
    private Rigidbody2D _rigidBody2D;
    public int TotalLives = 3;

    private bool isJumping = false;
    private bool isHitting = false;
    private bool isWalkingRight = true;
    private int actualLives;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        actualLives = TotalLives;
	}

	
	// Update is called once per frame
	void FixedUpdate () {

        // Horizontal movement
        float horizontalTranslation = Input.GetAxis("Horizontal") * Speed;    
        transform.Translate(horizontalTranslation, 0, 0);

        if (Input.GetAxis("Horizontal") < 0 && isWalkingRight)
            Flip();
        if (Input.GetAxis("Horizontal") > 0 && !isWalkingRight)
            Flip();

        // Jump
        if (Input.GetAxis("Jump") == 1 && isJumping == false)
        {
            _animator.SetBool("IsJumping", true);
            isJumping = true;
            _rigidBody2D.AddForce(Vector2.up * JumpHeight);
        }


        // Hit
        if (Input.GetAxis("Fire1") == 1)
        {
            _animator.SetBool("IsHitting", true);
        }
        else {
            _animator.SetBool("IsHitting", false);
        }
	}

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Ground") {
            isJumping = false;
            _animator.SetBool("IsJumping", false);
        }

        if (col.gameObject.tag == "Enemy") {

            // Do damage to the enemy
            if (isHitting == true) {
                MakeDamage(col);
            }

            // Damage to ourself
            if (isHitting == false) {
                SufferDamage();
            }
        }

    }


    // Make damage to the game object collided with
    void MakeDamage(Collision2D col) { 
    
    }

    // Die logic
    void Die()
    {

    }

    // Recive damage from any source
    void SufferDamage() {
        actualLives--;
        if (actualLives == 0) {
            Die();
        }
    }

   


    // Change character orientation
    void Flip() {
        isWalkingRight = !isWalkingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }



}

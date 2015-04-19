using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

    
    public float Speed = 1.0f;
    public float JumpHeight = 5000.0f;
    public GameObject _redDamageIndicator;

    private Animator _animator;
    private Rigidbody2D _rigidBody2D;

    public int TotalLives = 3;

    private bool isJumping = false;

    private bool isHitting = false;
    private bool isHittingUp = false;
    private bool isHittingDown = false;
    private bool isFacingRight = true;

	private Transform slasher;
    private Vector3 originalSlasherPosition;
    private Quaternion originalSlasherRotation;
    private Vector3 originalSlasherScale;
	public AudioClip hurt;
	public AudioClip jump;
    public int actualLives;

	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
        actualLives = TotalLives;

        slasher = transform.FindChild("Weapon");
        originalSlasherPosition = slasher.localPosition;
        originalSlasherRotation = slasher.localRotation;
        originalSlasherScale = slasher.localScale;

	}
	// Update is called once per frame
	void FixedUpdate () {
		//Physics.IgnoreLayerCollision(8, 9, (Player.GetComponent<Rigidbody>().velocity.y > 0.0f));
        // Jump
        if (Input.GetAxis("Jump") == 1 && isJumping == false)
        {
            _animator.SetBool("IsJumping", true);
            isJumping = true;
			if(GetComponent<Rigidbody2D>().velocity.y==0){
				AudioSource.PlayClipAtPoint (jump, Camera.main.transform.position, 0.25f);
				_rigidBody2D.AddForce(Vector2.up * JumpHeight);
			}
        }

        // Hit
        MakeHit();

        // Horizontal movement
        float horizontalTranslation = Input.GetAxis("Horizontal") * Speed;
        transform.Translate(horizontalTranslation, 0, 0);

        if (Input.GetAxis("Horizontal") < 0 && isFacingRight)
            Flip();
        if (Input.GetAxis("Horizontal") > 0 && !isFacingRight)
            Flip();
	}

    void OnTriggerEnter2D(Collider2D collider) {
        
        if (collider.gameObject.tag == "Ground" || collider.gameObject.tag == "Platform01")
        {
            isJumping = false;
            _animator.SetBool("IsJumping", false);
        }
    }
    void OnCollisionEnter2D(Collision2D col) {

        if (col.gameObject.tag == "Ground" || col.gameObject.tag == "Platform01") {
            
            isJumping = false;
            _animator.SetBool("IsJumping", false);
        }

        if (col.gameObject.tag == "Enemy")
        {
            SufferDamage();
        }
    }
    // Die logic
    void Die()
    {
        GameObject.Find("Nike").GetComponent<Nike>().StartGameOver();
    }
    // Recive damage from any source
    void SufferDamage() {
        actualLives--;
		AudioSource.PlayClipAtPoint (hurt, Camera.main.transform.position, 0.25f);
        _redDamageIndicator.GetComponent<RedDamageBehaviour>().BeginAnimation();

        GameObject[] list = GameObject.FindGameObjectsWithTag("Life");
        GameObject elected = list[0];
        Debug.Log(list.Length);
        foreach (GameObject l in list) {
            if (l.GetComponent<SpriteRenderer>().color.a != 0.0f && elected.transform.position.x < l.transform.position.x) {
                elected = l;
            }
        }
        Color n = elected.GetComponent<SpriteRenderer>().color;
        n.a = 0.0f;
        elected.GetComponent<SpriteRenderer>().color = n;


        if (actualLives == 0) {
            Die();
        }

    }
    
    // Change character orientation
    void Flip() {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        slasher.RotateAround(slasher.position, new Vector3(0, 1, 0), 180);
        originalSlasherScale.x *= -1;
        slasher.localScale = originalSlasherScale;
        originalSlasherRotation = slasher.localRotation;
    }

    void MakeHit() {

        if ((Input.GetAxis("Fire1") == 1))
        {
            // Determinar hacia donde se hace el golpe
            bool makeUpSlash = false;
            bool makeDownSlash = false;
            if (Input.GetAxis("Vertical") > 0) makeUpSlash = true;
            if (Input.GetAxis("Vertical") < 0) makeDownSlash = true;
            float angles = 90;
            if (!isFacingRight) angles = -90;

            if (makeUpSlash && !isHittingUp) //Pegar golpe hacia arriba
            {
                isHittingUp = true;
                slasher.RotateAround(transform.position, new Vector3(0, 0, 1), angles);
            }

            if (makeDownSlash && !isHittingDown)  //Pegar golpe hacia abajo
            {
                isHittingDown = true;
                slasher.RotateAround(transform.position, new Vector3(0, 0, 1), -angles);
            }

            if (!makeDownSlash && !makeUpSlash)  // Pegar golpe hacia adelante
            {
                if (isHittingUp || isHittingDown)
                {
                    ResetSlasherPosition();
                    isHittingUp = false;
                    isHittingDown = false;
                }
            }

            isHitting = true;
            slasher.GetComponent<Animator>().SetBool("MakeSlash", true);
            _animator.SetBool("IsHitting", true);
        }
        else
        {
            isHitting = false;
            isHittingDown = false;
            isHittingUp = false;
            ResetSlasherPosition();
            _animator.SetBool("IsHitting", false);
            slasher.GetComponent<Animator>().SetBool("MakeSlash", false);
        }            
        
    }

    void ResetSlasherPosition() {
        slasher.localRotation = originalSlasherRotation;
        slasher.localPosition = originalSlasherPosition;
        slasher.localScale = originalSlasherScale;
    }

}

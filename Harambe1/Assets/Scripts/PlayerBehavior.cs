using UnityEngine;
using System.Collections;


public class PlayerBehavior : MonoBehaviour {

    public float speed = 2;
	public float maxSpeed = 2;
    public float jumpForce = 1f;
    public float rotateSpeed = 1000;
	public bool grounded = true;
	public bool doubleJump = false;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        move();
        jump();
	}
		

    void move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void jump()
    {
		if(Input.GetButtonDown("Jump") && (grounded))
        {
            rb.AddForce((Vector2.up/* + Vector2.right*/) * jumpForce);
            //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			grounded = false;
		} else if (Input.GetButtonDown("Jump") && (!doubleJump))
		{
			rb.velocity = new Vector3(rb.velocity.x, 0, 0);
			rb.AddForce((Vector2.up/* + Vector2.right*/) * jumpForce);
			//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			doubleJump = true;
		}
    }

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			grounded = true;
			doubleJump = false;
			//rb.velocity = new Vector3(0, 0, 0);
			//move ();
		}

	}
}

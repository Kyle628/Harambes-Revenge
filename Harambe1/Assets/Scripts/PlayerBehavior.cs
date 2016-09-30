using UnityEngine;
using System.Collections;


public class PlayerBehavior : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;

    public float speed = 2;
	public float maxSpeed = 2;
    public float jumpForce = 3f;
    public float rotateSpeed = 1000;
	public bool grounded = true;
	public bool doubleJump = false;
	private SpriteRenderer SpriteRenderer;
	private int frame = 0;

    public Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		SpriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
		frame++;
		if (frame % 10 == 0) {
			ChangeSprite ();
		}
        move();
        jump();
		//hangtime ();
	}
		

    void move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void jump()
    {
		if(Input.GetButtonDown("Jump") && (grounded))
        {
			rb.AddForce(new Vector2(0f, jumpForce));
			rb.AddForce(new Vector2(.1f, 0f));
            //transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			grounded = false;
		} else if (Input.GetButtonDown("Jump") && (!doubleJump))
		{
			rb.velocity = new Vector3(rb.velocity.x, 0, 0);
			rb.AddForce(new Vector2(0f, jumpForce));
			rb.AddForce(new Vector2(.1f, 0f));
			//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			doubleJump = true;
		}

    }
		
	/*
	void hangtime()
	{
		
	if (Input.GetButton("Jump")) {
		rb.AddForce(new Vector2(1f, 0f));
	}

	return;

	}*/

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			grounded = true;
			doubleJump = false;
			//rb.velocity = new Vector3(0, 0, 0);
			//move ();
		}

	}

	void ChangeSprite() {
		if (SpriteRenderer.sprite == sprite1) {
			SpriteRenderer.sprite = sprite2;
		} else {
			SpriteRenderer.sprite = sprite1;
		}

	}
}

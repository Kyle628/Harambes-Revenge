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
	public Vector3 downForce;
	public bool shouldBlink;
	public int numBlinks;

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
			//SpriteRenderer.color = new Color(255, 255, 255);
			Blink();
		}
        move();
        jump();
		dash ();


	}
		

    void move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    void jump()
	{
		if (Input.GetButtonDown ("Jump") && (grounded)) {
			rb.AddForce (new Vector2 (0f, jumpForce));
			rb.AddForce (new Vector2 (.1f, 0f));
			//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			grounded = false;
		} else if (Input.GetButtonDown ("Jump") && (!doubleJump)) {
			rb.velocity = new Vector3 (rb.velocity.x, 0, 0);
			rb.AddForce (new Vector2 (0f, jumpForce));
			rb.AddForce (new Vector2 (.1f, 0f));
			//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			doubleJump = true;
		}

	}

	void dash() {
		if (Input.GetButtonDown ("Dash")) {
			transform.Translate (Vector3.right * 2f);
		}
	}
		


	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			grounded = true;
			doubleJump = false;
			//rb.velocity = new Vector3(0, 0, 0);
			//move ();
		}

		if (other.tag == "Baby") {
			shouldBlink = true;
			SpriteRenderer.color = Color.red;

		}

	}

	void ChangeSprite() {
		if (SpriteRenderer.sprite == sprite1) {
			SpriteRenderer.sprite = sprite2;
		} else {
			SpriteRenderer.sprite = sprite1;
		}

	}

	void Blink() {
		if (shouldBlink) {
			if (numBlinks < 5) {
				SwitchColor ();
				numBlinks++;
			} else {

				shouldBlink = false;
				numBlinks = 0;
			}
		}
	}

	void SwitchColor() {
		if (SpriteRenderer.color == Color.red) {
			SpriteRenderer.color = Color.white;
		} else {
			SpriteRenderer.color = Color.red;
		}
	}
}

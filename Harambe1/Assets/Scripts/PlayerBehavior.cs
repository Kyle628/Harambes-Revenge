﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerBehavior : MonoBehaviour {

	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;

	public Sprite healthSprite;
	public Sprite healthSprite2;
	public Sprite healthSprite3;

	public bool dashing = false;
	private IEnumerator coroutine;

	public float speed = 10;
	public float maxSpeed = 2;
	public float jumpForce = 1000f;
	public float rotateSpeed = 1000;
	public bool grounded = true;
	public bool doubleJump = false;

	public bool hasDashedRecently = false;

	private SpriteRenderer SpriteRenderer;
	private int frame = 0;
	public Vector3 downForce;
	public bool shouldBlink;
	public int numBlinks;
	public int health = 30;
	public bool crazedHarambe = false;

	public Rigidbody2D rb;

	public bool gameOver = false;

	bool hitRegistered = true;

	private SpriteRenderer HealthSpriteRenderer;

	static public int count;

	public Text countText;

	private IEnumerator scoreCoroutine;

	private IEnumerator deathCoroutine;

	public AudioSource[] sounds;

	public AudioSource coin_noise;
	public AudioSource jump_noise;
	public AudioSource damage_noise;
	public AudioSource rage_mode_noise;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		SpriteRenderer = GetComponent<SpriteRenderer>();

		GameObject Health = GameObject.Find("Health");
		HealthSpriteRenderer = Health.GetComponent<SpriteRenderer>();

		count = 0;
		countText.text = count.ToString();

		scoreCoroutine = incrementScore ();
		StartCoroutine (scoreCoroutine);

		sounds = GetComponents<AudioSource>();
		coin_noise = sounds[0];
		jump_noise = sounds[1];




	}

	// Update is called once per frame
	void Update () {
		if (gameOver == true) {
			 
			
			Application.LoadLevel(4);
		}
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

	public IEnumerator die() {
		yield return new WaitForSeconds (2f);
		rb.velocity = new Vector3 (rb.velocity.x, 0, 0);


	}

	public IEnumerator incrementScore () {
		while (true) {
			yield return new WaitForSeconds (.5f);
			count += 1;
			countText.text = count.ToString ();
		}

	}


	void move()
	{
		transform.Translate(Vector3.right * Time.deltaTime * speed);
	}

	void jump()
	{
		
		if ((Input.GetButtonDown ("Jump") || Input.GetTouch(0).phase == TouchPhase.Began) && (grounded) && Input.GetTouch(0).position.x > Screen.width / 2f ) {
			jump_noise.Play ();
			rb.AddForce (new Vector2 (0f, jumpForce));
			rb.AddForce (new Vector2 (.1f, 0f));
			//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			grounded = false;
		} else if ((Input.GetButtonDown ("Jump") || Input.GetTouch(0).phase == TouchPhase.Began) && (!doubleJump) && Input.GetTouch(0).position.x > Screen.width / 2f) {
			jump_noise.Play ();
			rb.velocity = new Vector3 (rb.velocity.x, 0, 0);
			rb.AddForce (new Vector2 (0f, jumpForce));
			rb.AddForce (new Vector2 (.1f, 0f));
			//transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
			doubleJump = true;
		}

	}

	void dash() {
		if ((Input.GetButtonDown ("Dash") || (Input.GetTouch(0).phase == TouchPhase.Began && Input.GetTouch(0).position.x < Screen.width / 2f) && !hasDashedRecently)) {
			dashing = true;
			coroutine = doDash();
			StartCoroutine(coroutine);
	    }
	}

	private IEnumerator doDash(){
		hasDashedRecently = true;
		speed = 50.0f;
		yield return new WaitForSeconds (.2f);
		speed = 15.0f;
		IEnumerator dashRoutine;
		dashRoutine = waitToDash ();
		StartCoroutine (dashRoutine);
	}

	public IEnumerator waitToDash () {
		yield return new WaitForSeconds (5f);
		hasDashedRecently = false;
	}




	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			grounded = true;
			doubleJump = false;
			//rb.velocity = new Vector3(0, 0, 0);
			//move ();
		}

		if (other.tag == "Baby") {
			//GetComponent<AudioSource> ().Play ("test");
			
			if (!crazedHarambe && hitRegistered) {
				damage_noise.Play ();
				hitRegistered = false;
				shouldBlink = true;
				SpriteRenderer.color = Color.red;
				health -= 10;
				if (health == 20) {
					HealthSpriteRenderer.sprite = healthSprite2;
				} else if (health == 10) {
					HealthSpriteRenderer.sprite = healthSprite3;
				}
				if (health <= 0) {
					gameOver = true;
				}
				hitRegistered = true;
			}
			else {
				coin_noise.Play();
				count += 10;
				countText.text = count.ToString();
				Time.timeScale = 1;

			}

		}

		if (other.tag == "Tranq") {
			rage_mode_noise.Play ();
			Time.timeScale = 2;
			crazedHarambe = true;

		}

	}

	void ChangeSprite() {
		if (SpriteRenderer.sprite == sprite1 && !crazedHarambe) {
			SpriteRenderer.sprite = sprite2;
		} else if (crazedHarambe) {
			if (SpriteRenderer.sprite == sprite3) {
				SpriteRenderer.sprite = sprite4;
			} else {
				SpriteRenderer.sprite = sprite3;
			}

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

using UnityEngine;
using System.Collections;

public class BabyController : MonoBehaviour {

	public GameObject moreBaby;
	private int frame = 0;
	private SpriteRenderer SpriteRenderer;




	void Start() {
		//Spawn ();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		InvokeRepeating("SpawnBaby", 1.5f, 9999999999999999f);
	}

	void Update() {
		//Spawn ();
		frame++;
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	public void SpawnBaby()
	{
		GameObject Player = GameObject.Find("gorilla");

		moreBaby = (GameObject)Instantiate(Resources.Load("Baby"), new Vector3(Player.transform.position.x + Random.Range( 30.0f, 55.0f ), 10.0f, 0), Quaternion.identity);
		Rigidbody2D rb = moreBaby.GetComponent<Rigidbody2D>();

		rb.AddForce(Random.Range( .1f, .9f ) * Vector3.down);
		transform.Rotate(Vector3.right * 2f);


		return;
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			Destroy (gameObject);
		}

	}
		

	void SwitchColor() {
		
		if (SpriteRenderer.color == Color.blue) {
			SpriteRenderer.color = Color.white;
		} else {
			SpriteRenderer.color = Color.blue;
		}
	}
}

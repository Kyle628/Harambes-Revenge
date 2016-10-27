using UnityEngine;
using System.Collections;

public class BabyController : MonoBehaviour {

	public GameObject moreBaby;
	private int frame = 0;
	private SpriteRenderer SpriteRenderer;
	public Sprite sprite2;
	private IEnumerator coroutine;




	void Start() {
		//Spawn ();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		coroutine = SpawnBaby();
		StartCoroutine(coroutine);
	}

	void Update() {
		//Spawn ();
		frame++;
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	public IEnumerator SpawnBaby()
	{
		Debug.Log ("spawn");
		yield return new WaitForSeconds(1.0f);
		GameObject Player = GameObject.Find("gorilla");

		moreBaby = (GameObject)Instantiate(Resources.Load("Baby"), new Vector3(Player.transform.position.x + Random.Range( 40.0f, 90.0f ), Random.Range( 10.0f, 15f ), 0), Quaternion.identity);
		Rigidbody2D rb = moreBaby.GetComponent<Rigidbody2D>();

		rb.AddForce(Random.Range( .1f, .9f ) * Vector3.down);
		transform.Rotate(Vector3.right * 2f);

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			Destroy (gameObject);
		}

		if (other.tag == "Player") {
			GameObject Player = GameObject.Find("gorilla");
			PlayerBehavior pScript = Player.GetComponent<PlayerBehavior> ();
			if (pScript.crazedHarambe) {
				pScript.crazedHarambe = false;
				SpriteRenderer.sprite = sprite2;
			} else {
				Destroy (gameObject);
			}
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


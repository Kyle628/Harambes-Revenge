using UnityEngine;
using System.Collections;

public class BabyController : MonoBehaviour {

	public GameObject moreBaby;



	void Start() {
		//Spawn ();
		InvokeRepeating("SpawnBaby", 1.5f, 9999999999999999f);
	}

	void Update() {
		//Spawn ();
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	public void SpawnBaby()
	{
		GameObject Player = GameObject.Find("gorilla");
		GameObject Baby = GameObject.Find("Baby");


		moreBaby = (GameObject)Instantiate(Baby, new Vector3(Player.transform.position.x + Random.Range( 30.0f, 55.0f ), 10.0f, 0), Quaternion.identity);
		Rigidbody2D rb = moreBaby.GetComponent<Rigidbody2D>();

		rb.AddForce(Random.Range( .1f, .9f ) * Vector3.down);
		transform.Rotate(Vector3.right * 2f);


		return;


	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Ground") {
			Destroy (moreBaby);
		}

	}
}

using UnityEngine;
using System.Collections;
using System;

public class BabyController : MonoBehaviour {

	public GameObject moreBaby;
	private int frame = 0;
	private SpriteRenderer SpriteRenderer;
	public Sprite sprite2;
	private IEnumerator coroutine;
	private float lastDistance = -999f;

	public AudioClip vloop;




	void Start() {
		//Spawn ();
		SpriteRenderer = GetComponent<SpriteRenderer>();
		coroutine = SpawnBaby();
		StartCoroutine(coroutine);
		//GetComponent<AudioSource> ().playOnAwake = false;
		//GetComponent<AudioSource> ().clip = vloop;
	}

	void Update() {
		//Spawn ();
		frame++;
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	public IEnumerator SpawnBaby()
	{
		yield return new WaitForSeconds(UnityEngine.Random.Range( 2.0f, 4.0f ));
		GameObject Player = GameObject.Find("gorilla");

		//find our lastDistance object
		GameObject lastDistanceObj = GameObject.Find("LastDistance");
		//get its script
		LastDistance lastDistanceScript = lastDistanceObj.GetComponent<LastDistance> ();
		//get its location...if it is the first time it will be negative
		float lastBabySpawnLoc = lastDistanceScript.lastDistance;

		//have some distances
		//float[] distances = {70f, 70f, 120f};
		// store a random distance from harambe
		float randomDistance = UnityEngine.Random.Range(70f, 100f) + Player.transform.position.x;
		//if this is the first time
		if (lastBabySpawnLoc < 0) {
			//update last spawn location to be this first random distance from harambe
			lastDistanceScript.lastDistance = randomDistance;
		// if not the first time lets make sure this spawn isn't too close to the last one
		} else if (Math.Abs(lastBabySpawnLoc - randomDistance) < 10f) {;
			//add more distance and update the last spawn
			randomDistance += UnityEngine.Random.Range(20f, 60f);
			lastDistanceScript.lastDistance = randomDistance;
		// otherwise the distance is adequate, update the last spawn
		} else {
			lastDistanceScript.lastDistance = randomDistance;
		}
		Debug.Log ("harambe at");
		Debug.Log (Player.transform.position.x + 1f);
		Debug.Log ("baby spawning at");
		Debug.Log(randomDistance);
		moreBaby = (GameObject)Instantiate(Resources.Load("Baby"), new Vector3(randomDistance, UnityEngine.Random.Range( 10.0f, 15f ), 0), Quaternion.identity);
		Rigidbody2D rb = moreBaby.GetComponent<Rigidbody2D>();

		rb.AddForce(UnityEngine.Random.Range( .1f, .9f ) * Vector3.down);
		transform.Rotate(Vector3.right * 2f);
		IEnumerator timeTillDestroy;
		timeTillDestroy = lateDestroy ();
		StartCoroutine (timeTillDestroy);

	}

	public IEnumerator lateDestroy() {
		yield return new WaitForSeconds(5.0f);
		Destroy(gameObject);
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


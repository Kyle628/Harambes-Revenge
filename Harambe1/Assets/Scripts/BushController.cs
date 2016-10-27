using UnityEngine;
using System.Collections;

public class BushController : MonoBehaviour {
	public GameObject moreBush;
	private IEnumerator coroutine;
	private GameObject baby1;
	private GameObject baby2;
	private GameObject baby3;
	private bool babiesHaveSpawned = false;
	// Use this for initialization
	void Start () {
		coroutine = SpawnBush();
		StartCoroutine(coroutine);	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator SpawnBush()
	{
		yield return new WaitForSeconds(Random.Range(5.0f, 10.0f));
		GameObject Player = GameObject.Find("gorilla");

		moreBush = (GameObject)Instantiate(Resources.Load("Bush"), new Vector3(Player.transform.position.x + 28f, transform.position.y, 0), Quaternion.identity);

		Rigidbody2D rb = moreBush.GetComponent<Rigidbody2D>();

		rb.AddForce(1000f * Vector3.left);


	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			Debug.Log ("collision");

				baby1 = (GameObject)Instantiate (Resources.Load ("Baby"), new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Rigidbody2D rb1 = baby1.GetComponent<Rigidbody2D>();

				rb1.AddForce(50f * new Vector3(0f, -5.58f, 0f));

				baby2 = (GameObject)Instantiate (Resources.Load ("Baby"), new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Rigidbody2D rb2 = baby2.GetComponent<Rigidbody2D>();

				rb2.AddForce(50f * new Vector3(2f, -5.58f, 0f));

				baby3 = (GameObject)Instantiate (Resources.Load ("Baby"), new Vector3 (transform.position.x, transform.position.y, 0), Quaternion.identity);
				Rigidbody2D rb3 = baby3.GetComponent<Rigidbody2D>();

				rb3.AddForce(50f * new Vector3(5f, -5.58f, 0f));

		}

	}
}

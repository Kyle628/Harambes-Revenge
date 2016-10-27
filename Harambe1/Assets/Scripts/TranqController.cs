using UnityEngine;
using System.Collections;

public class TranqController : MonoBehaviour {

	public GameObject moreTranq;
	private int frame = 0;
	private SpriteRenderer SpriteRenderer;

	// Use this for initialization
	void Start () {
		SpriteRenderer = GetComponent<SpriteRenderer>();
		InvokeRepeating("SpawnTranq", 30f, 9999999999999999f);
	
	}
	
	// Update is called once per frame
	void Update () {
		frame++;
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	public void SpawnTranq()
	{
		GameObject Player = GameObject.Find("gorilla");

		moreTranq = (GameObject)Instantiate(Resources.Load("Tranq"), new Vector3(Player.transform.position.x + Random.Range( 100.0f, 150.0f ), 0f, 0), Quaternion.identity);
		//Rigidbody2D rb = moreTranq.GetComponent<Rigidbody2D>();

		//rb.AddForce(Random.Range( .1f, .9f ) * Vector3.down);
		//transform.Rotate(Vector3.right * 2f);


		return;
	}
}

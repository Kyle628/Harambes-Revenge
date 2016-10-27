using UnityEngine;
using System.Collections;

public class TranqController : MonoBehaviour {

	public GameObject moreTranq;
	private SpriteRenderer SpriteRenderer;
	private IEnumerator coroutine;

	// Use this for initialization
	void Start () {
		SpriteRenderer = GetComponent<SpriteRenderer>();
		coroutine = SpawnTranq();
		StartCoroutine(coroutine);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (0, 0, 45) * Time.deltaTime);
	}

	private IEnumerator SpawnTranq()
	{
		GameObject Player = GameObject.Find("gorilla");
		while(true){
			yield return new WaitForSeconds(Random.Range(10.0f, 15.0f));
			moreTranq = (GameObject)Instantiate(Resources.Load("Tranq"), new Vector3(Player.transform.position.x + Random.Range( 20.0f, 35.0f ), 4.0f, 0), Quaternion.identity);
			//Rigidbody2D rb = moreTranq.GetComponent<Rigidbody2D>();

			//rb.AddForce(Random.Range( .1f, .9f ) * Vector3.down);
			//transform.Rotate(Vector3.right * 2f);

		}
	}
}

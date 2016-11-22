using UnityEngine;
using System.Collections;

public class GroundShiz : MonoBehaviour {


	public GameObject moreGround;


	//hiiiiiiiiiiiii



	void Start() {
		//Spawn ();
		InvokeRepeating("Spawn", .5f, 9999999999999999f);
	}

	void Update() {
		//Spawn ();
	}

	public void Spawn()
	{
		GameObject Ground = GameObject.Find("Ground");
		moreGround = (GameObject)Instantiate(Ground, transform.position + new Vector3(25, 0, 0), Quaternion.identity);

		return;
		

	}
	

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			GameObject Player = GameObject.Find("Player");
			PlayerBehavior playerBehavior = Player.GetComponent<PlayerBehavior>();
			playerBehavior.grounded = true;
			playerBehavior.doubleJump = false;
		}

	}*/
}

//test

//test2
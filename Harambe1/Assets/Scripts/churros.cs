using UnityEngine;
using System.Collections;

public class churros : MonoBehaviour {

	public GameObject morechurros;

	// Use this for initialization
	void Start () {
		InvokeRepeating("Spawnchurros", 10f, 9999999999999999f);
	}

	// Update is called once per frame
	void Update () {

	}

	public void Spawnchurros()
	{
		GameObject Player = GameObject.Find("gorilla");
		morechurros = (GameObject)Instantiate(Resources.Load("churros"), new Vector3(Player.transform.position.x + Random.Range( 100.0f, 150.0f ), -5.47f, 0f), Quaternion.identity);

		return;


	}
}

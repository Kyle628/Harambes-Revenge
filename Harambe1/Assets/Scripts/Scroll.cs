using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public GameObject moreBackground;


	public float scrollSpeed = .0001f;
	// Use this for initialization
	void Start () {

		InvokeRepeating("SpawnBackground", .4f, 9999999999999999f);
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 offset = new Vector2 (Time.time * scrollSpeed, 0);
		GetComponent<Renderer>().material.mainTextureOffset = offset;
	}

	public void SpawnBackground()
	{
		GameObject backGround = GameObject.Find("Background");
		moreBackground = (GameObject)Instantiate(backGround, transform.position + new Vector3(25, 0, 0), Quaternion.identity);

		return;


	}
}

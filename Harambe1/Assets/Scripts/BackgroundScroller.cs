using UnityEngine;
using System.Collections;

public class BackgroundScroller : MonoBehaviour {

	public float scrollSpeed = 1f;
	public float tileSize = 1f;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {

		startPosition = transform.position;
	
	}


	
	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat (Time.time * scrollSpeed, tileSize);
		transform.position = startPosition + Vector3.forward * newPosition;
	}
}

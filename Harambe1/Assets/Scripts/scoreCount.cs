using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreCount : MonoBehaviour {
	private Text score;
	private float nextTime = 0f;
	// Use this for initialization
	void Start () {
		score.GetComponent<UnityEngine.UI.Text> ().text;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= nextTime) {

			//do something here every interval seconds
			score = "hi";
			nextTime += 1; 

		}
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Replay : MonoBehaviour {

	public Text score_text;

	// Use this for initialization
	void Start () {
		score_text.text = "Score: " + PlayerBehavior.count.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class introText : MonoBehaviour {

	public IEnumerator wait_3_secs;
	//public Canvas intro_canvas;
	public Text intro_text;
	// Use this for initialization
	void Start () {
		//intro_canvas = GetComponent<Canvas>();
		wait_3_secs = change_text();
		StartCoroutine (wait_3_secs);
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	IEnumerator change_text() {
		yield return new WaitForSeconds (7f);
		intro_text.text = "In all seriousness...";
		yield return new WaitForSeconds (2.5f);
		intro_text.text = "Dicks out for Harambe";
		yield return new WaitForSeconds (2.5f);
		Application.LoadLevel (1);
	}
}

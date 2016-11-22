using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class canvas : MonoBehaviour {
	public bool crazedHarambe;
	public GameObject Player;
	public Sprite flashRed;
	public Sprite blank;

	// Use this for initialization
	void Start () {
		Player = GameObject.Find("gorilla");
	
	}
	
	// Update is called once per frame
	void Update () {
		
		//get its script
		PlayerBehavior PlayerBehaviorScript = Player.GetComponent<PlayerBehavior> ();
		//get its location...if it is the first time it will be negative
		crazedHarambe = PlayerBehaviorScript.crazedHarambe;
		if (crazedHarambe) {
			GetComponent<Image>().sprite = flashRed;
		} else {
			GetComponent<Image>().sprite = blank;
		}
	
	}
}

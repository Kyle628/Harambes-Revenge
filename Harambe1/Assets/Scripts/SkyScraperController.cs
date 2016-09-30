using UnityEngine;
using System.Collections;

public class SkyScraperController : MonoBehaviour {
	
	public GameObject moreSkyScraper;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSkyScraper", .5f, 9999999999999999f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnSkyScraper()
	{
		GameObject SkyScraper = GameObject.Find("SkyScraper");
		moreSkyScraper = (GameObject)Instantiate(SkyScraper, transform.position + new Vector3(Random.Range(10.0f, 40.0f), 0, 0), Quaternion.identity);

		return;


	}
}

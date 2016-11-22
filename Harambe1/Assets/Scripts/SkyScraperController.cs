using UnityEngine;
using System.Collections;

public class SkyScraperController : MonoBehaviour {
	
	public GameObject moreSkyScraper;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnSkyScraper", 1f, 9999999999999999f);
		Debug.Log (transform.position);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SpawnSkyScraper()
	{
		GameObject lastDistanceObj = GameObject.Find("LastDistance");
		//get its script
		LastDistance lastDistanceScript = lastDistanceObj.GetComponent<LastDistance> ();
		//get its location...if it is the first time it will be negative
		string lastBuilding = lastDistanceScript.lastBuilding;

		string[] buildings_arr = new string[] {"SkyScraper (1)", "skyscraper2 (1)", "skyscraper3 (1)"};
		System.Collections.Generic.List<string> buildings = new System.Collections.Generic.List<string>(buildings_arr);
		string buildingType = buildings_arr[UnityEngine.Random.Range (0, 3)];
		if (buildingType == lastBuilding) {
			buildings.Remove(lastBuilding);
			buildings_arr = buildings.ToArray();
			buildingType = buildings_arr[UnityEngine.Random.Range (0, 2)];
			lastDistanceScript.lastBuilding = buildingType;
			}

		GameObject SkyScraper = GameObject.Find(buildingType);
		moreSkyScraper = (GameObject)Instantiate(SkyScraper, new Vector3(transform.position.x + 30f, -3, 0), Quaternion.identity);
		lastDistanceScript.lastBuilding = buildingType;

		return;


	}
}

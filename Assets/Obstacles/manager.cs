using UnityEngine;
using System.Collections;

public class manager : MonoBehaviour {
	
	public int asteriodCount;
	private int start;
	public GameObject [] aster = new GameObject [3];
	// Use this for initialization
	void Start () {
		start = GameObject.FindGameObjectsWithTag("obstacle").Length;
	}
	
	// Update is called once per frame
	void Update () {
		asteriodCount = GameObject.FindGameObjectsWithTag("obstacle").Length;
		if(asteriodCount<start)
			Instantiate(aster[Random.Range(0,3)]);
//		Debug.Log(asteriodCount);
	}
}

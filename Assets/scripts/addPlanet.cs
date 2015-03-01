using UnityEngine;
using System.Collections;

public class addPlanet : MonoBehaviour {

	public GameObject Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Planet")
			Target.GetComponent<PlayerController> ().planet = other.gameObject.transform;
	}
}

using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	// Use this for initialization
	public ShipAi callback;
	void Start () {
		gameObject.tag = callback.gameObject.tag;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		callback.callback (other);
	}
}

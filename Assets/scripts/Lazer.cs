using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	bool move = true;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			if(move)
			transform.Translate(transform.forward * 100 * Time.deltaTime);
	}

	public void moved(){
		move = true;
	}
	
}

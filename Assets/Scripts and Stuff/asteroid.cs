using UnityEngine;
using System.Collections;

public class asteroid : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision Other) {
		if(Other.gameObject.tag == "Planet")
			Destroy(this.gameObject);
	}
}

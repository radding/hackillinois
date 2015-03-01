using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	
	public float tyma = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * 10f * Time.deltaTime);
		if(tyma <= 0.0f){
			Destroy(this.gameObject);
		}
		tyma -= Time.deltaTime;
	}
}

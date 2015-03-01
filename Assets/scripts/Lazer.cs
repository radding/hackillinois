using UnityEngine;
using System.Collections;

public class Lazer : MonoBehaviour {

	bool move = true;
	float timer = 2.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
			if (move)
				transform.position += transform.forward * 100 * Time.deltaTime;
		if (timer <= 0.0f)
						Destroy (this.gameObject);
		timer -= Time.deltaTime;
	}

	public void moved(){
		move = true;
	}
	
}

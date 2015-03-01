using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int health = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0)
			killSelf ();
	}

	private void killSelf(){
		Destroy (this.gameObject);
	}

	public void hurt(){
		health -= 10;
	}
}

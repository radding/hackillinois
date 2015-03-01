using UnityEngine;
using System.Collections;

public class makecharacterSelectLive : MonoBehaviour {
	public GameObject target;
	public GameObject GM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	if (target.GetComponent<StartController>().isActive && GM.GetComponent<GameManager>().onCharacter) {
		this.camera.enabled = true;
	}
	}
}

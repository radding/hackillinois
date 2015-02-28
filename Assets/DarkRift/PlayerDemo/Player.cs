using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public bool isControllable;

	void Awake()
	{
		this.GetComponentInChildren<OpenDiveSensor>().cameraleft.enabled = false;
		this.GetComponentInChildren<OpenDiveSensor>().cameraright.enabled = false;

	}

	//This is a really simple script to move the player around,
	//nothing you can't already do :)
	void Update () {
		if( isControllable ){
			//Move
			transform.Translate(0, 0, Input.GetAxis("Vertical"));
			//Rotation
			transform.Rotate(0, Input.GetAxis("Horizontal"), 0 );
		}
	}
}

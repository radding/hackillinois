using UnityEngine;
using System.Collections;

public class CharacterControllerAndroid : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject ammo;
	bool canFire;
	public float fireRate;
	public float rotSpeed = 1000f;
	public GameObject myo;
	ThalmicMyo thalmicMyo;

	// Use this for initialization
	void Start () {
		thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * speed * Time.deltaTime);
		Vector3 newEulerAngles = thalmicMyo.gyroscope;
		transform.Rotate (newEulerAngles);
		print (newEulerAngles);
	}
}

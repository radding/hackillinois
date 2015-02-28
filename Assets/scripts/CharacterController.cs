using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	public float speed = 10.0f;
	public float rotSpeed = 1.0f;
	public GameObject ammo;
	bool canFire;
	public float fireRate;
	public GameObject myo;
	private ThalmicMyo thalmicMyo;

	// Use this for initialization
	void Start () {
		MyoManager.Initialize ();
		MyoManager.PresentPairing (); 
//		thalmicMyo = myo.GetComponent<ThalmicMyo> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (transform.forward * speed * Time.deltaTime);
		Vector3 newEulerAngles = MyoManager.GetQuaternion ().eulerAngles;
//		newEulerAngles = thalmicMyo.gyroscope;
		transform.Rotate (newEulerAngles);
	}
}

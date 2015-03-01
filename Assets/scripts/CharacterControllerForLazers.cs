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
		if (Input.GetKeyDown (KeyCode.D))
						transform.position += transform.right;
		if (Input.GetKeyDown (KeyCode.A))
			transform.position -= transform.right;
		if (Input.GetKey (KeyCode.RightArrow))
						transform.Rotate (Vector3.up * 2);
		if (Input.GetKey (KeyCode.LeftArrow))
				transform.Rotate (Vector3.up * -2);
		transform.Translate (transform.forward * speed * Time.deltaTime);
		Vector3 newEulerAngles = MyoManager.GetQuaternion ().eulerAngles;
//		newEulerAngles = thalmicMyo.gyroscope;
//		transform.Rotate (newEulerAngles);
		if (Input.GetKeyDown (KeyCode.Space))
						fire ();
	}

	void fire(){
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit)) {
			if(hit.collider.gameObject.GetComponent<Health>())
				hit.collider.gameObject.GetComponent<Health>().hurt();
		}
		GameObject clone = (GameObject)Instantiate (ammo, transform.position, Quaternion.Euler(transform.eulerAngles));
//		clone.transform.eulerAngles = ;
//		clone.transform.localRotation = transform.localRotation;
		
	}
}

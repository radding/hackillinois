using UnityEngine;
using System.Collections;

public class CharacterControllerAndroid : MonoBehaviour {
	
	public float speed = 10.0f;
	public GameObject ammo;
	bool canFire;
	public float fireRate;
	public float rotSpeed = 10f;
	public GameObject myo;
	public float turnThreshold = 1f;
	private Vector3 lastRot = Vector3.zero;
	ThalmicMyo thalmicMyo;
	
	// Use this for initialization
	void Start () {
		thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		resetMyoOrientation ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time < 1)
			resetMyoOrientation ();
		
		Vector3 newEulerAngles = myo.transform.rotation.eulerAngles;
		if (newEulerAngles.x > 180)
			newEulerAngles.x = newEulerAngles.x - 360;
		if (newEulerAngles.y > 180)
			newEulerAngles.y = newEulerAngles.y - 360;
		if (newEulerAngles.z > 180)
			newEulerAngles.z = newEulerAngles.z - 360;
		newEulerAngles.x *= -1f;
		newEulerAngles.z *= -1f;
		newEulerAngles.y = 0f;
		
		transform.Rotate (new Vector3(angleCheck(lastRot.x, newEulerAngles.x), angleCheck(lastRot.y, newEulerAngles.y),
		                              angleCheck(lastRot.z, newEulerAngles.z))*Time.deltaTime*rotSpeed*100);
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		lastRot = transform.rotation.eulerAngles;
	}
	
	void resetMyoOrientation()
	{
		myo.transform.rotation = Quaternion.Euler (0, 0, 0);
	}
	
	float angleCheck(float last, float cur)
	{
		if (Mathf.Abs (last - cur) >= turnThreshold)
			return cur;
		else
			return 0;
		
	}
}

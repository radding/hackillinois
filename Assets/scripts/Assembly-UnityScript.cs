using UnityEngine;
using System.Collections;

public class CarSmoothFollow : MonoBehaviour {
	

	public Transform target;
	public Transform lookAt;
	public float distance = 3.0f;
	public float height = 3.0f;
	public float damping = 5.0f;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;
	public float maxDist = 10.0f;
	
	void Update () {
		Vector3 wantedPosition;
		Vector3 temp;
		if(followBehind)
			wantedPosition = target.TransformPoint(0, height, -distance);
		else
			wantedPosition = target.TransformPoint(0, height, distance);

		temp = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime*damping);
		temp -= Time.deltaTime*target.transform.parent.rigidbody.velocity * maxDist;
		transform.position = temp;
		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt (lookAt, lookAt.up);
	}
	
}
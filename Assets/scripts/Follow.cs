using UnityEngine;
using System.Collections;

/*******************************************************************
 * This Script Is to force the camera to follow the player. This 
 * 		is designed to follow the empty with the player parent. This 
 * 	Variable Overview:
 * 		1. target: the object to follow.
 * 		2. smooth: this is the spring factor.
 * 		3. back: how far back to set the camera (relative to target)
 * 		4. up: how far up to set the camera (relative to target)
 * *****************************************************************/


public class Follow : MonoBehaviour {
	
	private Vector3 velocity = new Vector3(0,0,0);
	public GameObject target;
	public float smooth;
	public float damping;
	public float mass = .5f;
	public float maxDistance = 50.0f;
	public float back = 3f;
	public float up = 1.5f;
	public GameObject facerientation;
	public GameObject player;
	private Vector3 tarPos;
	float sensitivity = 5.0f;
	public bool first;
	LayerMask mask;
	public int excludeLayer1;
	public int excludeLayer2;
	void Start () {
		//target = GameObject.FindGameObjectWithTag ("Player");
		//Screen.lockCursor = true;
		mask = 1 << excludeLayer1 | 1 << 14;
		mask = ~mask;
		transform.position = target.transform.position;
	}
	
	// Update is called once per frame
	//	void LateUpdate () {
	void OutOfRange()
	{
		if (!first) {
			tarPos = facerientation.transform.position + target.transform.up * up - facerientation.transform.forward * back;
			//transform.position = new Vector3 (target.transform.position.x, target.transform.position.y + 2, target.transform.position.z + 5);
			//transform.position = Vector3.Lerp (transform.position, tarPos, Time.deltaTime * smooth);
			//			tarPos = target.transform.position - target.transform.forward * maxDistance;
			//			Debug.Log(tarPos);
			Vector3 temp = Vector3.Lerp (transform.position, tarPos, Time.deltaTime * smooth);
			compensate(target.transform.position,ref temp);
			transform.position = temp;
			transform.LookAt (facerientation.transform.position);
			
		} 
		//		else 
		//		{
		//			transform.position = target.transform.position;
		//			//transform.LookAt(target.transform.position);
		//			transform.rotation = target.transform.rotation;
		//		}
		//		//first = target.GetComponent<looky> ().fps;
	}
	
	void LateUpdate()
	{
		OutOfRange ();
		//		// Calculate spring force
		////		tarPos = facerientation.transform.position + target.transform.up * up - facerientation.transform.forward * back;
		////		if(Vector3.Distance(transform.position,target.transform.position)<maxDistance)
		////		{
		////			Vector3 stretch = Vector3.ClampMagnitude(target.transform.position- transform.position, maxDistance);
		//			Vector3 stretch = target.transform.position - transform.position;
		//			Vector3 acceleration = (stretch * smooth - velocity * damping);
		//			
		//			// Apply acceleration
		//			velocity += acceleration * (float)Time.deltaTime;
		//			
		//			// Apply velocity
		//			transform.position += velocity * (float)Time.deltaTime;
		//
		////		}
		////		else 
		////		{
		////			transform.position = Vector3.ClampMagnitude(target.transform.position - transform.position,maxDistance);
		////		}
		//		transform.LookAt (player.transform);
		
	}
	void compensate(Vector3 from, ref Vector3 to)
	{
		RaycastHit hit;
		Debug.DrawLine (to, from, Color.green);
		if(Physics.Linecast(to, from, out hit, mask.value))
			if(hit.collider.gameObject.tag == "planet")// || (hit.collider.gameObject.layer != 8  && hit.collider.gameObject.layer != 14 ))
				to = new Vector3(hit.point.x, to.y, hit.point.z);
	}
	
}

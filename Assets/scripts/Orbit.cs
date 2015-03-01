using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Orbit : MonoBehaviour {

	public bool isTardis = false;
	public float radius;
	private float orbitalSpeed;
	public float rotateSpeed;
	public Transform rotateAround;
	public float eccentricity;
	private float B;
	public float theta;
	private float A;
	public float speedModifier = 100000000000f;
	public bool random = false;
	public List<Transform> planets;
	public int next;

	// Use this for initialization
	void Start () {
		//rotateAround = GameObject.FindGameObjectWithTag ("sun").transform;
		//theta = 0;
		A = Vector3.Distance(this.transform.position, rotateAround.position)/(1f+eccentricity);
		B = Mathf.Sqrt (Vector3.Distance (this.transform.position, rotateAround.position) * A);
		if (random) speedModifier = Random.Range (100000000000f, 100000000000000f + 1);
		if (isTardis)
						StartCoroutine (getNext ());
	}
	
	// Update is called once per frame
	void Update () {
		if(eccentricity <=0)
			transform.RotateAround(rotateAround.position, Vector3.up, orbitalSpeed * Time.deltaTime);
		else
		{
			float x = transform.position.x;
			float y = transform.position.y;
			y = (B) * Mathf.Cos (theta * .005f) + rotateAround.position.z;
			x = A*Mathf.Sin (theta * .005f)+ rotateAround.position.x + A * eccentricity;
//			transform.position = Vector3.Lerp(transform.position, new Vector3(x,0,y), .5f);
			if(!isTardis)
				transform.position = new Vector3(x,0,y);
			else if(isTardis)
				transform.position = Vector3.Lerp(transform.position,new Vector3(x,0,y),40*Time.deltaTime);
			theta += orbitalSpeed;
			transform.Rotate (transform.up * rotateSpeed * Time.deltaTime);			
		}
		float distance = Vector3.Distance (this.transform.position, rotateAround.position);
		float speedSquared = (6.67f * Mathf.Pow (10, -11) * rotateAround.gameObject.rigidbody.mass*speedModifier) / distance;
		orbitalSpeed = Mathf.Sqrt (speedSquared);
		//transform.RotateAround(rotateAround.position, Vector3.up, orbitalSpeed * Time.deltaTime);
		if(isTardis)
		{
			rotateAround = planets[next];
//			transform.position = Vector3.Lerp(transform.position,rotateAround.position+new Vector3(100,0,100),40*Time.deltaTime);
		}

	}

	IEnumerator getNext ()
	{
		while(true)
		{
			next = Random.Range(0,10);
			yield return new WaitForSeconds(10f);
		}
	}

	int Compare(Transform one, Transform two)
	{
		return Vector3.Distance (transform.position, one.position).CompareTo (Vector3.Distance (transform.position, two.position));
	}
}

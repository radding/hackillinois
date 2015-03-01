using UnityEngine;
using System.Collections;

public class slerpTest : MonoBehaviour {

	public enum SlerpStates
	{
		FIRST,
		SECOND
	};
	private SlerpStates state = SlerpStates.FIRST;
	public Transform planet;
	private Vector3 to;
	public float speed;
	private float theta;
	private float thetaStart;
	public float num;
	public float boostTime;
	float r;
	// Use this for initialization
	void Start () {
		r = Vector3.Distance (transform.position, planet.position);
		to = (planet.position - transform.position);
		theta = ((-(Vector3.Angle (transform.position, to) +90f)+180f) * Mathf.PI/180f) + Mathf.PI/2 ;
		thetaStart = theta;
	}
	
	// Update is called once per frame
	void Update () {

		//rigidbody.velocity += transform.forward;
		switch(state)
		{

			case(SlerpStates.FIRST):
				speed += Mathf.Sqrt((6.67f * Mathf.Pow (10, -11) * planet.gameObject.rigidbody.mass*100000000000f) / r);
				transform.position = new Vector3 ((r) * Mathf.Cos (theta), 0 , (r)*Mathf.Sin (theta))+planet.position;
				theta += speed/r*Time.deltaTime;
				to = (planet.position - transform.position);
				transform.eulerAngles = new Vector3 (transform.eulerAngles.x, Vector3.Angle (to, transform.position), transform.eulerAngles.x);
				if (theta > (2*Mathf.PI+ thetaStart)+.1f)
					state = SlerpStates.SECOND;
				break;
			case (SlerpStates.SECOND):
				transform.position += transform.forward * speed * Time.deltaTime;
				if(boostTime >=95f && speed >= 0f)
				{
					speed -= speed/boostTime;
					boostTime -= Time.deltaTime;
				}
				if(speed<0f)
					speed = 0f;
				break;
		}

	}
}

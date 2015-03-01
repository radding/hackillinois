// SeekSteer.cs
// Written by Matthew Hughes
// 19 April 2009
// Uploaded to Unify Community Wiki on 19 April 2009
// URL: http://www.unifycommunity.com/wiki/index.php?title=SeekSteer
using UnityEngine;
using System.Collections;

public class SeekSteer : MonoBehaviour
{
	
	public Transform target;
	public float waypointRadius = 1.5f;
	public float damping = 0.1f;
	public bool loop = false;
	public float speed = 2.0f;
	public bool faceHeading = true;
	public bool chaseThat = true;
	public float fiyaTyme;
	public GameObject bullet;
	
	private Vector3 currentHeading,targetHeading;
	private int targetwaypoint;
	private Transform xform;
	private bool useRigidbody;
	private Rigidbody rigidmember;
	private Vector3 holder;
	private float timer = .5f;
	
	public enum State{
		WANDERING,
		ATTACK,
		EVADE
	};
	
	public State state = State.ATTACK;
	
	
	// Use this for initialization
	protected void Start ()
	{
		holder = new Vector3 (1, 0, 1);
		xform = transform;
		currentHeading = xform.forward;
		targetwaypoint = 0;
		if(rigidbody!=null)
		{
			useRigidbody = true;
			rigidmember = rigidbody;
		}
		else
		{
			useRigidbody = false;
		}
	}
	
	
	// calculates a new heading
	protected void FixedUpdate ()
	{
		
		switch(state){
		case State.ATTACK:
			targetHeading = target.position - xform.position;
			break;
		case State.EVADE:

			if(Random.Range(0,100) > 90 && timer <=0.0f){
				timer = .5f;
				targetHeading = Random.Range (0, 100) > 5 ? new Vector3(Random.insideUnitCircle.x * 5, 0, Random.insideUnitCircle.y * 5): targetHeading;
			}
			else{
				targetHeading = xform.position - target.position;
			}
			timer -= Time.deltaTime;
			Quaternion oldRot = transform.rotation;
			Quaternion newRot = Quaternion.LookRotation (targetHeading);
			transform.rotation = Quaternion.Lerp (oldRot, newRot, .7f);
			break;
		case State.WANDERING:
			targetHeading = xform.position - new Vector3(Random.insideUnitCircle.x * 5, 0, Random.insideUnitCircle.y * 5);
			break;
		}
		
		currentHeading = Vector3.Lerp(currentHeading,targetHeading,damping*Time.deltaTime);
	}
	
	// moves us along current heading
	protected void Update()
	{
		if(!target && state != State.WANDERING)
			state = State.WANDERING;
		
		if(useRigidbody)
			rigidmember.velocity = currentHeading * speed;
		else
			xform.position +=currentHeading * Time.deltaTime * speed;
		if(faceHeading)
			xform.LookAt(xform.position+currentHeading);
		if(state == State.ATTACK){
			if(Vector3.Distance(xform.position,target.position)<=waypointRadius)
			{
				
			}
			if(Vector3.Distance(transform.position, target.position) <=100.9f){
				if(!target){
					state = State.WANDERING;
					return;
				}
				if(Vector3.Angle(transform.position, target.position)>= -5.0f && Vector3.Angle(transform.position, target.position)<= 5.0f){
					bool doDamage = Random.Range(0,100) < 60 ? true : false;
					if(doDamage){
						target.gameObject.GetComponent<Health>().hurt();
						if(fiyaTyme <= 0.0f){
							Instantiate(bullet, transform.position, transform.rotation);
							fiyaTyme = 2.0f;
						}
						fiyaTyme -= Time.deltaTime;
					}

				}
			}
		}
	}
	
}



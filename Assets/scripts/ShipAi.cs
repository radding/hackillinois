using UnityEngine;
using System.Collections;

public class ShipAi : MonoBehaviour {
	
	public float rotSpeed = .05f;
	public float attackRotSpeed = 0.5f;
	public float evadeRotSpeed = .7f;
	public float timer = 1.0f;
	public float reset;
	GameObject target;
	public ShipAi parent;

	public float speed = 10.0f;
	public float maxDist = 10.0f;
	public float minDist = 2.0f;

	public enum State{
		WANDER = 0,
		ATTACK = 1,
		EVADE = 2,
		DEAD = 3
	};
	
	private Vector3 position;
	
	public State state = State.WANDER;
	
	// Use this for initialization
	void Start () {
		reset = timer;
		position = new Vector3(Random.insideUnitCircle.x * 5, 0, Random.insideUnitCircle.y * 5);
//		target = new GameObject();
	}
	
	// Update is called once per frame
	void Update () {
		switch(state){
			case(State.WANDER):
				wander();
				break;
			case (State.ATTACK):
				attack();
				break;
			case (State.EVADE):
				evade();
				break;
		}
		transform.Translate (Vector3.forward * speed * Time.deltaTime);

	}
	
	void wander(){
		Quaternion oldRot = transform.rotation;
		Quaternion newRot = Quaternion.LookRotation (position);
		transform.rotation = Quaternion.Lerp (oldRot, newRot, rotSpeed);
		if(timer < 0.0f){
			position = Random.Range (0, 100) > 5 ? new Vector3(Random.insideUnitCircle.x * 5, 0, Random.insideUnitCircle.y * 5): position;
			timer = reset;
		}
		timer -= Time.deltaTime;
	}

	void attack(){

		Quaternion oldRot = transform.rotation;
		Quaternion newRot = Quaternion.LookRotation (target.gameObject.transform.position);
		transform.rotation = Quaternion.Lerp (oldRot, newRot, attackRotSpeed);

		if(Vector3.Distance(transform.position, target.transform.position) > minDist && Vector3.Distance(transform.position, target.transform.position) < maxDist){
			transform.Translate (Vector3.forward * speed * Time.deltaTime);
		}
		else{
			state = State.WANDER;
			target.GetComponent<ShipAi>().changeState(State.WANDER);
		}

	}

	void evade(){
		Quaternion oldRot = transform.rotation;
		Quaternion newRot = Quaternion.LookRotation (position);
		transform.rotation = Quaternion.Lerp (oldRot, newRot, evadeRotSpeed);
		if(timer < 0.0f){
			position = Random.Range (0, 100) < 50 ? new Vector3(Random.insideUnitCircle.x * 5, 0, Random.insideUnitCircle.y * 5): position;

			timer = reset;
		}
		timer -= Time.deltaTime;
	}

	public void callback(Collider other){
//		Debug.Log ("tiggered");
//		Vector3 forward = (other.transform.position - transform.position).normalized;
//		RaycastHit hit;
//		Debug.DrawRay (transform.position, forward,Color.blue);
////		Debug.Break ();
//		if(Physics.Raycast (transform.position, forward, out hit)){
//			string thing = gameObject.tag == "Red" ? "Blue" : "Red";
//			Debug.Log("thing = " + thing);
//			Debug.Log("other = " + hit.collider.gameObject.tag);
//			if(thing.Equals(hit.collider.gameObject.tag) && hit.collider.gameObject){
//				state = State.ATTACK;
//				target = hit.collider.gameObject;
//				target.GetComponent<ShipAi>().changeState(State.EVADE);
//			}
//		}

	}

	public void changeState(State nxtState){
		if(parent)
			parent.state = nxtState;
		else{
			this.state = nxtState;
		}
	}

}

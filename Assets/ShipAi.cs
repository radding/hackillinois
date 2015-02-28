using UnityEngine;
using System.Collections;

public class ShipAi : MonoBehaviour {
	
	public float rotSpeed = 1.0f;
	public float timer = 1.0f;
	public float reset;
	GameObject target;

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
		transform.Translate (Vector3.forward);

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

	}

	void evade(){
	
	}
}

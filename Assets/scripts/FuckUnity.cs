using UnityEngine;
using System.Collections;

public class FuckUnity : MonoBehaviour {

	// Use this for initialization
	public GameObject redPerson;
	public GameObject bluePerson;

	public GameObject prefab;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!redPerson){
			redPerson = (GameObject)Instantiate(prefab);
			redPerson.tag = "Red";
			redPerson.GetComponent<SeekSteer>().target = bluePerson.transform;
			redPerson.GetComponent<SeekSteer>().state = SeekSteer.State.ATTACK;
			bluePerson.GetComponent<SeekSteer>().target = redPerson.transform;
			bluePerson.GetComponent<SeekSteer>().state = SeekSteer.State.ATTACK;
		}

		if(!bluePerson){
			bluePerson = (GameObject)Instantiate(prefab);
			bluePerson.tag = "Blue";
			bluePerson.GetComponent<SeekSteer>().target = redPerson.transform;
			bluePerson.GetComponent<SeekSteer>().state = SeekSteer.State.ATTACK;
			redPerson.GetComponent<SeekSteer>().target = bluePerson.transform;
			redPerson.GetComponent<SeekSteer>().state = SeekSteer.State.ATTACK;
		}
	}

	public void createNewFuckers(bool isPlaya){

	}
}

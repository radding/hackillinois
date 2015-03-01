using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {
	Vector3 newEulerAngles = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MyoRotation(string param)
	{
		string[] arr = param.Split (' ');
		Quaternion tmpRot = new Quaternion(float.Parse (arr [0]), float.Parse (arr [1]), float.Parse (arr [2]), float.Parse (arr [3]));
		newEulerAngles = tmpRot.eulerAngles;
	}

	public Vector3 GetMyoRotation() {return newEulerAngles;}
}

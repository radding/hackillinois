using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {
	Vector3 newEulerAngles = Vector3.zero;
	GameObject myo;

	// Use this for initialization
	void Start () {
		myo = GameObject.FindWithTag ("Myo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MyoRotation(string param)
	{
		//if (param != null)
		//{
		string[] arr = param.Split (' ');
		myo.transform.localRotation = new Quaternion(float.Parse (arr [0]), float.Parse (arr [1]), float.Parse (arr [2]), float.Parse (arr [3]));
		//}
	}

	//public Quaternion GetMyoRotation() {return newEulerAngles;}
}

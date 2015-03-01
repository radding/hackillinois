using UnityEngine;
using System.Collections;

public class MessageManager : MonoBehaviour {
	Vector3 newEulerAngles = Vector3.zero;
	GameObject myo;
	string curPose;

	// Use this for initialization
	void Start () {
		myo = GameObject.FindWithTag ("Myo");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MyoRotation(string param)
	{


		string[] arr = param.Split (' ');
		//myo.transform.rotation = float.Parse (arr [0]);
		//myo.transform.rotation.x = float.Parse (arr [1]);
		//myo.transform.rotation.y = float.Parse (arr [2]);
		myo.transform.eulerAngles = new Vector3 (float.Parse (arr [1]), float.Parse (arr [2]), float.Parse (arr [0]));
		//mTextView.setRotation(roll);
		//mTextView.setRotationX(pitch);
		//mTextView.setRotationY(yaw);
		//myo.transform.localRotation = new Quaternion(float.Parse (arr [0]), float.Parse (arr [1]), float.Parse (arr [2]), float.Parse (arr [3]));
		//}
	}

	public void MyoPose(string param)
	{
		curPose = param;
	}

	public string GetMyoPose() {return curPose;}
}

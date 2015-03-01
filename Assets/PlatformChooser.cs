using UnityEngine;
using System.Collections;

public class PlatformChooser : MonoBehaviour {
	public GameObject oculus, cardboard;
	// Use this for initialization
	void Awake () {
		if (Application.platform == RuntimePlatform.Android)
			cardboard.SetActive (true);
		else
			oculus.SetActive(true);
	}
}

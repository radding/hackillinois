// LevelLoadButton
// Load specified level when clicked on

using UnityEngine;
using System.Collections;

public class LevelLoadButton : MonoBehaviour {

	public string LevelToLoad = "Enter level name here";

	void OnClick()
	{
		Application.LoadLevel(LevelToLoad);
	}
}

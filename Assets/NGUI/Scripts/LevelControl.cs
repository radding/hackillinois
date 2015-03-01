using UnityEngine;
using System.Collections;

public class LevelControl : MonoBehaviour
{
	// Use this for initialization
	void Start()
	{
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown("q"))
			GoBackLevel();
		
		if(Input.GetKeyDown("w"))
			GoForwardLevel();
		
		if(Input.GetKeyDown("r"))
			ReloadLevel();
	}
	
	public void GoForwardLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
	
	public void GoBackLevel()
	{
		Application.LoadLevel(Application.loadedLevel - 1);
	}
	
	public void ReloadLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GoToLevel(int level)
	{
		Application.LoadLevel(level);
	}
}

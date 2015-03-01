using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour 
{

	public int NumberOfPlayers = 1;
	public int player1;
	public int player2 = 0; 
	public int player3 = 100;
	public int player4 = 100;
	public GameObject [] CharacterArray = new GameObject[2];
	public GameObject [] ShipArray = new GameObject[1];
	public GameObject [] StartArray = new GameObject[2];
	public GameObject player1GO;
	public GameObject player2GO;
	public GameObject player3GO;
	public GameObject player4GO;
	private int startIndex;
	public GameObject P1Camera;
	public GameObject P2Camera;
	public GameObject P3Camera;
	public GameObject P4Camera;
	public GameObject pauseMenuGUI;
	int size;
	int size2;
	public bool isPaused;
	public GameObject [] pausedArray = new GameObject[2];

	public bool onCharacter = false;

	private bool p1Ready = false;
	private bool p2Ready = true;
	private bool p3Ready = true;
	private bool p4Ready = true;
	
	public bool onFirstLoad = false;
	private bool runLevelCode;
	private Transform finishLine;

	//race Code 
	public List<GameObject> cars;
	private bool p1Finished;
	private bool p2Finished;
	private bool p3Finished;
	private bool p4Finished;

	// Use this for initialization
	void Start () 
	{
		
		size = CharacterArray.Length;
		size2 = StartArray.Length;
		DontDestroyOnLoad(this.gameObject);
		if (NumberOfPlayers >= 2)
		{
			player2 = 1;
			p2Ready = false;
		}
		if (NumberOfPlayers >=3)
		{
			player3 = 2;
			p3Ready = false;
		}
		if (NumberOfPlayers >= 4)
		{
			p4Ready = false;
			player4 = 3;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{	

		if(Application.loadedLevelName == "StartMenu")
		{
			if(player1GO != null) 
				p1Ready = player1GO.GetComponent<StartController> ().ready;
			if(player2GO != null)
				p2Ready = player2GO.GetComponent<StartController> ().ready;
			if(player3GO != null)
				p3Ready = player3GO.GetComponent<StartController> ().ready;
			if(player4GO != null)
				p4Ready = player4GO.GetComponent<StartController> ().ready;
			CharacterArray [player1].GetComponent<UIButton> ().trueHover ();
			if (NumberOfPlayers >=2)
				CharacterArray [player2].GetComponent<UIButton> ().trueHover ();
			if (NumberOfPlayers >=3)
				CharacterArray [player3].GetComponent<UIButton> ().trueHover ();
			if (NumberOfPlayers >=4)
				CharacterArray [player4].GetComponent<UIButton> ().trueHover ();
			StartArray[startIndex].GetComponent<UIButton>().trueHover();
			Debug.Log (p1Ready && p2Ready && p3Ready && p4Ready);
	
			P1Camera.transform.position = ShipArray [player1].transform.position - Vector3.forward;
			if (P2Camera != null && player2 != 100)
				P2Camera.transform.position = ShipArray [player2].transform.position - Vector3.forward;
			
			if(p1Ready && p2Ready && p3Ready && p4Ready)
			{
				Application.LoadLevel("loadingScreen");
			}
		}

		else if (onFirstLoad)
		{
			if (isPaused)
			{
				Time.timeScale = 0;
				//pauseMenuGUI.SetActive(true);
				GameObject.FindGameObjectWithTag("pauseMenu").SetActive (true);
				
			}
			//starting up a level
			cars.Sort(Compare);
			if(player1GO.GetComponent<PlayerController>().finishedTheRace && player2GO.GetComponent<PlayerController>().finishedTheRace)
				Application.LoadLevel("finishLevel");
		}
	}

	IEnumerator Sort()
	{
		while(true)
		{
			cars.Sort(Compare);
			yield return null;
		}
	}

	void OnLevelWasLoaded(int level) 
	{
		if(level == 2)
		{
			onFirstLoad = true;
			cars = GameObject.FindGameObjectsWithTag("Player").ToList();
			finishLine = GameObject.FindGameObjectWithTag("finishLine").transform;
			StartCoroutine (Sort ());
		}
	}

	int Compare(GameObject self, GameObject other)
	{
		return (Vector3.Distance(self.GetComponent<PlayerController>().transform.position,finishLine.position).CompareTo(
			Vector3.Distance(other.GetComponent<PlayerController>().transform.position,finishLine.position)));
	}

	public void changeIndex(StartController.PlayerNum player, int next)
	{

		if(onCharacter)
			switch(player)
			{
				case(StartController.PlayerNum.Player1):
					if(!p1Ready)
					{
						CharacterArray [player1].GetComponent<UIButton> ().falseHover ();
						player1 = ((player1+(next+2*size))%size);
					}
				break;
				case(StartController.PlayerNum.Player2):
					CharacterArray [player2].GetComponent<UIButton> ().falseHover ();
//					Debug.Break();
					player2 = ((player2+(next+2*size))%size);
				break;
				case(StartController.PlayerNum.Player3):
					CharacterArray [player3].GetComponent<UIButton> ().falseHover ();
					player3 = ((player3+(next+2*size))%size);
				break;
				case(StartController.PlayerNum.Player4):
					CharacterArray [player4].GetComponent<UIButton> ().falseHover ();
					player4 = ((player4+(next+2*size))%size);
				break;
			}
	}

	public void horizontalChange(int next)
	{
		if(!onCharacter && !onFirstLoad)
		{
				StartArray[startIndex].GetComponent<UIButton>().falseHover();
				startIndex = (startIndex + (next+2*size)) % size2;
		}
		else if(isPaused)
		{
			startIndex = ((startIndex+next) + 2) % 2;	
		}
	}

	public void handleA(StartController.PlayerNum num)
	{
		if(!onCharacter) //onStart Screen
		{
			StartArray[startIndex].GetComponent<UIButton>().callClick();
			if(startIndex != size2 - 1)
				onCharacter = true;
		}
		else if(onCharacter && !onFirstLoad)
			switch(num)
			{
				case(StartController.PlayerNum.Player1):
					if(player1 == size-1)
					{
						CharacterArray[player1].GetComponent<UIButton>().callClick(); 
						onCharacter = false;
					}
//					else
//						p1Ready = true;
					break;
				case(StartController.PlayerNum.Player2):
					Debug.Log(num);
					if(player2 == size-1)
						CharacterArray[player2].GetComponent<UIButton>().callClick();
//					else
//						p2Ready = true;
					break;
				case(StartController.PlayerNum.Player3):
					if(player3 == size-1)
						CharacterArray[player3].GetComponent<UIButton>().callClick();
//					else
//						p3Ready = true;
					break;
				case(StartController.PlayerNum.Player4):
					if(player4 == size-1)
						CharacterArray[player4].GetComponent<UIButton>().callClick();
//					else
//						p4Ready = true;
					break;
			}

	}
	
	public void handleA()
	{
		if(isPaused && onFirstLoad)
		{
			pausedArray[startIndex].GetComponent<UIButton>().callClick();
		}
	}

	public void setActive(StartController.PlayerNum num)
	{
		switch(num)
		{
			case(StartController.PlayerNum.Player1):
				break;
			case(StartController.PlayerNum.Player2):
				NumberOfPlayers +=1;
				p2Ready = false;
				player2 = 0;
				break;
			case(StartController.PlayerNum.Player3):
					NumberOfPlayers +=1;
					player3 = 0;
					p3Ready = false;
				break;
			case(StartController.PlayerNum.Player4):
					NumberOfPlayers +=1;
					player4 = 0;
					p4Ready = false;
				break;
		}	
	}

	void FixedUpdate()
	{
		int temp = 1;
		foreach(GameObject i in cars)
		{
			i.GetComponent<PlayerController>().place = temp.ToString()+(temp == 1 ? " st": temp == 2 ? " nd" : temp ==3 ? " rd":" th");
			temp +=1;
		}
	}
}

//public var wasPressed : boolean = false;
//var lockCursor:int;
public var playerOneGUI : GameObject;
 
function Start () {
 //Screen.lockCursor = true;
 Time.timeScale = 1;
 playerOneGUI.SetActive(false);
 //playerTwoGUI.SetActive(false);
// wasPressed = false;
 
}

function unPauseGame()
{
	Time.timeScale = 1;
	playerOneGUI.SetActive(false);
}
//onClickNotification();
 
function Update () {
 if(Input.GetKeyDown(KeyCode.Return)){
  //wasPressed = true;
  Time.timeScale = 0;
  Debug.Log("paused");
  //Screen.lockCursor = true;
  playerOneGUI.SetActive(true);
  //OnMouseOver();
  	}
}
  OnMouseOver();
function OnMouseOver () {
//		this.Time.timeScale = 1;
	}

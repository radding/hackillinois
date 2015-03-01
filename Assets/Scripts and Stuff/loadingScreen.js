#pragma strict
var nextLevelBtn : GameObject;
	//var percentageLoaded : float = 0;
var countDown : float = 10;

var CDx = 100;
var CDy =100;

var bigNumFive :GameObject;
var bigNumFour : GameObject;
var bigNumThree : GameObject;
var bigNumTwo : GameObject;
var bigNumOne : GameObject;
var bigLoadingPrompt : GameObject;


function Start() {
	nextLevelBtn.SetActive(false);
	OnMouseOver();
	
	bigNumFive.SetActive(false);
	bigNumFour.SetActive(false);
	bigNumThree.SetActive(false);
	bigNumTwo.SetActive(false);
	bigNumOne.SetActive(false);
	
}

//function OnGUI() {
	//GUI.Box(new Rect (CDx,CDy,50,20), "" + countDown.ToString("0"));
//}


	function Update() {
	countDown -= Time.deltaTime;

		if(Application.GetStreamProgressForLevel("firstLevel") == 1){
    nextLevelBtn.SetActive(true);
    Debug.Log("readyToBegin");
}

if (countDown > 6) {
	//countDown -= Time.deltaTime;
	bigLoadingPrompt.SetActive(true);
	bigNumFive.SetActive(false);
	bigNumFour.SetActive(false);
	bigNumThree.SetActive(false);
	bigNumTwo.SetActive(false);
	bigNumOne.SetActive(false);
}

if (countDown < 5 && countDown > 4) {
	//countDown -= Time.deltaTime;
	bigLoadingPrompt.SetActive(false);
	bigNumFive.SetActive(true);
	bigNumFour.SetActive(false);
	bigNumThree.SetActive(false);
	bigNumTwo.SetActive(false);
	bigNumOne.SetActive(false);
	

}
if(countDown < 4 && countDown >3) {
	//countDown -= Time.deltaTime;
	bigLoadingPrompt.SetActive(false);
	bigNumFive.SetActive(false);
	bigNumFour.SetActive(true);
	bigNumThree.SetActive(false);
	bigNumTwo.SetActive(false);
	bigNumOne.SetActive(false);

	}
if(countDown < 3 && countDown > 2) {
	//countDown -= Time.deltaTime;
	bigLoadingPrompt.SetActive(false);
	bigNumFive.SetActive(false);
	bigNumFour.SetActive(false);
	bigNumThree.SetActive(true);
	bigNumTwo.SetActive(false);
	bigNumOne.SetActive(false);
	}
if(countDown < 2 && countDown > 1) {
	//countDown -= Time.deltaTime;
	bigLoadingPrompt.SetActive(false);
	bigNumFive.SetActive(false);
	bigNumFour.SetActive(false);
	bigNumThree.SetActive(false);
	bigNumTwo.SetActive(true);
	bigNumOne.SetActive(false);
	}
if(countDown < 1 && countDown > 0) {
	//countDown -= Time.deltaTime;
	bigLoadingPrompt.SetActive(false);
	bigNumFive.SetActive(false);
	bigNumFour.SetActive(false);
	bigNumThree.SetActive(false);
	bigNumTwo.SetActive(false);
	bigNumOne.SetActive(true);
	}
	if (countDown <= 0)
		 Application.LoadLevel("firstLevel");
	}
	
function OnMouseDown() {
	 Application.LoadLevel("firstLevel");
}

function OnMouseOver() {
	//nextLevelBtn.animation.Stop();
	//nextLevelBtn.renderer.material.color.a = 1.0;
	Debug.Log("OverButton");
}
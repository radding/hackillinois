//A simple countdown timer
var myTimer : float = 60.0;
var isPlayerOneTimer = false;
var isPlayerTwoTimer = false; 
 
function Update () {
 if(myTimer > 0){
  myTimer -= Time.deltaTime;
 }
 if(myTimer <= 0){

 }
}

function OnGUI() {
if (isPlayerOneTimer == true)
{
GUI.Box(new Rect (10,10,50,20), "" + myTimer.ToString("0"));
}

if (isPlayerTwoTimer == true)
{
GUI.Box(new Rect (10,140,50,20), "" + myTimer.ToString("0"));
}
}
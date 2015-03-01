#pragma strict
//static var currentOption : GameObject;

//var player_two: GameObject;
 var firstOption = false;
 var firstOn = false;
 var secondOption = false;
  var thirdOption = false;
   var notOption = false;
//var spawnPoint = false;

var test : GameObject;


function Update() {
OnMouseUp();
}

 private function OnMouseUp() {
if (Input.GetButtonUp) {
// print ("up arrow key is held down");
if (firstOption == true){
displayFirstOption();
print ("stuff");
//if (Input.GetKey ("up"))
//displayFirstOption();
}
}
}


 function displayFirstOption () {
if(test.renderer.enabled == false) {
test.renderer.enabled = true;
}
else {
test.renderer.enabled = false;
}

}


/*function Start () {
if (spawnPoint == true) {
var spawnFirstOption: GameObject = Instantiate(spawnFirstOption, transform.position + Vector3(2,0,0), transform.rotation);
}
}

if (firstOption == true) {
var spawnTheFirstOption: GameObject = Instantiate(spawnFirstOption, transform.position + Vector3(0,0,0), transform.rotation);
}
if (secondOption == true) {
var spawnTheSecondOption: GameObject = Instantiate(spawnSecondOption, transform.position + Vector3(0,0,0), transform.rotation);
}
if (thirdOption == true) {
var spawnTheThirdOption: GameObject = Instantiate(spawnThirdOption, transform.position + Vector3(0,0,0), transform.rotation);
}
if (fourthOption == true) {
var spawnTheFourthOption: GameObject = Instantiate(spawnFourthOption, transform.position + Vector3(0,0,0), transform.rotation);
}

}

*/
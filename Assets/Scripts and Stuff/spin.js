#pragma strict

var rotationSpeed = 50;

function Update () {
this.transform.Rotate(Vector3(0,rotationSpeed,0) *Time.deltaTime);
}
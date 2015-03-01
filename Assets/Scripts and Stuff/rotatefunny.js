#pragma strict

function Update () {
this.transform.Rotate(Vector3(100,200,20) *Time.deltaTime);
}
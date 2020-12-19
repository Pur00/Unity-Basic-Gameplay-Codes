#pragma strict

var target : Transform;

function Update () {
	transform.position = target.position + Vector3 (3, 2.5, -10);
}
#pragma strict

var playerSpeed : int = 10;
var jumpHeight : int = 10;
var inAir : boolean = false;

function Update () {
/*	if (Input.GetAxis ("Jump") && inAir == false) {
		GetComponent.<Rigidbody>().velocity.y = jumpHeight;
		inAir = true;
	}
*/	if (transform.position.y < -10)
		transform.position = Vector3 (0, 2, 0);
}

function OnCollisionEnter () {
	inAir = false;
}
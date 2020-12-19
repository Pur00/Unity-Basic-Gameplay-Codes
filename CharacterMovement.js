#pragma strict

var characterSpeed : int = 10;
public var jumpHeight : int = 10;
var inAir : boolean = false;

function Update () {
	transform.position += Vector3 (Input.GetAxis ("Horizontal") * characterSpeed * Time.deltaTime, 0, 0);
	if (Input.GetAxis ("Horizontal") < 0) {
//		GetComponent.<Animation>().Play ("Turn_Left");
		transform.localScale.y = -10;
	}
	if (Input.GetAxis ("Horizontal") > 0) {
//		GetComponent.<Animation>().Play ("Turn_Right");
		transform.localScale.y = 10;
	}
	if (Input.GetAxis ("Jump") && inAir == false) {
		GetComponent.<Rigidbody>().velocity.y = jumpHeight;
		inAir = true;
	}
	if (transform.position.y < -10)
		transform.position = Vector3 (-11, 1, 0);
}

function OnCollisionEnter () {
	inAir = false;
}
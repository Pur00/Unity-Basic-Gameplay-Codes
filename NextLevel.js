#pragma strict

function OnCollisionEnter()	{
	Application.LoadLevel(Application.loadedLevel+1);
}
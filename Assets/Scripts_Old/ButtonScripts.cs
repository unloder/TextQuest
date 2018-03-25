using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour {


	public void OnStartClick(){
		Debug.Log ("Start button was pressed!");
		Debug.LogError ("You have lost THE GAME.");
	}

	public void OnQuitClick(){
		Debug.Log ("Quitting the game...");
	}

	public void OnQuitClickSecondary(){
		Debug.Log (".");
		Debug.Log (".");
		Debug.Log (".");
		Debug.LogError ("You can not quit THE GAME.");
	}
}

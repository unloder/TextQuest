using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatesLogic : MonoBehaviour {
	
	enum QuestStates { Intro, Room, Window, Door };
	QuestStates currentState;

	public Text titleText;

	// Use this for initialization
	void Start () {
		currentState = QuestStates.Window;
		print (currentState);
	}
	
	// Update is called once per frame
	void Update () {

		if (currentState == QuestStates.Intro) {
			IntroStateUpdate ();
		} else if (currentState == QuestStates.Door) {		
			DoorStateUpdate ();
		} else if (currentState == QuestStates.Room) {		
			RoomStateUpdate ();
		} else if (currentState == QuestStates.Window) {		
			WindowStateUpdate ();
		}
	}

	void IntroStateUpdate (){
		titleText.text = "Where am I?\nWho am I?";
		print (currentState);
	}

	void DoorStateUpdate (){
		titleText.text = "The door is locked...\n";
		print (currentState);
	}

	void RoomStateUpdate (){
		// TO CHANGE
		titleText.text = "The door is locked...\n";
		print (currentState);
	}

	void WindowStateUpdate (){
		// TO CHANGE
		titleText.text = "The door is locked...\n";
		print (currentState);
	}

}

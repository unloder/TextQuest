using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatesLogic : MonoBehaviour {
	
	enum QuestStates { 
		Intro,
		BriefingRoom,
		BriefingRoomMonitor,
		Hangar,
		NormalShip,
		FastShip,
		ArmoredShip,
		ShipConfirmScreen,
		Space };
	QuestStates currentState;
	QuestStates[] StateChangeChoices;
	QuestStates ShipSelected = QuestStates.Hangar;

	public Text titleText;
	public Text actionText;

	// Use this for initialization
	void Start () {
		currentState = QuestStates.Intro;
//		print (currentState);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentState == QuestStates.Intro) {
			IntroStateUpdate ();
		} else if (currentState == QuestStates.BriefingRoom) {		
			BriefingRoomStateUpdate ();
		} else if (currentState == QuestStates.BriefingRoomMonitor) {		
			BriefingRoomMonitorStateUpdate ();
		} else if (currentState == QuestStates.Hangar) {		
			HangarStateUpdate ();
		} else if (currentState == QuestStates.NormalShip) {		
			NormalShipStateUpdate ();
		} else if (currentState == QuestStates.FastShip) {		
			FastShipStateUpdate ();
		} else if (currentState == QuestStates.ArmoredShip) {		
			ArmoredShipStateUpdate ();
		} else if (currentState == QuestStates.ShipConfirmScreen) {		
			ShipConfirmScreenStateUpdate ();
		} else if (currentState == QuestStates.Space) {		
			SpaceStateUpdate ();
		}
	}
	void IntroStateUpdate (){
		titleText.text = "Gallaxy is in danger!\nYou are the only one who can save it!";
		StateChangeChoices = new QuestStates[]{QuestStates.BriefingRoom};
		actionText.text = "1 - Go to breifing room";
		ChoicesSelect ();
	}

	void BriefingRoomStateUpdate (){
		titleText.text = "Your mission is very dangerous!\nYou will probably die...";
		actionText.text = "1 - Go to breifing room.\n2 - Go to hangar.";
		StateChangeChoices = new QuestStates[]{
			QuestStates.BriefingRoomMonitor,
			QuestStates.Hangar,
		};
		ChoicesSelect ();
	}

	void BriefingRoomMonitorStateUpdate (){
		titleText.text = "Enemies are everywhere.\nYou can pilot one of our 3 remaining ships to battle.";
		actionText.text = "1 - Go to hangar.\n2 - Back to briefing room.";
		StateChangeChoices = new QuestStates[]{
			QuestStates.Hangar,
			QuestStates.BriefingRoom,
		};
		ChoicesSelect ();
	}

	void HangarStateUpdate (){
		ShipSelected = QuestStates.Hangar;
		titleText.text = "You see 3 ships in the hangar.";
		actionText.text = "1 - Approach Normal ship.\n2 - Approach Fast ship.\n3 - Approach Armored ship.\n4 - Back to Briefing room.";
		StateChangeChoices = new QuestStates[]{
			QuestStates.NormalShip,
			QuestStates.FastShip,
			QuestStates.ArmoredShip,
			QuestStates.BriefingRoom,
		};
		ChoicesSelect ();
	}

	void NormalShipStateUpdate (){
		titleText.text = "Normal Ship with normal stats.";
		actionText.text = "1 - Confirm ship " + ShipSelected + ".\n2-Back to hangar.";
		ShipSelected = QuestStates.NormalShip;
		StateChangeChoices = new QuestStates[]{
			QuestStates.ShipConfirmScreen,
			QuestStates.Hangar,
		};
		ChoicesSelect ();
	}

	void FastShipStateUpdate (){
		titleText.text = "Fast and agile ship with lower defences but greater speed.";
		actionText.text = "1 - Confirm ship " + ShipSelected + ".\n2-Back to hangar.";
		ShipSelected = QuestStates.FastShip;
		StateChangeChoices = new QuestStates[]{
			QuestStates.ShipConfirmScreen,
			QuestStates.Hangar,
		};
		ChoicesSelect ();
	}

	void ArmoredShipStateUpdate (){
		ShipSelected = QuestStates.FastShip;
		titleText.text = "High armored but slow ship. Better not pick this one, unless fighting lots of enemies.";
		actionText.text = "1 - Confirm ship " + ShipSelected + ".\n2-Back to hangar.";
		StateChangeChoices = new QuestStates[]{
			QuestStates.ShipConfirmScreen,
			QuestStates.Hangar,
		};
		ChoicesSelect ();
	}

	void ShipConfirmScreenStateUpdate (){
		titleText.text = "Are you shure about the choice of your ship?\nThis choice is important it could mean the difference between life and death.";
		actionText.text = "You have chosen: " + ShipSelected + "\n1 - Venture into space!\n2-Changed your mind, back to hangar.";
		StateChangeChoices = new QuestStates[]{
			QuestStates.Space,
			QuestStates.Hangar,
		};
		ChoicesSelect ();
	}

	void SpaceStateUpdate (){
		titleText.text = "You venture into open space.";
		actionText.text = "No choices yet, but you are in space.";
		StateChangeChoices = new QuestStates[]{};
		ChoicesSelect ();
	}

	void ChoicesSelect (){
		print ("Choices select");
		if (StateChangeChoices != null & StateChangeChoices.Length > 0) {
			print ("in if");
			if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1)) {
				print ("1 pressed");
				ChangeState (StateChangeChoices[0]);
			}
			if (StateChangeChoices.Length > 1) {
				if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2)) {
					print ("2 pressed");
					ChangeState (StateChangeChoices[1]);
				}
			}

			if (StateChangeChoices.Length > 2) {
				if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3)) {
					print ("3 pressed");
					ChangeState (StateChangeChoices[2]);
				}
			}

			if (StateChangeChoices.Length > 3) {
				if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4)) {
					print ("4 pressed");
					ChangeState (StateChangeChoices[4]);
				}
			}

		}
	}


	void ChangeState(QuestStates State){
		currentState = State;
		print ("State changed to: " + State);
		StateChangeChoices = null;
	}
}

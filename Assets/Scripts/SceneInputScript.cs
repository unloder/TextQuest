using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInputScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		print ("scene input update");
		if (Input.GetKeyDown(KeyCode.Escape)) {
			print ("escape pressed");
			SceneManager.LoadScene ("MainMenu");
		}
	}
}

using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 200, 200), "Super Stache Studios Presents: \n ExploZone: Beneath the Surface");

		GUI.Label (new Rect (250, 0, 200, 200), "Controls: \n WASD to move \n Left Click to charge grenade shot \n Health bar is jetpack");

		if(GUI.Button (new Rect(0,250,100,100), "Start!"))
		   Application.LoadLevel(2);
	}
}

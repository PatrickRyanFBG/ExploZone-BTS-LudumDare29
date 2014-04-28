using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.showCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label (new Rect (0, 0, 100, 100), "Game Over!~");

		if(GUI.Button (new Rect(0,100,100,100), "Again?"))
			Application.LoadLevel(2);
	}
}

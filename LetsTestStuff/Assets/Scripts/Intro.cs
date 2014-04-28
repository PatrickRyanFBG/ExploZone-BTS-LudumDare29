using UnityEngine;
using System.Collections;

public class Intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DestroyObject (this.gameObject, 5f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown (KeyCode.Space))
			DestroyObject(this.gameObject);

		if(Input.GetMouseButtonDown(0))
			DestroyObject(this.gameObject);

	}

	void OnDestroy(){
		Application.LoadLevel (1);
	}
}

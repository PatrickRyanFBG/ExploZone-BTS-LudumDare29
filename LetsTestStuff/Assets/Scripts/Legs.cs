using UnityEngine;
using System.Collections;

public class Legs : MonoBehaviour {
	void Update () {
		if(Input.GetKey (KeyCode.D)){
			transform.rotation = Quaternion.identity;
			GetComponent<Animator>().SetBool ("Running", true);
		}
		else if(Input.GetKey (KeyCode.A)){
			transform.rotation = Quaternion.Euler(0,180,0);
			GetComponent<Animator>().SetBool ("Running", true);
		}

		if(Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp(KeyCode.A)){
			GetComponent<Animator>().SetBool ("Running", false);
		}
	}
}

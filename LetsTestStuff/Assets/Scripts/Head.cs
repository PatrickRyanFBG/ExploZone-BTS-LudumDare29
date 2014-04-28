using UnityEngine;
using System.Collections;

public class Head : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if(transform.position.x <= mousePos.x){
			transform.rotation = Quaternion.identity;
		}
		else{
			transform.rotation = Quaternion.Euler(0,180,0);
		}

		if(renderer.bounds.max.y >= mousePos.y){
			GetComponent<Animator>().SetInteger ("Direction", 0);
		}
		else{
			GetComponent<Animator>().SetInteger ("Direction", 1);
		}
	}
}

using UnityEngine;
using System.Collections;

public class Smoke : MonoBehaviour {
	public float deathTime;
	
	// Use this for initialization
	void Start () {
		DestroyObject (this.gameObject, deathTime);
	}

	void Update(){
		rigidbody2D.gravityScale = Mathf.Lerp (-.05f, -.5f, .1f);
	}
}

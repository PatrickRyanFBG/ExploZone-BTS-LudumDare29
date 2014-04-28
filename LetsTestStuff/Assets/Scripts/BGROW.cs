using UnityEngine;
using System.Collections;

public class BGROW : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height)).y + 1){
			DestroyObject(this.gameObject);
		}
	}
}

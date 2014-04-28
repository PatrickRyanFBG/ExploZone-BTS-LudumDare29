using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
	public GameObject bgRow;

	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y > player.transform.position.y){
			transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
		}
	}
}

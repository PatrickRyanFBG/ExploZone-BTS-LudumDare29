using UnityEngine;
using System.Collections;

public class SkullShadow : MonoBehaviour {
	public float life, speed;
	// Use this for initialization
	void Start () {
		DestroyObject (this.gameObject, life);
	}

	// Update is called once per frame
	void Update () {
		rigidbody2D.gravityScale = speed;
	}
}

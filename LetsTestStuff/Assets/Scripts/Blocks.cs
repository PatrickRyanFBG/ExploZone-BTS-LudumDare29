using UnityEngine;
using System.Collections;

public class Blocks : MonoBehaviour {
	public Sprite[] colors;
	private int life = 5;
	// Use this for initialization
	void Start () {
		GetComponent<SpriteRenderer>().sprite = colors[Random.Range (0,colors.Length)];
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 min = Camera.main.ScreenToWorldPoint(Vector3.zero);
//		Vector3 max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height));
//
//		if(renderer.bounds.max.y < min.y)
//			DestroyObject(this.gameObject);
//
//		if(renderer.bounds.max.y > max.y)
//			DestroyObject(this.gameObject);

		if(life <= 0)
			DestroyObject(this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		life--;
	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.transform.name == "Ceiling")
			DestroyObject(this.gameObject);
	}
}

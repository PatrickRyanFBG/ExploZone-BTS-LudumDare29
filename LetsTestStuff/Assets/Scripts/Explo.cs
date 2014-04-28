using UnityEngine;
using System.Collections;

public class Explo : MonoBehaviour {
	
	private float spawnTime;
	// Use this for initialization
	void Start () {
		spawnTime = Time.time;
		rigidbody2D.gravityScale = -.125f;

		Physics2D.IgnoreLayerCollision (10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time - spawnTime >= 1){
			DestroyObject(this.gameObject);
		}
		
		if(Time.time - spawnTime >= .5f){
			rigidbody2D.gravityScale += Random.Range (-Time.deltaTime/2f, Time.deltaTime*2f);
			
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Blocks"){
			Vector3 exp = col.transform.position - transform.position;
			if(col.rigidbody2D)
				col.rigidbody2D.AddForce(new Vector2(exp.x,exp.y).normalized * 250);
		}
	}
}

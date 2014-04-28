using UnityEngine;
using System.Collections;

public class MovementCont : MonoBehaviour {

	public float speed;
	public float jumpSpeed;

	private float life = 100;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreLayerCollision (8, 9);
		Physics2D.IgnoreLayerCollision (8, 10);
	}
	
	// Update is called once per frame
	void Update () {
		if(life <= 0)
			Application.LoadLevel(3);

		if(life <= 10){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 1);
		}
		else if(life <= 20){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 2);
		}
		else if(life <= 30){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 3);
		}
		else if(life <= 40){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 4);
		}
		else if(life <= 50){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 5);
		}
		else if(life <= 60){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 6);
		}
		else if(life <= 70){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 7);
		}
		else if(life <= 80){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 8);
		}
		else if(life <= 90){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 9);
		}
		else if(life <= 100){
			GameObject.FindWithTag("Life").GetComponent<Animator>().SetInteger("Life" , 10);
		}

		if(Input.GetKey (KeyCode.D)){
			rigidbody2D.velocity = new Vector2 (Mathf.Lerp (rigidbody2D.velocity.x,1*speed,.5f), rigidbody2D.velocity.y);
			//rigidbody2D.velocity = new Vector2(speed,rigidbody2D.velocity.y);
		}
		else if(Input.GetKey (KeyCode.A)){
			rigidbody2D.velocity = new Vector2 (Mathf.Lerp (rigidbody2D.velocity.x,-1*speed,.5f), rigidbody2D.velocity.y);
			//rigidbody2D.velocity = new Vector2(-speed,rigidbody2D.velocity.y);
		}

		if (Input.GetKeyDown (KeyCode.W)) {
			StartCoroutine(jetThrust());
			rigidbody2D.velocity = new Vector2 (rigidbody2D.velocity.x, Mathf.Lerp(rigidbody2D.velocity.y, jumpSpeed, .8f));
		}

		if(!Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A)){
			rigidbody2D.velocity  = new Vector2 (Mathf.Lerp (rigidbody2D.velocity.x,0,.1f), rigidbody2D.velocity.y);
			//rigidbody2D.velocity = Vector2.zero;
		}
	}

	IEnumerator jetThrust(){
		GameObject.FindWithTag ("JetPack").GetComponent<Animator> ().SetBool ("Thrust", true);
		yield return new WaitForSeconds (.1f);
		GameObject.FindWithTag ("JetPack").GetComponent<Animator> ().SetBool ("Thrust", false);

	}

	void OnCollisionEnter2D(Collision2D col){
		if(col.transform.tag == "Diamond"){
			audio.PlayOneShot(audio.clip);
			life += 10;
			if(life > 100)
				life = 100;

			col.transform.GetComponent<Animator>().SetBool("Collected",true);
			col.transform.GetComponent<BoxCollider2D>().isTrigger = true;
			col.transform.rigidbody2D.gravityScale = -.8f;
			DestroyObject(col.transform.gameObject, .5f);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Skull")
			life -= 10;
	}
}

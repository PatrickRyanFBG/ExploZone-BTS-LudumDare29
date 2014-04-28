using UnityEngine;
using System.Collections;

public class Skull : MonoBehaviour {
	public GameObject shadow, death;

	private int frameCnt;
	private int frameToo;

	private int life = 90;

	private float damageTime;

	// Use this for initialization
	void Start () {
		frameToo = Random.Range (8, 12);
	}
	
	// Update is called once per frame
	void Update () {
		if(life <= 0)
			DestroyObject(this.gameObject);

		if(life <= 10){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 1);
		}
		else if(life <= 20){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 2);
		}
		else if(life <= 30){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 3);
		}
		else if(life <= 40){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 4);
		}
		else if(life <= 50){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 5);
		}
		else if(life <= 60){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 6);
		}
		else if(life <= 70){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 7);
		}
		else if(life <= 80){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 8);
		}
		else if(life <= 90){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 9);
		}
		else if(life <= 100){
			transform.GetChild (0).GetComponent<Animator>().SetInteger("Life" , 10);
		}


		frameCnt++;
		
		if(frameCnt == frameToo){
			frameToo = Random.Range (40,60);
			Instantiate(shadow,new Vector3(transform.position.x, transform.position.y + .10f, transform.position.z + 1), Quaternion.identity);
			frameCnt = 0;
		}

		GameObject player = GameObject.FindWithTag ("Player");
		Vector3 playPos = player.transform.position;

		transform.position = Vector3.Lerp (transform.position, playPos, .01f);

		if(transform.position.x >= playPos.x){
			transform.rotation = Quaternion.identity;
		}
		else{
			transform.rotation = Quaternion.Euler(0,180,0);
		}
		
		if(renderer.bounds.max.y <= playPos.y){
			GetComponent<Animator>().SetInteger ("UpDown", 0);
		}
		else{
			GetComponent<Animator>().SetInteger ("UpDown", 1);
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Player"){
			DestroyObject(this.gameObject);
		}
		else if(col.transform.tag == "Explo" && Time.time - damageTime > .05f){
			damageTime = Time.time;
			life -= 10;
		}
	}

	void OnDestroy(){
		Instantiate (death, transform.position, Quaternion.identity);
	}
}

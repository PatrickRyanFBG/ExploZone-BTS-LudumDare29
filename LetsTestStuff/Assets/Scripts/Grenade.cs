using UnityEngine;
using System.Collections;

public class Grenade : MonoBehaviour {

	public GameObject exploMNGR, smkLrg, smkSml;

	private float charge;
	private float spawnTime;
	private bool torqued = false;
	private int frameCnt;
	private int frameToo;

	void Start(){

		frameToo = Random.Range (5, 10);
		spawnTime = Time.time;
		Instantiate (smkLrg, transform.position, Quaternion.identity);
	}

	void Update(){
		frameCnt++;

		if(frameCnt == frameToo){
			frameToo = Random.Range (5, 10);
			StartCoroutine(smoke());
			frameCnt = 0;
		}

		if(!torqued && Time.time - spawnTime > .25f){
			torqued = true;
			rigidbody2D.AddTorque(5);
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		GameObject xlp = (GameObject)Instantiate (exploMNGR, transform.position, Quaternion.identity);
		xlp.GetComponent<ExplosionMNGR> ().SetCharge (charge);
		DestroyObject (this.gameObject);
	}

	void OnTriggerEnter2D(Collider2D col){
		if(col.transform.tag == "Skull"){
			
			GameObject xlp = (GameObject)Instantiate (exploMNGR, transform.position, Quaternion.identity);
			xlp.GetComponent<ExplosionMNGR> ().SetCharge (charge);
			DestroyObject (this.gameObject);
		}
	}

	IEnumerator smoke(){
		int smokes = Random.Range (1, 3);
		int smokeCount = 0;
		while(smokeCount < smokes){
			Instantiate (smkSml, new Vector3(transform.position.x + Random.Range (-(3f/8f), (3f/8f)), transform.position.y), Quaternion.identity);
			yield return new WaitForSeconds(.05f);
			smokeCount++;
		}
	}

	public void SetCharge(float chg){
		charge = chg;
	}
}

using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject grenade;
	public bool shooting = false;
	private float fireTime;
	private float charge = 1;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)  &&  Time.time - fireTime > 1){
			shooting = true;

			if(charge > 5){
				GameObject.FindWithTag("Firebar").GetComponent<Animator>().SetInteger ("Power",5);
			}
			else if(charge > 4){
				GameObject.FindWithTag("Firebar").GetComponent<Animator>().SetInteger ("Power",4);
			}
			else if(charge > 3){
				GameObject.FindWithTag("Firebar").GetComponent<Animator>().SetInteger ("Power",3);
			}
			else if(charge> 2){
				GameObject.FindWithTag("Firebar").GetComponent<Animator>().SetInteger ("Power",2);
			}
			else if(charge > 1){
				GameObject.FindWithTag("Firebar").GetComponent<Animator>().SetInteger ("Power",1);
			}



			if(charge < 5)
				charge += Time.deltaTime*3;
		}

		else if(Input.GetMouseButtonUp (0) && Time.time - fireTime > 1){
			audio.PlayOneShot(audio.clip);
			fireTime = Time.time;
			GameObject grn = (GameObject) Instantiate (grenade, transform.position, Quaternion.identity);
			GameObject.FindWithTag ("Torso").GetComponent<Torso>().Shoot();
			Vector3 firePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

			grn.rigidbody2D.AddForce(new Vector2(firePos.x, firePos.y).normalized * (100*charge));
			grn.GetComponent<Grenade>().SetCharge(charge);
			GameObject.FindWithTag("Firebar").GetComponent<Animator>().SetInteger ("Power",0);
			charge = 1;
			shooting = false;
		}
	}
}

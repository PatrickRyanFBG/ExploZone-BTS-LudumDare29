using UnityEngine;
using System.Collections;

public class Torso : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.tag == "Torso"){
			if(transform.parent.rigidbody2D.velocity.magnitude != 0 || transform.GetChild (0).GetComponent<Shooting>().shooting)
				GetComponent<Animator> ().SetBool("Moving", true);
			else
				GetComponent<Animator> ().SetBool("Moving", false);

		}

		Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		
		if(transform.position.x <= mousePos.x){
			transform.rotation = Quaternion.identity;
		}
		else{
			transform.rotation = Quaternion.Euler(0,180,0);
		}
	}

	public void Shoot(){
		StartCoroutine (ShootIEnum ());
	}
	
	private IEnumerator ShootIEnum(){
		GetComponent<Animator> ().SetBool ("Shoot", true);
		yield return new WaitForSeconds(.1f);
		GetComponent<Animator> ().SetBool ("Shoot", false);
	}
}

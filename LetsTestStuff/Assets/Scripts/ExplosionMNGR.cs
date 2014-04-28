using UnityEngine;
using System.Collections;

public class ExplosionMNGR : MonoBehaviour {

	public GameObject explo;

	private float charge = 1;
	// Use this for initialization
	void Start () {
		iTween.ShakePosition(Camera.main.gameObject, new Vector3(.15f*charge,.15f*charge), .18f*charge);
		StartCoroutine (exploZone (transform.position));
	}
	
	IEnumerator exploZone(Vector3 mPos){
		int count = 0;
		//print ((int)(charge*4));

		while (count < (int)(charge*3)){
			Instantiate(explo, new Vector3(mPos.x + Random.Range (-.15f*charge,.15f*charge), mPos.y + Random.Range (-.15f*charge,.15f*charge), 0), Quaternion.identity);
			
			count++;
			
			yield return new WaitForSeconds(.01f);
		}

		DestroyObject (this.gameObject);
	}

	public void SetCharge(float chg){
		charge = chg;
	}
}

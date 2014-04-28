using UnityEngine;
using System.Collections;

public class Row : MonoBehaviour {
	public GameObject[] sqrs;

	private int dCount, curD;
	private GameObject[] rowSqrs = new GameObject[10];
	// Use this for initialization
	void Start () {

		dCount = Random.Range (0, 4);

		for(int i = 0; i < rowSqrs.Length; i++){
			if(curD < dCount){
				int temp = Random.Range (0,2);

				if(temp == 0){
					curD++;
					rowSqrs[i] = (GameObject)Instantiate(sqrs[1], new Vector3( -4.5f+i, transform.position.y, 0), Quaternion.identity);
				}
				else{
					rowSqrs[i] = (GameObject)Instantiate(sqrs[0], new Vector3( -4.5f+i, transform.position.y, 0), Quaternion.identity);
				}
			}
			else{
				rowSqrs[i] = (GameObject)Instantiate(sqrs[0], new Vector3( -4.5f+i, transform.position.y, 0), Quaternion.identity);
			}
		}

		foreach(GameObject obj in rowSqrs)
			obj.transform.parent = this.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

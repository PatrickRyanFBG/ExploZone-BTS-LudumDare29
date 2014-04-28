using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {
	public GameObject skull, row, bg;

	private float t;
	private int count = 3;
	// Use this for initialization
	void Start () {
		t = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 min = Camera.main.ScreenToWorldPoint(Vector3.zero);
		Vector3 max = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height));

		if(Time.time - t > 8f){
		

			int leftRight = Random.Range(0,2);

			if(leftRight == 0){
				Instantiate(skull, new Vector3(min.x, Random.Range (min.y, max.y), -3), Quaternion.identity);
			}
			else{
				Instantiate(skull, new Vector3(max.x, Random.Range (min.y, max.y), -3), Quaternion.identity);
			}

			leftRight = Random.Range(0,2);
			
			if(leftRight == 0){
				Instantiate(skull, new Vector3(min.x, Random.Range (min.y, max.y), -3), Quaternion.identity);
			}
			else{
				Instantiate(skull, new Vector3(max.x, Random.Range (min.y, max.y), -3), Quaternion.identity);
			}

			t = Time.time;
		}

		if(GameObject.Find ("Background").transform.childCount < 8){
			GameObject back = (GameObject) Instantiate(bg, new Vector3(0,GameObject.Find ("Last").transform.position.y - 1, 10), Quaternion.identity);
			GameObject.Find ("Last").transform.name = "bgRow";
			back.transform.name = "Last";
			back.transform.parent = GameObject.Find ("Background").transform;
			if(count == 3){
				count = 0;
				Instantiate(row, new Vector3(0,back.transform.position.y, 10), Quaternion.identity);
			}

			count++;
		}
	}
}

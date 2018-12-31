using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float distance_x=1f;
	public float distance_y=1f;
	public float alignment=0.5f;
	public GameObject barrackPrefab;
	public GameObject housePrefab;
	public GameObject barrackFill;
	public GameObject houseFill;
	private GameObject usingPrefab;
	private GameObject clonePrefab;
	private int fillNo=-1;
	public int unitID;

	void Start () {
		usingPrefab = null;
	}

	void FixedUpdate () {
		if (usingPrefab != null) {
			usingPrefab.transform.position = FollowMouse ();
			if (Input.GetMouseButtonDown(0) && usingPrefab.GetComponent<AreaControl>().Pass()){
				if(fillNo==0)
					Instantiate (barrackFill,usingPrefab.transform.position,usingPrefab.transform.rotation);
				if(fillNo==1)
					Instantiate (houseFill,usingPrefab.transform.position,usingPrefab.transform.rotation);
				clonePrefab = usingPrefab;
				usingPrefab=null;
				Destroy (clonePrefab);
			}
		}
	}

	public void BuildBarrack(){
		if (usingPrefab != null) {
			clonePrefab = usingPrefab;
			usingPrefab=null;
			Destroy (clonePrefab);
		}
		fillNo = 0;
		usingPrefab = Instantiate (barrackPrefab,Camera.main.ScreenToWorldPoint (Input.mousePosition+new Vector3(0,0,0)),transform.rotation) as GameObject;
	}
	public void BuildHouse(){
		if (usingPrefab != null) {
			clonePrefab = usingPrefab;
			usingPrefab=null;
			Destroy (clonePrefab);
		}
		fillNo = 1;
		usingPrefab = Instantiate (housePrefab,Camera.main.ScreenToWorldPoint (Input.mousePosition+new Vector3(0,0,0)),transform.rotation) as GameObject;
	}

	public void CreateUnit(){
		if (usingPrefab != null) {
			clonePrefab = usingPrefab;
			usingPrefab=null;
			Destroy (clonePrefab);
			usingPrefab=null;
		}
	}

	public Vector3 FollowMouse(){
		Vector3 clickPos = -Vector3.one;

		clickPos = Camera.main.ScreenToWorldPoint (Input.mousePosition+new Vector3(0,0,0));


		float xdif=clickPos.x % (distance_x);
		float ydif=clickPos.y % (distance_y);

		int cx = Mathf.RoundToInt(clickPos.x);
		int cy = Mathf.RoundToInt(clickPos.y);

		if(cx<clickPos.x){
			clickPos.x = cx + alignment;
		}
		else
		{
			clickPos.x = cx - alignment;
		}

		if(cy<clickPos.y){
			clickPos.y = cy + alignment;
		}
		else
		{
			clickPos.y = cy - alignment;
		}
		clickPos.z = 0.0f;

		return clickPos;
	}
}

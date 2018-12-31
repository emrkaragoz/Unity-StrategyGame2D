using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
	private Transform tr;
	private Platform pf;
	public float speed=5f;
	private int id;
	// Use this for initialization
	void Start () {
		tr = GetComponent<Transform> ();
		pf = GameObject.FindGameObjectWithTag ("Platform").GetComponent<Platform> ();
		id = GameObject.FindGameObjectsWithTag ("SoldierUnit").Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(id==pf.unitID){
			if(Input.GetMouseButtonDown(1)){
				Vector2 target = Camera.main.ScreenToWorldPoint (Input.mousePosition+new Vector3(0,0,0));
				transform.position = target;
				//findPath (target);
			}
		}
		
	}
	void OnMouseDown () {
		tr.localScale = new Vector3 (0.6f,0.6f,0f);
		GetComponent<SpriteRenderer> ().color = Color.yellow;
		pf.unitID=id;

	}
	void OnMouseExit () {
		tr.localScale = new Vector3 (0.5f,0.5f,0f);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}
	/*private void findPath(Vector3 _to){
		Vector3 _from = transform.position;
		float[,] tilesmap = new float[1, 1];
		PathFind.Grid grid = new PathFind.Grid(1, 1, tilesmap);
		List<PathFind.Point> path = PathFind.Pathfinding.FindPath(grid, _from, _to);
		Debug.Log ("Paths"+path);

	}*/
}

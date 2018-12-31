using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Barrack : MonoBehaviour {
	
	private Slider unitSlider;
	private GameObject barrackInfo;
	private GameObject unitButton;
	private GameObject[] slots;
	private GameObject[] slotID;
	public GameObject unitPrefabs;
	public Transform spawnTransform;
	private Transform tr;
	public int unit_count=0;
	private float sliderv=0;
	public float train_time=0.1f;
	private int id;

	void Start () {
		slots = GameObject.FindGameObjectsWithTag ("UnitSlots");
		barrackInfo = GameObject.FindGameObjectWithTag ("BarrackUI");
		unitButton = GameObject.FindGameObjectWithTag ("UnitUI");
		unitSlider = GameObject.FindGameObjectWithTag ("UnitSlider").GetComponent<Slider>();

		tr = GetComponent<Transform> ();
		id = GameObject.FindGameObjectsWithTag ("Barrack").Length;
	}
	
	// Update is called once per frame
	void FixedUpdate(){
		if (unitButton.GetComponent<UIScript>().barrackID==id) {
			barrackInfo.GetComponentInChildren<Text> ().text = "Barrack " + id.ToString ();
			if (unit_count == 0) {
				for (int i = 1; i < slots.Length + 1; i++) {
					FixedSlot (i - 1).GetComponent<Image> ().enabled = false;
				}
			} else {
				if (unit_count > 10)
					unit_count = 10;
				for (int i = 1; i < slots.Length + 1; i++) {
					if (i <= unit_count)
						FixedSlot (i - 1).GetComponent<Image> ().enabled = true;
					else
						FixedSlot (i - 1).GetComponent<Image> ().enabled = false;
				}
			}
		}
			
	}
	void OnMouseDown () {
		tr.localScale = new Vector3 (3.5f,3.5f,0f);
		GetComponent<SpriteRenderer> ().color = Color.yellow;
		unitButton.SetActive (true);
		unitButton.GetComponent<UIScript>().barrackID=id;

	}
	void OnMouseExit () {
		tr.localScale = new Vector3 (3.0f,3.0f,0f);
		GetComponent<SpriteRenderer> ().color = Color.white;
	}

	private GameObject FixedSlot(int index){
		GameObject slot=null;

		foreach (GameObject s in slots) {
			if (s.name.Equals (index.ToString ())) {
					slot = s;
				}
		}

		return slot;
	}

	public void spawnUnit(){
		if (unit_count < 0)
			return;
		sliderv = 0;
		StartCoroutine (training(train_time));
	}

	IEnumerator training(float time)
	{
		yield return new WaitForSeconds(time);
		sliderv += 0.25f;
		unitSlider.value = sliderv;

		if (sliderv < 1 && unit_count > 0 )
			StartCoroutine (training (train_time));
		else if (unit_count > 0){
			Instantiate (unitPrefabs, spawnTransform.position, spawnTransform.rotation);
			sliderv = 0;
			unitSlider.value = 0;
			unit_count--;
		}
	}

}

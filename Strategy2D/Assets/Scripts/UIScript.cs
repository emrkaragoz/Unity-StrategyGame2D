using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {
	public int barrackID=-1;
	public Platform platformScript;

    public void BuildClick(){
		platformScript.BuildBarrack();
	}
	public void HouseClick(){
		platformScript.BuildHouse();
	}

	public void UnitClick(){
		Barrack barrack = GameObject.FindGameObjectsWithTag ("Barrack") [barrackID - 1].GetComponent<Barrack> ();
		barrack.unit_count++;
		barrack.spawnUnit ();
	}
}

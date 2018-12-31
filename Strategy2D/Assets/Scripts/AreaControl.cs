using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaControl : MonoBehaviour {
	private bool pass=false;
	private SpriteRenderer[] areaSlots;

	public bool Pass(){
		pass = true;
		areaSlots = GetComponentsInChildren<SpriteRenderer>();
		foreach (SpriteRenderer s in areaSlots) {
			if(s.color==Color.red){
				pass = false;
			}
		}
		return pass;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Area : MonoBehaviour {
	protected SpriteRenderer spriteRenderer;
	private Color startColor = Color.green;
	private Color green;
	private Color red;
	public bool clear=false;
	void Start () {
		green = Color.green;
		red   = Color.red;
		//green.a = 0.5f;
		//red.a   = 0.5f;
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = startColor;
	}

	void OnTriggerEnter2D(Collider2D co){
			clear = false;
			spriteRenderer.color = red;

	}
	void OnTriggerStay2D(Collider2D co){
			clear = false;
			spriteRenderer.color = red;

	}
	void OnTriggerExit2D(Collider2D co){
			clear = true;
			spriteRenderer.color = green;
	}
}

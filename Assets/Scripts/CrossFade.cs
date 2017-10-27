using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossFade : MonoBehaviour {

	// Use this for initialization
	public float speed;
	public GameObject start_canvas;
	CanvasGroup canvasGroup;

	void Start () {
		canvasGroup = start_canvas.GetComponent<CanvasGroup> ();
		canvasGroup.alpha = 0.0f;
		StartCoroutine (anim ());
		
	}

	IEnumerator anim(){
		canvasGroup.alpha = 0.0f;
		while (canvasGroup.alpha<1) {
			canvasGroup.alpha += 0.02f;
			yield return new WaitForSeconds (0.01f);
		}
	}

	public void animCanvas(){
		StartCoroutine (anim ());
	}
	
	// Update is called once per frame
	void Update () {
		/*
		speed+=Time.deltaTime;
		//print (speed);
		while (canvasGroup.alpha < 1.0f) {
			canvasGroup.alpha+= 0.000001f ;
			print (canvasGroup.alpha);
		}
*/
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbsRotation : MonoBehaviour {
	private float speed;

	// Use this for initialization
	void Start () {
		//this.gameObject.transform.Rotate (Vector3.right * Time.deltaTime*speed);
		speed=10;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Rotate (Vector3.right * Time.deltaTime*speed);
	}
}

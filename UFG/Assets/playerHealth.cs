	using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float health = 0f;
	public GameObject healthbar;

	// Use this for initialization
	void Start () {

		health = max_Health;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void hurt(){
		//make calculations for taking damage in here.

		//gives us a number between 0 - 1 so that we can use it to transform the shape of the healthbar.

		float healthtransform = health / max_Health;

	}

	public void health_bar(float MH){

		healthbar.transform.localScale = new Vector3 (MH, healthbar.transform.localScale.y, healthbar.transform.localScale.z);

	}
}


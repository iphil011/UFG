using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s : MonoBehaviour {

	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel (1);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dummyHit : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack1") { 
            Vector3 up = new Vector2(0.5f, 0.5f);
            transform.position += up;
        }
        if (collision.gameObject.tag == "Attack2")
        {
            Vector3 up = new Vector2(0.2f, 0.2f);
            transform.position += up;
        }
        if (collision.gameObject.tag == "Attack3")
        {
            Vector3 up = new Vector2(1.5f, 1.5f);
            transform.position += up;
        }

    }
}

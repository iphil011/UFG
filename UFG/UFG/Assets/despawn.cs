using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class despawn : MonoBehaviour
{

    // Use this for initialization
    IEnumerator Start()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy();
    }

    // Update is called once per frame
    void Destroy()
    {
        Destroy(gameObject);
    }
}
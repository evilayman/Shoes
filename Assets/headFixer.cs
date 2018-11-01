using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class headFixer : MonoBehaviour {
    public Camera head;
    public GameObject cameraRig;
	// Use this for initialization
	IEnumerator Start () {
        yield return null;

        Fix();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        // Fix();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fix();
        }
    }
    void Fix()
    {
       // head.transform.parent = this.transform.parent;
        cameraRig.transform.position = cameraRig.transform.position + this.transform.position - head.transform.position;


      //  head.transform.parent = cameraRig.transform;
    }
    
}

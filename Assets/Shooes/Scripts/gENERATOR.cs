using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gENERATOR : MonoBehaviour {
    public GameObject red;
    public GameObject green;
	// Use this for initialization
	void Start () {
        StartCoroutine(Generate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public float time = 2;
    IEnumerator Generate()
    {
        yield return null;
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(red, this.transform.position,Quaternion.identity);
                yield return new WaitForSeconds(time);
                Instantiate(green, this.transform.position,Quaternion.identity);
                yield return new WaitForSeconds(time);

            }
            time /= 1.5f;
            if (time < .3f) time = .3f;
        }
    }
}

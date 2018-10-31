using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public enum type
{
    red,blue
}
public class Craftable : MonoBehaviour {
    public type t;
    [SerializeField]
    private Rigidbody body;
	// Use this for initialization
	void Start () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Craftable"))
        {
            var other=collision.collider.GetComponent<Craftable>();
            if (other.t != t)
            {
                if (t == type.red)
                {
                    other.Combine(this);
                    GameObject.Destroy(this);

                }

            }
            else
            {
                /// TODO Play error
            }
        }
    }
    public void Combine(Craftable other)
    {
        GameObject.Destroy(this.GetComponent<Throwable>());
        GameObject.Destroy(this);
        GameObject.Destroy(body);
        this.transform.parent = other.transform;
    }

}

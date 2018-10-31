using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvayerBelt : MonoBehaviour {
    private List<Transform> hamada;
    public Vector3 beltSpeed;
    public float textureScrollSpeed;
    private Material mat;
	// Use this for initialization
	void Start () {
        hamada = new List<Transform>();
        mat = this.GetComponent<MeshRenderer>().material;
        t = 0;
    }
    float t;
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < hamada.Count; i++)
        {
            hamada[i].GetComponent<Rigidbody>().velocity=(beltSpeed);
        }
        mat.SetTextureOffset("_MainTex", new Vector2(0, t));
        t += textureScrollSpeed * Time.deltaTime;
	}
    private void OnCollisionEnter(Collision collision)
    {
        hamada.Add(collision.collider.transform);
    }

    private void OnCollisionExit(Collision collision)
    {
        try
        {
            hamada.Remove(collision.collider.transform);
        }
        catch
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampScript : MonoBehaviour
{
    [SerializeField]
    private GameObject SignPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stampable")
        {
            Stamp();
        }
    }

    private void Stamp()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit))
        {
            if(hit.collider.tag == "Stampable")
            {
                GameObject GO = Instantiate(SignPrefab, hit.point, Quaternion.identity, hit.transform);
                GO.transform.forward = hit.normal * -1;
            }
            
        }


    }




}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetInteraction : MonoBehaviour
{
    public GameObject Magnet;
    public float attractionForce = 10;
    public float maxDistance = 10;
    float actualDistance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        actualDistance = Vector3.Distance(Magnet.transform.position, transform.position);
        if (actualDistance <= maxDistance)
        {
            GetComponent<Rigidbody>().AddForce((Magnet.transform.position - transform.position) * attractionForce * Time.deltaTime);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1 : le clou detecte a quelle profondeur il peut se planter.
/// 2 : Le clou se plante plus ou moins profondément en fonction d'une var entre 0 et 1. 
/// </summary>
public class InteractiveNail : MonoBehaviour
{

    [Range(0.01f, 0.9f)] public float hammerredRatio01;
    [Range(0.01f, 0.15f)] public float nailLength;
    Vector3 originalPosition;
    Vector3 fullyHammeredPosition;
    const float SURFACE_ROUGHNESS = 1;
    // Start is called before the first frame update
    
    
    void Start()
    {
        originalPosition = transform.position;
        DetectSurface();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(originalPosition, fullyHammeredPosition, hammerredRatio01);
    }


    public void ApplyHammerForce(Vector3 force)
    {
        // changer de référentiel pour passer dans celui du clou

        Vector3 localForce = transform.InverseTransformDirection(force);

        float effectiveForce = localForce.y;
        Debug.Log($"<color=#5555FF> Effective force = {effectiveForce}</color>");

        hammerredRatio01 += Mathf.Abs( effectiveForce / SURFACE_ROUGHNESS);
        hammerredRatio01 = Mathf.Clamp01(hammerredRatio01);
    }
    void DetectSurface()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, nailLength))
        {
            fullyHammeredPosition = hit.point;
        }
        else
        {
            fullyHammeredPosition = transform.position - transform.up * nailLength;
            Debug.Log($"Nail{gameObject.name}SONNOM couldn't detect a surface, make sure it isn't floating in the air");
        }
    }

    //afficher la longueur du clou

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, - transform.up * nailLength);
    }
}

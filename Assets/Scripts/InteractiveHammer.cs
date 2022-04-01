using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 1 detecter sa vitesse
/// 2 Calculer une force
/// 3 Transmettre au clou quand on le touche
/// </summary>
public class InteractiveHammer : MonoBehaviour
{
    public Transform hammerHead;
    Vector3 lastPosition;
    Vector3 currentSpeed;
    new Rigidbody rigidbody;

    Vector3 HammerForce { get =>  0.5f * rigidbody.mass * currentSpeed * currentSpeed.magnitude;}

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ComputeSpeed();
        lastPosition = transform.position;
    }

    void ComputeSpeed()
    {
        // la vitesse est égale (position actuelle - position précédente)/temps
        currentSpeed = (transform.position - lastPosition) / Time.deltaTime;
    }

    void OnCollisionEnter(Collision collision)
    {
        InteractiveNail hitNail = collision.transform.GetComponent<InteractiveNail>();
        if (hitNail != null)
            hitNail.ApplyHammerForce(HammerForce);

        //Sucre syntaxique alternatif : 
        //collision.other.GetComponent<InterractiveNail>()?.ApplyHammerForce(HammerForce);

        //collision.other.SendMessage("ApplyHammerForce",HammerForce, SendMessageOptions.DontRequireReceiver);
    }

}

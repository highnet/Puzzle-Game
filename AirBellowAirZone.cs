using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBellowAirZone : MonoBehaviour
{

    public AirBellow airBellow;
    private BoxCollider boxCollider;
    public ParticleSystem wind;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
    }


    public void BlowAir()
    {
       Collider[] colliders =  Physics.OverlapBox(this.transform.position, boxCollider.size / 2);
    
        for(int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Balloon")
            {
                colliders[i].attachedRigidbody.AddForce(airBellow.blowDirection * airBellow.blowStrength);
            }
        }

        var windEmission = wind.emission;
        wind.Emit(5);
    }
}


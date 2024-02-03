using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBreakController : MonoBehaviour
{
    
    public void Boom()
    {

        var rigids = GetComponentsInChildren<Rigidbody>();

        foreach(var rigid in rigids)
        {

            rigid.AddExplosionForce(0.5f, transform.position, 3);

        }

    }

}

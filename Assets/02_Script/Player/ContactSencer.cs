using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactSencer : MonoBehaviour
{

    private Rigidbody rigid;

    public bool IsContacted { get; private set; }

    public event Action<float> OnContacted;

    private float fallingTime;

    private void Awake()
    {
        
        rigid = GetComponentInParent<Rigidbody>();

    }

    private void Update()
    {
        
        if(IsContacted == false)
        {

            fallingTime += Time.deltaTime;

        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        OnContacted?.Invoke(fallingTime);

        if (rigid.velocity.y > -0.1f)
        {

            fallingTime = 0;

        }


        IsContacted = true;

    }

    private void OnCollisionStay(Collision collision)
    {

        if (rigid.velocity.y > -0.1f)
        {

            fallingTime = 0;

        }

        IsContacted = true;

    }

    private void OnCollisionExit(Collision collision)
    {


        IsContacted = false;

    }



}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactSencer : MonoBehaviour
{

    public bool IsContacted { get; private set; }

    public event Action<float> OnContacted;

    private float fallingTime;

    private void Update()
    {
        
        if(IsContacted == false)
        {

            fallingTime += Time.deltaTime;

        }

    }

    private void OnTriggerEnter(Collider other)
    {

        OnContacted?.Invoke(fallingTime);

        fallingTime = 0;

        IsContacted = true;

    }

    private void OnTriggerStay(Collider other)
    {

        IsContacted = true;

    }

    private void OnTriggerExit(Collider other)
    {

        IsContacted = false;

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDownSencer : MonoBehaviour
{

    [SerializeField] private float overPower;
    [SerializeField] private PlayerBreakController breakController;

    private Rigidbody rigid;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody>();
        GetComponent<ContactSencer>().OnContacted += HandleContacted;

    }

    private void HandleContacted(float fallingTime)
    {

        var power = (Mathf.Abs(rigid.velocity.x) + Mathf.Abs(rigid.velocity.y * 5) + Mathf.Abs(rigid.velocity.z));

        if(power > overPower)
        {

            Destroy(gameObject);
            Instantiate(breakController, transform.position + new Vector3(0, 0.3f), Quaternion.identity);
            breakController.Boom();

        }

    }

}

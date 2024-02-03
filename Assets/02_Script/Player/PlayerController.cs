using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveSpeed;

    private Rigidbody rigid;
    private ContactSencer sencer;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody>();
        sencer = GetComponent<ContactSencer>();

    }

    private void Update()
    {

        Move();

    }

    private void Move()
    {

        var rot = Camera.main.transform.rotation;
        rot.x = 0;

        var inputDir = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxis("Horizontal")).normalized;
        var curDir = rot * inputDir;

        if (!sencer.IsContacted && inputDir != Vector3.zero)
        {

            rigid.AddForce(new Vector3(curDir.x / 2, 0, curDir.z / 2), ForceMode.Acceleration);
            return;

        }

        if (inputDir == Vector3.zero) return;


        rigid.AddTorque(curDir * moveSpeed, ForceMode.Acceleration);

    }

}

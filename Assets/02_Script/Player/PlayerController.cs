using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rigid;

    private void Awake()
    {
        
        rigid = GetComponent<Rigidbody>();

    }

    private void Update()
    {

        Move();

    }

    private void Move()
    {

        var dir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        var inputDir = dir.normalized;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{

    [SerializeField] private GameObject rotateObj;
    [SerializeField] private float rotateSpeed;

    private Vector3 rotateVec;

    private void Update()
    {
        
        Rotate();
        RePos();

    }

    private void Rotate()
    {

        var inputDir = new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"));

        rotateVec += inputDir * rotateSpeed * Time.deltaTime;

        rotateVec.x = Mathf.Clamp(rotateVec.x, -50, 50);

        rotateObj.transform.eulerAngles = rotateVec;

    }

    private void RePos()
    {

        var dir = transform.position - rotateObj.transform.position;

        dir.Normalize();

        if(Physics.Raycast(rotateObj.transform.position, dir, out var info, 2.25f))
        {

            transform.position = info.point;

        }
        else
        {

            transform.localPosition = new Vector3(0, 1, -2);

        }

    }

}

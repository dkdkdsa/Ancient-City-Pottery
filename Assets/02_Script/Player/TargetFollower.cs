using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{

    [SerializeField] private Transform target;

    private void Update()
    {
        
        if(target != null)
        {

            transform.position = target.position + new Vector3(0, 0.5f);

        }

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhysics : MonoBehaviour
{

    [SerializeField] private Transform maxUpPoint;

    private void OnTriggerEnter(Collider other)
    {

        other.attachedRigidbody.AddForce(Vector3.up / 5, ForceMode.VelocityChange);

    }

    private void OnTriggerStay(Collider other)
    {

        var dir = maxUpPoint.transform.position - other.transform.position;
        other.attachedRigidbody.AddForce(Vector3.up / 5, ForceMode.VelocityChange);

    }

}

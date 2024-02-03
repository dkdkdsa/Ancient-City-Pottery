using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakDownSencer : MonoBehaviour
{

    [SerializeField] private float overTime;
    [SerializeField] private PlayerBreakController breakController;

    private void Awake()
    {
        
        GetComponentInChildren<ContactSencer>().OnContacted += HandleContacted;

    }


    private void HandleContacted(float fallingTime)
    {

        Debug.Log(fallingTime);

        if (fallingTime == 0) return;

        if(fallingTime > overTime)
        {

            Destroy(gameObject);
            Instantiate(breakController, transform.position, Quaternion.identity).Boom();

            if(GameManager.Instance != null)
            {

                GameManager.Instance.OnPlayerDieEvent?.Invoke();

            }

        }

    }

}

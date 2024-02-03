using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LanguageDebugController : MonoBehaviour
{

    [SerializeField] private LanguageType debugView;

#if UNITY_EDITOR

    private void OnValidate()
    {

        var compo = FindObjectsOfType<LanguageByTMP>();

        foreach(var obj in compo)
        {

            obj.debugView = debugView;
            obj.SetText();

        }

    }

#endif

}

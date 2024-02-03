using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class LanguageByTMP : MonoBehaviour
{

    public LanguageType debugView;
    [SerializeField] private LanguageData data;

    private void Awake()
    {

        LanguageManager.OnLanguageChangeEvent += HandleLanguageChangedEvent;
        HandleLanguageChangedEvent();

    }

    private void HandleLanguageChangedEvent()
    {

        var text = GetComponent<TMP_Text>();
        text.text = data.Text;

    }

    private void OnDestroy()
    {

        LanguageManager.OnLanguageChangeEvent -= HandleLanguageChangedEvent;

    }

#if UNITY_EDITOR

    private void OnValidate()
    {

        SetText();

    }

    public void SetText()
    {

        var text = GetComponent<TMP_Text>();

        if (text != null && data != null && data[debugView] != null)
        {

            text.text = data[debugView];

        }

    }

#endif

}

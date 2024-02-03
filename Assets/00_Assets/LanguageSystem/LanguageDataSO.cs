using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LanguageType
{

    KOR = 0,
    ENG

}

public class LanguageDataSO : ScriptableObject
{

    [field:SerializeField] public LanguageType languageData { get; private set; }

    public void InitData()
    {

        int num = PlayerPrefs.GetInt("LanguageType", -1);

        if(num != -1)
        {

            languageData = (LanguageType)num;

        }


    }

    public void ChangeLanguage(LanguageType type)
    {

        languageData = type;

        PlayerPrefs.SetInt("LanguageType", (int)type);

    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LanguageManager
{

    private static LanguageDataSO so;

    public static event Action OnLanguageChangeEvent;

    public static LanguageType CurrentLanguageType 
    {

        get
        {

            return so.languageData;

        }

        set
        {

            so.ChangeLanguage(value);
            OnLanguageChangeEvent?.Invoke();

        }

    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {

        so = Resources.Load<LanguageDataSO>("Language/Data");
        so.InitData();

    }

}

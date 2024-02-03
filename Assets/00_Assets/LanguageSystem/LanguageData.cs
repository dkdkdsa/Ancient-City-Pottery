using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LanguageObject
{

    public LanguageType Type;
    
    [TextArea] public string Text;

}

[System.Serializable]
public class LanguageData
{

    [SerializeField] private List<LanguageObject> languageDatas;

    public string Text => this[LanguageManager.CurrentLanguageType];

    public string this[LanguageType type]
    {

        get
        {

            return languageDatas.Find(x => x.Type == type).Text;

        }

    }

}

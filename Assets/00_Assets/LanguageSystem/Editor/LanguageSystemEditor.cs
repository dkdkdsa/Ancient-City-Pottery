using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class LanguageSystemEditor
{


    [InitializeOnLoadMethod]
    public static void Init()
    {

        if(!Directory.Exists(Application.dataPath + "/Resources/Language"))
        {
            //
            Directory.CreateDirectory(Application.dataPath + "/Resources/Language");

            var data = ScriptableObject.CreateInstance<LanguageDataSO>();

            AssetDatabase.CreateAsset(data, "Assets/Resources/Language/Data.asset");
            EditorUtility.SetDirty(data);

            AssetDatabase.Refresh();

        }

    }

}

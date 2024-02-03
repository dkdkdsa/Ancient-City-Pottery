using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundInit : MonoBehaviour
{
    [SerializeField] private string bgmName;
    [SerializeField] private string btnName;

    void Start()
    {
        SoundManager.Play2DSound(bgmName, SoundType.BGM);
        InputButtonSfx();
    }

    private void InputButtonSfx()
    {
        foreach (Button allBtn in FindObjectsOfType<Button>())
        {
            allBtn.onClick.AddListener(() => { SoundManager.Play3DSound(btnName, allBtn.transform.position); });
        }
    }
}

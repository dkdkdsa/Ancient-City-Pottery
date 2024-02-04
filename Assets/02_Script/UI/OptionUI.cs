using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [Header("StartOption")]
    [SerializeField] private Image[] _sliderImg;
    [SerializeField] private Transform _option;
    [SerializeField] private Slider _bgmSlider, _sfxSlider;
    [Header("=================================================")]

    [SerializeField] private Transform[] _panel;


    [SerializeField] private TextMeshProUGUI _soundTex;
    [SerializeField] private TextMeshProUGUI _languageTex;

    [SerializeField] private float _dotTime;

    private void Start()
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("BGM", 1);
        _sfxSlider.value = PlayerPrefs.GetFloat("SFX", 1);

        _sfxSlider.onValueChanged.AddListener(HandleSfxValueChanged);
        _bgmSlider.onValueChanged.AddListener(HandleBGMValueChanged);


    }



    public void StartOption()
    {
        Sequence seq = DOTween.Sequence();
        CanvasGroup group = GetComponent<CanvasGroup>();
        group.blocksRaycasts = true;
        group.DOFade(1, 0.1f);
        CanvasGroup optionCanvas = _option.GetComponent<CanvasGroup>();

        for(int i = 0; i < _sliderImg.Length; i++)
        {
            seq.Append(_sliderImg[i].DOFade(1, 0.05f));
        }
        optionCanvas.DOFade(1, _dotTime);
    }

    #region Change Language

    [Header("LanguagePanel//Language//LanguageTex")]
    [SerializeField] private TextMeshProUGUI languageText;
    private LanguageType current;

    public void LanChPlus()
    {
        int c = (int)current + 1;

        if (c >= 2)
        {
            LanguageManager.CurrentLanguageType = LanguageType.KOR;
        }
        else
        {
            LanguageManager.CurrentLanguageType = LanguageType.ENG;
        }

        current = LanguageManager.CurrentLanguageType;

        SetLanguageText();
    }

    public void LanChM()
    {

        int c = (int)current - 1;

        if (c < 0)
        {
            LanguageManager.CurrentLanguageType = LanguageType.ENG;
        }
        else
        {
            LanguageManager.CurrentLanguageType = LanguageType.KOR;
        }

        current = LanguageManager.CurrentLanguageType;

        SetLanguageText();
    }

    private void SetLanguageText()
    {
        languageText.text = LanguageManager.CurrentLanguageType switch
        {
            LanguageType.KOR => "ÇÑ±¹¾î",
            LanguageType.ENG => "ENGLISH",
            _ => "Error!"
        };
    }

    #endregion

    #region VolumeControl

    private void HandleSfxValueChanged(float value)
    {

        PlayerPrefs.SetFloat("SFX", value);
        SoundManager.SetSFXVolume(value);

    }

    private void HandleBGMValueChanged(float value)
    {

        PlayerPrefs.SetFloat("BGM", value);
        SoundManager.SetBGMVolume(value);

    }


    #endregion

    private bool order;
    private bool canChange = true;

    public void LRBtn()
    {
        if (canChange)
        {
            canChange = false;

            order = !order;

            SettingTitle(order, 130);
        }
    }

    public void SettingTitle(bool value, float direction)
    {
        Sequence seq = DOTween.Sequence();

        CanvasGroup soundCanvas = _panel[0].GetComponent<CanvasGroup>();
        CanvasGroup languageCanvas = _panel[1].GetComponent<CanvasGroup>();

        if(value)
        {
            seq.AppendCallback(() =>
            {
                soundCanvas.blocksRaycasts = false;
                soundCanvas.DOFade(0, _dotTime);
            }).AppendInterval(_dotTime)
            .AppendCallback(() =>
            {
                languageCanvas.DOFade(1, _dotTime);
                languageCanvas.blocksRaycasts = true;
                canChange = true;
            });
        }
        else
        {
            seq.AppendCallback(() =>
            {
                languageCanvas.blocksRaycasts = false;
                languageCanvas.DOFade(0, _dotTime);
            }).AppendInterval(_dotTime)
            .AppendCallback(() =>
            {
                soundCanvas.DOFade(1, _dotTime);
                soundCanvas.blocksRaycasts = true;
                canChange = true;
            });
        }

    }

    public void GoToBack()
    {
        Sequence seq = DOTween.Sequence();
        CanvasGroup group = GetComponent<CanvasGroup>();
        group.blocksRaycasts = false;

        CanvasGroup optionCanvas = _option.GetComponent<CanvasGroup>();

        for (int i = 0; i < _sliderImg.Length; i++)
        {
            seq.Append(_sliderImg[i].DOFade(0, 0.05f));
        }
        optionCanvas.DOFade(0, _dotTime);
        group.DOFade(0, 0.5f);
    }
}

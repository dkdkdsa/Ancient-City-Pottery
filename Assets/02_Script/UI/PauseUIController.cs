using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUIController : MonoBehaviour
{

    [SerializeField] private Image bg;
    [SerializeField] private Transform panel, buttons;
    [SerializeField] private float _dotTime;
    [SerializeField] private OptionUI _option;

    public bool isControl = true;
    private bool isPaused;

    private Image[] _buttonImgs;
    private TextMeshProUGUI[] _texts;

    private void Awake()
    {
        _buttonImgs = buttons.GetComponentsInChildren<Image>();
        _texts = buttons.GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape) && isControl)
        {
            isControl = false;

            if (isPaused)
            {

                Time.timeScale = 1.0f;
                Release();

            }
            else
            {

                Time.timeScale = 0f;
                Control();

            }

            isPaused = !isPaused;

        }

    }
    
    private void Release()
    {
        Sequence seq = DOTween.Sequence();
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        for (int imgCnt = 0; imgCnt < _buttonImgs.Length; imgCnt++)
        {
            seq.Append(_buttonImgs[imgCnt].DOFade(0, _dotTime))
               .Join(_texts[imgCnt].DOFade(0, _dotTime))
               .Join(_texts[imgCnt].transform.DOLocalMoveX(150, _dotTime))
               .SetEase(Ease.OutSine).SetUpdate(true);
        }

        seq.AppendInterval(0.1f)
            .AppendCallback(() => canvasGroup.DOFade(0, _dotTime).SetUpdate(true))
            .Append(bg.DOFade(0, 0.1f))
            .AppendCallback(() => isControl = true).SetUpdate(true);
    }

    public void Control()
    {
        Sequence seq = DOTween.Sequence();
        CanvasGroup canvasGroup = panel.GetComponent<CanvasGroup>();

        seq.Append(bg.DOFade(0.7f, 0.1f))
            .AppendCallback(() =>
            {
                canvasGroup.DOFade(1, _dotTime).SetUpdate(true);
            }).SetUpdate(true);


        for (int imgCnt = 0; imgCnt < _buttonImgs.Length; imgCnt++)
        {
            seq.Append(_buttonImgs[imgCnt].DOFade(0.7f, _dotTime))
               .Join(_texts[imgCnt].DOFade(1, _dotTime))
               .Join(_texts[imgCnt].transform.DOLocalMoveX(210, _dotTime))
               .SetEase(Ease.OutSine).SetUpdate(true);
        }

        seq.AppendInterval(0.45f).AppendCallback(() => isControl = true).SetUpdate(true);
    }

    public void Continue()
    {
        Release();
        Time.timeScale = 1;

    }

    public void Restart()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => Release())
           .AppendInterval(1f)
           .AppendCallback(() =>
           {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
           }).SetUpdate(true);

    }

    public void Option()
    {
        Sequence seq = DOTween.Sequence();
        Release();
        seq.AppendInterval(0.5f)
            .AppendCallback(() => _option.StartOption()).SetUpdate(true);
    }

    public void Menu()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => Release())
           .AppendInterval(1f)
           .AppendCallback(() =>
           {
               SceneManager.LoadScene("IntroScene");
           }).SetUpdate(true);
    }

    private void OnDestroy()
    {

        Time.timeScale = 1;

    }

}

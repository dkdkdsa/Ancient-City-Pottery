using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroSceneUI : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform _button;
    [SerializeField] private Transform _works;
    [SerializeField] private Transform _title;
    [SerializeField] private OptionUI _option;
    [SerializeField] private Image _backPanel;

    [Header("Property")]
    [SerializeField] private float _dotweenTime;

    private Image[] _buttonImgs;
    private TextMeshProUGUI[] _texts;

    private void Awake()
    {
        _buttonImgs = _button.GetComponentsInChildren<Image>();
        _texts = _button.GetComponentsInChildren<TextMeshProUGUI>();

        Application.targetFrameRate = 144;

    }

    private void Start()
    {
        CanvasGroup titleCanvas = _title.GetComponent<CanvasGroup>();
        Sequence seq = DOTween.Sequence();

        seq.Append(titleCanvas.DOFade(1, 1f))
            .AppendInterval(0.5f)
        .AppendCallback(() => BtnFadeIn(_dotweenTime)).SetUpdate(true);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.J))
        {
            BtnFadeIn(_dotweenTime);
        }

        if (Input.GetKeyUp(KeyCode.K))
        {
            BtnFadeOut(_dotweenTime);
        }
    }

    public void BtnFadeIn(float time)
    {
        Sequence seq = DOTween.Sequence();

        for (int imgCnt = 0; imgCnt < _buttonImgs.Length; imgCnt++)
        {
            seq.Append(_buttonImgs[imgCnt].DOFade(0.7f, time))
               .Join(_texts[imgCnt].DOFade(1, time))
               .Join(_texts[imgCnt].transform.DOLocalMoveX(210, time))
               .SetEase(Ease.OutSine);
        }
    }

    public void BtnFadeOut(float time)
    {
        Sequence seq = DOTween.Sequence();

        for (int imgCnt = 0; imgCnt < _buttonImgs.Length; imgCnt++)
        {
            seq.Append(_buttonImgs[imgCnt].DOFade(0, time))
               .Join(_texts[imgCnt].DOFade(0, time))
               .Join(_texts[imgCnt].transform.DOLocalMoveX(150, time))
               .SetEase(Ease.OutSine);
        }
    }


    public void GameStart()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => BtnFadeOut(_dotweenTime))
           .AppendInterval(1f)
           .Append(_backPanel.DOFade(1f, 1f))
           .AppendCallback(() =>
           {
               SceneManager.LoadScene("LoadingScene");
           });
    }

    public void Option()
    {
        Sequence seq = DOTween.Sequence();
        BtnFadeOut(_dotweenTime);
        seq.AppendInterval(0.4f)
            .AppendCallback(() => _option.StartOption());
    }

    public void Works()
    {
        CanvasGroup titleCanvas = _title.GetComponent<CanvasGroup>();
        Sequence seq = DOTween.Sequence();

        BtnFadeOut(_dotweenTime);

        seq.Append(titleCanvas.DOFade(0, 0.3f))
            .AppendInterval(0.5f)
           .AppendCallback(() =>        
        WorksFade(true, 1, _dotweenTime));
    }

    public void GoToMenu()
    {
        CanvasGroup titleCanvas = _title.GetComponent<CanvasGroup>();
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() => WorksFade(false, 0, _dotweenTime)).
            Append(titleCanvas.DOFade(1, 0.7f))
            .AppendCallback(() => BtnFadeIn(_dotweenTime));
    }

    public void WorksFade(bool boolean, float value, float time)
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() =>
        {
            CanvasGroup canvasGroup = _works.GetComponent<CanvasGroup>();

            canvasGroup.blocksRaycasts = boolean;
            canvasGroup.DOFade(value, time);
        });
    }    

    public void Exit()
    {
        Sequence seq = DOTween.Sequence();

        seq.AppendCallback(() =>BtnFadeOut(_dotweenTime))
           .AppendInterval(1f)
           .AppendCallback(() =>
           {
               Debug.Log("EXIT!");
               Application.Quit();
           });
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroSceneUI : MonoBehaviour
{
    [Header("Transform")]
    [SerializeField] private Transform _button;
    [SerializeField] private Transform _works;

    [Header("Property")]
    [SerializeField] private float _dotweenTime;

    private Image[] _buttonImgs;
    private TextMeshProUGUI[] _texts;

    private void Awake()
    {
        _buttonImgs = _button.GetComponentsInChildren<Image>();
        _texts = _button.GetComponentsInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        BtnFadeIn(_dotweenTime);
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
           .AppendCallback(() =>
           {
               Debug.Log("SCENE MOVE!");
           });
    }

    public void Option()
    {

    }

    public void Works()
    {
        Sequence seq = DOTween.Sequence();

        BtnFadeOut(_dotweenTime);

        seq.AppendInterval(0.5f)
           .AppendCallback(() =>        
        WorksFade(true, 1, _dotweenTime));
    }

    public void GoToMenu()
    {
        WorksFade(false, 0, _dotweenTime);
        BtnFadeIn(_dotweenTime);
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

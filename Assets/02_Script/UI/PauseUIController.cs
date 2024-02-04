using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUIController : MonoBehaviour
{

    [SerializeField] private Image bg;
    [SerializeField] private Transform panel, buttons;

    private bool isControl;
    private bool isPaused;

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Escape) && !isControl)
        {

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
    /// <summary>
    /// 
    /// </summary>
    private void Release()
    {

        Sequence seq = DOTween.Sequence();

        seq.SetUpdate(true);
        seq.Append(bg.DOFade(0, 0.3f));
        seq.Join(panel.transform.DOLocalMoveX(-1460, 0.3f).SetEase(Ease.OutSine));
        seq.AppendInterval(0.05f);

        seq.Append(buttons.GetChild(0).DOLocalMoveX(-1300, 0.3f).SetEase(Ease.OutSine));
        seq.Insert(0.5f, buttons.GetChild(1).DOLocalMoveX(-1300, 0.3f).SetEase(Ease.OutSine));
        seq.Insert(0.6f, buttons.GetChild(2).DOLocalMoveX(-1300, 0.3f).SetEase(Ease.OutSine));

        seq.AppendCallback(() => bg.gameObject.SetActive(false));

    }

    private void Control()
    {

        Sequence seq = DOTween.Sequence();

        bg.gameObject.SetActive(true);

        seq.SetUpdate(true);
        seq.Append(bg.DOFade(0.3f, 0.3f));
        seq.Join(panel.transform.DOLocalMoveX(-456, 0.3f).SetEase(Ease.OutSine));
        seq.AppendInterval(0.05f);

        seq.Append(buttons.GetChild(0).DOLocalMoveX(-660, 0.3f).SetEase(Ease.OutSine));
        seq.Insert(0.5f, buttons.GetChild(1).DOLocalMoveX(-660, 0.3f).SetEase(Ease.OutSine));
        seq.Insert(0.6f, buttons.GetChild(2).DOLocalMoveX(-660, 0.3f).SetEase(Ease.OutSine));

    }

    public void Continue()
    {

        Release();
        Time.timeScale = 1;

    }

    public void Restart()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Exit()
    {

        SceneManager.LoadScene("IntroScene");

    }

    private void OnDestroy()
    {

        Time.timeScale = 1;

    }

}

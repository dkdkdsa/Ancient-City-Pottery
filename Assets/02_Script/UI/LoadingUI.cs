using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private Image _circle;

    private void Start()
    {
        _textMeshProUGUI.DOFade(1, 0.5f);
        _circle.DOFade(1, 0.5f);
    }

    private void Update()
    {
        _circle.transform.Rotate(0, 0, _rotateSpeed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class ClearSystem : MonoBehaviour
{
    public UnityEvent OnClearEvt;

    [SerializeField] private Vector3 boxSize;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private GameObject clearPanel;
    [SerializeField] private RectTransform creditText;
    [SerializeField] private float creditPosY;

    float scrollDuration = 2f;

    bool isClear;

    private void Update()
    {
        bool isFindPlayer = Physics.OverlapBox(transform.position, boxSize / 2, 
                    Quaternion.identity, playerLayer).Length > 0;
        if (isFindPlayer && !isClear)
        {
            isClear = true;
            OnClearEvt?.Invoke();
            ScrollCradit();
        }
    }

    private void ScrollCradit()
    {
        clearPanel.SetActive(true);

        Sequence sequence = DOTween.Sequence();

        sequence.AppendInterval(3f);
        sequence.Append(creditText.DOLocalMoveY(creditPosY, scrollDuration)
            .SetEase(Ease.Linear));
        sequence.AppendInterval(2f)
            .OnComplete(() => 
            {
                //인트로씬으로 넘겨
            });
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
#endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FailureSystem : MonoBehaviour
{
    [SerializeField] private List<LanguageData> Wisesayings;

    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private TextMeshProUGUI wiseText;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            PopupPanel();
    }

    private void PopupPanel() //������ �̺�Ʈ�� �ֱ�
    {
        gameoverPanel.SetActive(true);

        wiseText.text = GetRandomWiseSaying().Text;
    }

    private LanguageData GetRandomWiseSaying()
    {
        int index = Random.Range(0, Wisesayings.Count - 1);
        return Wisesayings[index];
    }
}

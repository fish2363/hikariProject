using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBoxUI : MonoBehaviour
{
    private TextMeshProUGUI _text;
    public static ChatBoxUI Instance { get; private set; }

    [SerializeField]
    private PlayerMove playerMove;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _text = GetComponentInChildren<TextMeshProUGUI>();
        Hide();
    }

    public void SetText(string text)
    {
        _text.SetText(text);               //�ؽ�Ʈ�� �Է�
        _text.ForceMeshUpdate();

        Vector2 textSize = _text.GetRenderedValues(false);   //���⵵ ���Ե� (������ ��) �ؽ�Ʈ�� �ʺ�
        Vector2 offset = new Vector2(8, 8); //������ ũ��
        transform.GetComponent<RectTransform>().sizeDelta = textSize + offset;
    }

    public void Show(string text)
    {
        playerMove._isForce = true;
        gameObject.SetActive(true);
        SetText(text);
    }

    public void Hide()
    {
        playerMove._isForce = false;
        gameObject.SetActive(false);
    }
}

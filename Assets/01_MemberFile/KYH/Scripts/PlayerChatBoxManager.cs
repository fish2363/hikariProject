using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using Cinemachine;

public class PlayerChatBoxManager : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private Image textImage;

    private PlayerAnimation _playerAnimator;
    public static PlayerChatBoxManager Instance { get; private set; }

    private bool isPutInTimer;
    private float putInTimer;

    private float textDelayCounter;

    [SerializeField]
    private PlayerMove playerMove;
    private float currentTimer;

    [SerializeField]
    private bool isWindowScene;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _text = GetComponentInChildren<TextMeshProUGUI>();
        textImage = GetComponentInChildren<Image>();
        _playerAnimator = GameObject.Find("PlayerAnimation").GetComponent<PlayerAnimation>();

        Hide();

    }

    public void SetText(string text, float second)
    {
        DOVirtual.DelayedCall(textDelayCounter, () =>
        {
            _text.SetText(text);               //�ؽ�Ʈ�� �Է�
            _text.ForceMeshUpdate();

            Vector2 textSize = _text.GetRenderedValues(false);   //���⵵ ���Ե� (������ ��) �ؽ�Ʈ�� �ʺ�
            float x = textSize.x;
            x -= (x / 2);
            textSize.x = x;

            Vector2 offset;

            if (_text.textInfo.lineCount > 1)
            {
                float y = textSize.y;
                y -= (y / 2);
                textSize.y = y;
                offset = new Vector2(2, 2); //������ ũ��
            }
            else
                offset = new Vector2(2, 8); //������ ũ��
            textImage.GetComponent<RectTransform>().sizeDelta = textSize + offset;
        });
        textDelayCounter += second;
    }

    public void End()
    {
        DOVirtual.DelayedCall(textDelayCounter, () =>
        {
            Hide();
        });
        textDelayCounter = 0;
    }

    public PlayerChatBoxManager Show(string text, float second, bool isMoveStop)
    {
        print("�ڷ�ƾ �����");
        if(!isWindowScene)
        {
            playerMove._isForce = isMoveStop;
            playerMove.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        textImage.gameObject.SetActive(true);
        SetText(text, second);
        putInTimer = second;
        isPutInTimer = true;
        print("����");
        return this;
    }

    private void Hide()
    {
        if (!isWindowScene)
            playerMove._isForce = false;
        textImage.gameObject.SetActive(false);
        isPutInTimer = false;
        currentTimer = 0f;
        return;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonMnager : MonoBehaviour
{
    private int _value;

    [SerializeField] private GameObject _Esc;
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private Button _brightButton;
    [Header("��ȭ��")]
    [SerializeField] private TextMeshProUGUI _FireWallTrueText;
    public bool IsFireWallTrue;
    [Header("Wifi")]
    [SerializeField] private TextMeshProUGUI _WifiCollectText;
    public bool IsWifiTrue;
    [Header("Sound")]
    [SerializeField] private TextMeshProUGUI _SoundText;
    [SerializeField] private Slider _musicSlider;

    [Header("ButtonList")]
    public List<GameObject> ChangeButton = new List<GameObject>();
    public int SceneNumber;

    private void Awake()
    {
        _Esc.SetActive(false);
        IsWifiTrue = false;
        IsFireWallTrue = false;
        _brightButton.interactable = false;
    }

    private void Start()
    {
        _FireWallTrueText.text = "���� �ȵ�";
        _WifiCollectText.text = "���� �ȵ�";

    }

    private void Update()
    {
        _value = (int)_musicSlider.value;
        SceneNumber = SceneManager.GetActiveScene().buildIndex;

        SceneTextChange();

        InteractablFalse();

        _SoundText.text = $"{_value}";

        if (IsFireWallTrue == true)
        {
            _FireWallTrueText.text = "�����";
        }
        else if (IsFireWallTrue == false )
        {
            _FireWallTrueText.text = "���� �ȵ�";
        }

        if (IsWifiTrue == true)
        {
            _WifiCollectText.text = "�����";
        }
        else if (IsWifiTrue == false)
        {
            _WifiCollectText.text = "���� �ȵ�";
        }
    }

    private void SceneTextChange()
    {
        int i = 0;
        switch(SceneNumber)
        {
            case 3:
                _currentText.text = "����";
                ChangeButton[i].SetActive(true);
                i++;
                break;
            case 4:
                _currentText.text = "ĸ��";
                ChangeButton[i - 1].SetActive(false);
                ChangeButton[i].SetActive(true);
                break;
            case 5:
                _currentText.text = null;
                break;
        }
    }

    private void InteractablFalse()
    {
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            _brightButton.interactable = true;
        }
        else
        {
            _brightButton.interactable = false;
        }
    }

    public void FireWall()
    {
        if(IsFireWallTrue == true)
        {
            IsFireWallTrue = false;
        }
        else
        {
            IsFireWallTrue = true;
        }    
    }

    public void WifiTrue()
    {
        if (IsWifiTrue == true)
        {
            IsWifiTrue = false;
        }
        else
        {
            IsWifiTrue = true;
        }
    }
}

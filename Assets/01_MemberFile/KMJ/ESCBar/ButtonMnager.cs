using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ButtonMnager : MonoBehaviour
{
    private int _value;
    public static int i = 0;

    [SerializeField] private GameObject _Esc;
    [SerializeField] private TextMeshProUGUI _currentText;
    [SerializeField] private Button _brightButton;
    [Header("��ȭ��")]
    [SerializeField] private TextMeshProUGUI _FireWallTrueText;
    public bool IsFireWallTrue;
    [Header("Wifi")]
    [SerializeField] private TextMeshProUGUI _WifiCollectText;
    [field :SerializeField] public bool IsWifiTrue { get; set; }
    [field: SerializeField] private Animator _wifiAniamtion;
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


        InteractablFalse();

        _SoundText.text = $"{_value}";

        if (IsFireWallTrue == true)
        {
            _FireWallTrueText.text = "�����";
            _FireWallTrueText.color = Color.green;
        }
        else if (IsFireWallTrue == false )
        {
            _FireWallTrueText.text = "���� �ȵ�";
            _FireWallTrueText.color = Color.red;
        }

        if (IsWifiTrue == true)
        {
            _WifiCollectText.text = "�����";
            _WifiCollectText.color = Color.green;
            _wifiAniamtion.enabled = true;
        }
        else if (IsWifiTrue == false)
        {
            _WifiCollectText.text = "���� �ȵ�";
            _WifiCollectText.color = Color.red;
            _wifiAniamtion.enabled = false;
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

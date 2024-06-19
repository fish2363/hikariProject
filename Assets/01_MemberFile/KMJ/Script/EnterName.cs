using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    public TextMeshProUGUI receiveText;
    public TMP_InputField display;

    private void Start()
    {
        receiveText.text = PlayerPrefs.GetString("�̸� �Է�");
    }

    public void Enter()
    {
        receiveText.text = $"������̸�: {display.text}";
        PlayerPrefs.SetString("�̸� �Է�", receiveText.text);
        PlayerPrefs.Save();
    }


    private void Update()
    {
        None();
    }
    public void None()
    {
        if(Input.GetMouseButtonDown(1))
        {
            receiveText.text = $"������̸�: ������";
        }
    }
}

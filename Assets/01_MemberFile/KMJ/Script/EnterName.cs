using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterName : MonoBehaviour
{
    public TextMeshProUGUI receiveText;
    public TMP_InputField display;

    public List<string> str = new List<string>();

    

    private void Start()
    {
        receiveText.text = PlayerPrefs.GetString("�̸� �Է�");
    }

    public void Enter()
    {
        if(display.text.Length < 5)
        {
            receiveText.text = $"������̸�: {display.text}";
        }
        else
        {
            receiveText.text = $"�ٽ� �Է��ϼ���";
        }
        PlayerPrefs.SetString("�̸� �Է�",  receiveText.text);
        PlayerPrefs.Save();
        
    }


    private void Update()
    {
        None();
        Filtering();
    }

    private void Filtering()
    {
        foreach (string no in str)
        {
            if(display.text == no)
            {
                receiveText.text = "�������� �̸��Դϴ�";
            }
        }
    }

    private void None()
    {
        if(Input.GetMouseButtonDown(1))
        {
            receiveText.text = $"������̸�: ��ī����";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonClick : MonoBehaviour
{
    [field: SerializeField] public TMP_InputField InputField { get; set; }

    public void Button1()
    {
        InputField.text = "���ؼ� Ž��";
    }
    public void Button2()
    {
        InputField.text = "���ؿ� �ִ� �����";
    }
    public void Button3()
    {
        InputField.text = "���ؼ� ����";
    }


}

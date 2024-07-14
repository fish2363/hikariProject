using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SearchBar : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputFieldText;
    [SerializeField] private GameObject _inputField;
    [SerializeField] private GameObject _inputSlide;
    [SerializeField] private GameObject _answerScreen;

    private void Awake()
    {
        _inputSlide.SetActive(false);
        _answerScreen.SetActive(false);
    }

    public void EnterSearch()
    {
        if(_inputFieldText.text == "���ؼ� Ž��" || _inputFieldText.text == "���ؿ� �ִ� �����" || _inputFieldText.text == "���ؼ� ����")
        {
            _inputFieldText.text = null;
            _inputSlide.SetActive(false);
            _inputField.SetActive(false);
            _answerScreen.SetActive(true);
        }
        else if(_inputFieldText.text == null)
        {
            _inputFieldText.text = null;
            _inputSlide.SetActive(false);
            _inputField.SetActive(true);
            _answerScreen.SetActive(false);
        }
    }
    
    public void Onselect()
    {
        _inputSlide.SetActive(true);
    }

    public void OnDelete()
    {
        _inputSlide.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class NodePuzzle : MonoBehaviour
{
    const int SIZE = 4;
    const int RANGE = 100000;

    private Button[] _valueBtn;
    private TextMeshProUGUI[] _valueTxt;
    private RawImage[] _nodes;
    private int[] _valueOrder = new int[4]; //������ ������ �����ϴ� �迭
    private int[,] _valueArr = new int[4, SIZE]; //�������� ���� ���� �迭
    private int[] answer = new int[4];

    private int _sum = 0; //���� ������ ��
    private TextMeshProUGUI _reqTxt;
    private TextMeshProUGUI _sumTxt;

    [SerializeField] private int[] Answer = new int[4];
    [SerializeField] private int _answer; //����

    private void Awake()
    {
        Assignment();
        InitializePuzzle();
    }

    private void Assignment()
    {
        _valueBtn = new Button[4];
        _valueTxt = new TextMeshProUGUI[4];
        _nodes = new RawImage[4];

        _reqTxt = GameObject.Find("DesireNumberText").GetComponent<TextMeshProUGUI>();
        _sumTxt = GameObject.Find("SumText").GetComponent<TextMeshProUGUI>();


        for (int i = 0; i < 4; i++)
        {
            _valueBtn[i]
                = GameObject.Find($"ValueButton{i + 1}").GetComponent<Button>();
            _valueTxt[i]
                = GameObject.Find($"ValueText{i + 1}").GetComponent<TextMeshProUGUI>();
            _nodes[i]
                = GameObject.Find($"Node{i + 1}").GetComponent<RawImage>();
        }
    }

    private void InitializePuzzle() //���� �ʱ�ȭ
    {
        int sum = 0;
        _answer = Random.Range(0, RANGE);
        StartCoroutine(DesireTextAnim());

        for (int i = 0; i < 3; i++)
        {
            answer[i] = Random.Range
                (0, _answer / 4);

            answer[i] = CheckOdd(answer[i], i);

            sum += answer[i];
        }

        answer[3] = _answer - sum;

        for (int i = 0; i < 4; i++)
            Answer[i] = answer[i];

        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, SIZE);
            for (int j = 0; j < SIZE; j++)
            {
                if (j == index)
                    _valueArr[i, j] = answer[i];
                else
                {
                    _valueArr[i, j] = SetValueArr(j);
                    _valueArr[i, j] = CheckOdd(_valueArr[i, j], i);
                }
            }
        }

        for (int i = 0; i < 4; i++)
        {
            SetReqireButton(i);
        }

        GetSum();
    }

    private int CheckOdd(int num, int index)
    {
        if (index % 2 == 0)
        {
            if (num % 2 == 0)
                num++;
            else
                num--;
        }
        else
        {
            if (num % 2 == 0)
                num--;
            else
                num++;
        }

        return num;
    }

    private int SetValueArr(int j)
    {
        int min = ((j * j) * 10) * (j * 10);
        int max = (j * j + 1) * 20 * (j * 10 + 1);

        return Random.Range(min, max);
    }

    private void SetReqireButton(int index) //��ư ���� ī��Ʈ ����
    {
        int rand = Random.Range(0, SIZE - 1);

        _valueOrder[index] = rand;
        _valueTxt[index].text = _valueArr[index, rand].ToString();
    }

    public void OnReqireClick() //��ư Ŭ��
    {
        string button = EventSystem.current
            .currentSelectedGameObject.name.ToString();

        int index = int.Parse(button.Substring(button.Length - 1)) - 1;

        _valueOrder[index]++;

        if (_valueOrder[index] >= SIZE)
            _valueOrder[index] = 0;

        _valueTxt[index].text = _valueArr
            [index, _valueOrder[index]].ToString();

        GetSum();
        CheckEqual();
    }

    private void GetSum()
    {
        _sum = 0;

        for (int i = 0; i < 4; i++)
            _sum += _valueArr[i, _valueOrder[i]];

        _sumTxt.text = $"�հ� : {_sum}";
    }

    private void CheckEqual()
    {
        if (_sum == _answer)
            Sucess();
    }

    private void Sucess()
    {
        Debug.Log("����");
    }

    private IEnumerator DesireTextAnim() //���� �ٲ�� ȿ��
    {
        for (int i = 0; i < 25; i++)
        {
            _reqTxt.text = Random.Range(0, RANGE).ToString();
            yield return new WaitForSeconds(0.05f);
        }

        _reqTxt.text = _answer.ToString();
    }
}

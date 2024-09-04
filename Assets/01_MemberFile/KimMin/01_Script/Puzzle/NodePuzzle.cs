using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class NodePuzzle : MonoBehaviour
{
    const int SIZE = 10;
    const int RANGE = 100000;

    private Button[] _valueBtn;
    private TextMeshProUGUI[] _valueTxt;
    private RawImage[] _nodes;
    private int[] _valueOrder = new int[4]; //������ ������ �����ϴ� �迭
    private int[,] _valueArr = new int[4, SIZE]; //�������� ���� ���� �迭
    private int[] _answerList = new int[4];

    private int _answer; //����
    private float _sum = 0; //���� ������ ��
    [SerializeField] private float _approxRatio, _ratio, _prevApproxRatio;
    private float _currentVelocity;

    private bool _isStart;

    private TextMeshProUGUI _reqTxt;
    private TextMeshProUGUI _sumTxt;

    [SerializeField] private Slider _approxSlider;

    private void Awake()
    {
        Assignment();
        InitializePuzzle();
    }

    private void Update()
    {
        if (_isStart)
        {
            float current = Mathf.SmoothDamp(_approxSlider.value, _ratio, ref _currentVelocity, 0.1f, 5f);
            _approxSlider.value = current;
        }
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
        _answer = Random.Range(RANGE / 3, RANGE);
        StartCoroutine(DesireTextAnim());

        for (int i = 0; i < 3; i++)
        {
            _answerList[i] = Random.Range(0, _answer / 4);
            sum += _answerList[i];
        }

        _answerList[3] = _answer - sum;

        for (int i = 0; i < 4; i++)
        {
            int index = Random.Range(0, SIZE);
            for (int j = 0; j < SIZE; j++)
            {
                if (j == index)
                    _valueArr[i, j] = _answerList[i];
                else
                    _valueArr[i, j] = SetValueArr(j + 1);
            }
        }

        for (int i = 0; i < 4; i++)
            SetReqireButton(i);

        GetSum();
    }

    private int SetValueArr(int j)
    {
        int min = ((j * j) * SIZE / 4) * (j * SIZE / 4);
        int max = (j * j) * SIZE / 2 * (j * SIZE / 2);

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
        ApproximateRatio();
    }

    private void GetSum()
    {
        _sum = 0;

        for (int i = 0; i < 4; i++)
            _sum += _valueArr[i, _valueOrder[i]];

        _sumTxt.text = $"�հ� : {_sum}";
    }

    private void ApproximateRatio()
    {
        _approxRatio = (_answer - _sum) / _answer;

        if (_approxRatio > 0)
        {
            _ratio = 1 - _approxRatio;
            _prevApproxRatio = _ratio;
        }
        else
        {
            _ratio = 1 - Mathf.Abs(_approxRatio);
            _prevApproxRatio -= _ratio;
        }

        _isStart = true;

        if (1 - _ratio <= 0.005f)
            Sucess();
    }

    private void Sucess()
    {
        foreach (RawImage node in _nodes)
        {
            node.DOColor(Color.green, 1.5f);
        }
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

using UnityEngine;

public class CaptureStartText : MonoBehaviour
{
    public static bool _isStart;
    private Color[] color;

    private void Awake()
    {
        _isStart = true;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        if(_isStart == true)
        {
            PlayerChatBoxManager.Instance.Show("�������� ��������", 3, true)
                .Show("���� ������ �̵��Ͽ� Ż������!", 3.5f, true)
                .End();
        }
    }

    private void Update()
    {
    }





}

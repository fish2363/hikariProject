using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramIcon : MonoBehaviour
{
    [SerializeField] private List<GameObject> priviewWindow = new List<GameObject>();
    private bool isContactCursor; // Ŀ���� �̸����� ȭ�鿡 ��Ҵ°�

    private void Awake()
    {
        for (int i = 0; i < priviewWindow.Count; i++)
        {
            priviewWindow[i].SetActive(false);
        }
    }

    private void Update()
    {
        PriviewWindowOn();
    }

    private void PriviewWindowOn() // �̸����� Ȱ��ȭ ���
    {
        if (isContactCursor == true) // Ŀ���� ���α׷� �����ܿ� ����ִ� ���
        {
            // �̸����� ȭ���� Ȱ��ȭ ��Ų��.
            for (int i = 0; i < priviewWindow.Count; i++)
            {
                priviewWindow[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < priviewWindow.Count; i++)
            {
                priviewWindow[i].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cursor")) // Ŀ���� ���α׷� �����ܿ� ����� ���
        {
            isContactCursor = true; // isContactCursor�� ���� ���θ� ������ �����.
        }
    }

    private void OnTriggerExit2D(Collider2D other) // Ŀ���� ���α׷� �����ܿ� ��Ҵٰ� �������� ���
    {
        if (other.CompareTag("Cursor"))
        {
            isContactCursor = false;
        }
    }
}

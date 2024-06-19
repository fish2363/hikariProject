using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramIcon : MonoBehaviour
{
    [SerializeField] private List<GameObject> priviewWindow = new List<GameObject>();
    private bool isContactCursor;

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

    private void PriviewWindowOn()
    {
        if (isContactCursor == true) // Ŀ���� ���α׷� �����ܿ� ����ִ� ���
        {
            //priviewWindow[priviewWindow.Count].SetActive(true);
            // �̸����� ȭ���� Ȱ��ȭ ��Ų��.
            for (int i = 0; i < priviewWindow.Count; i++)
            {
                priviewWindow[i].SetActive(true);
            }
        }
        else
        {
            //priviewWindow[priviewWindow.Count].SetActive(false);
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

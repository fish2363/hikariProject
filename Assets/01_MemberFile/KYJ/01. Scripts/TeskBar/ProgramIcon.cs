using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgramIcon : MonoBehaviour
{
    [SerializeField] private List<GameObject> priviewWindow = new List<GameObject>();
    public bool isContactCursor; // Ŀ���� �̸����� ȭ�鿡 ��Ҵ°�

    private void Start()
    {
        priviewWindow[0].SetActive(false);

    }

    private void Update()
    {
        PriviewWindowOn();
    }

    private void PriviewWindowOn() // �̸����� Ȱ��ȭ ���
    {
        if (isContactCursor) // Ŀ���� ���α׷� �����ܿ� ����ִ� ���
        {
            priviewWindow[0].SetActive(true);
            // �̸����� ȭ���� Ȱ��ȭ ��Ų��.
            //for (int i = 0; i < priviewWindow.Count; i++)
            //{
            //    print("������ ��ҽ��ϴ�.");
            //    priviewWindow[i].SetActive(true);
            //}
        }
        else if(isContactCursor != true)
        {
            priviewWindow[0].SetActive(false);

            //for (int i = 0; i < priviewWindow.Count; i++)
            //{
            //    priviewWindow[i].SetActive(false);
            //}
        }
    }

    public void ShowWindow()
    {
        isContactCursor = true; // isContactCursor�� ���� ���θ� ������ �����.
    }

    public void DownWindow()
    {
        isContactCursor = false; // isContactCursor�� ���� ���θ� ������ �����.
    }

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Cursor")) // Ŀ���� ���α׷� �����ܿ� ����� ���
    //    {
    //        isContactCursor = true; // isContactCursor�� ���� ���θ� ������ �����.
    //    }
    //}

    private void OnTriggerExit2D(Collider2D other) // Ŀ���� ���α׷� �����ܿ� ��Ҵٰ� �������� ���
    {
        if (other.CompareTag("Cursor"))
        {
            isContactCursor = false;
        }
    }
}

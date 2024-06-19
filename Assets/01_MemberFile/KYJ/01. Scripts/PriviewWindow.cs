using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PriviewWindow : MonoBehaviour
{
    [SerializeField] public bool isContactingPreview; // �̸����� ȭ�鿡 ���� ���� bool
    
    public bool IsContactingPreview
    {
        get
        {
            return isContactingPreview;
        }
        set
        {
            isContactingPreview = value;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �÷��̾ �̸����� ȭ�鿡 ����� ���
        {
            isContactingPreview = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // �÷��̾ �̸����� ȭ�鿡 ��Ҵٰ� �������� ���
        {
            isContactingPreview = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerMovement
{
    //private NewBehaviourScript window;
    [SerializeField] private bool isContactingPreview; // �̸����� ȭ�鿡 ���� ���� bool
    [SerializeField] private GameObject SettingWindow;
    [SerializeField] private List<GameObject> button = new List<GameObject>();
    private bool isCoolTime;


    private void Awake()
    {
        //window = GameObject.Find("AppIcon").GetComponent<NewBehaviourScript>(); 
        for (int i = 0; i < button.Count; i++)
        {
            button[i].SetActive(false);
        }
        SettingWindow.SetActive(false);
    }

    private void Teleporting() // �÷��̾ �̸����� ȭ�� ������ �̵�
    {
        if (/*window.IsTriggerCursor == true && */isContactingPreview == true && Input.GetKeyDown(KeyCode.E)) // �����쿡 Ŀ���� ���, �÷��̾ ������� EŰ�� ������ ���
        {
            SceneManager.LoadScene("PreviewScene"); // �̸����� ȭ������ �� ��ȯ
        }
    }

    public void Buffering() // �������� �ٿ��� ���, �÷��̾� �����ӿ� ���۸�
    {
        int i = Random.Range(0, 100);
        if (i < 50) // 50% Ȯ����
        {
            PlayerMove(0.1f); // �÷��̾� �̵� �ӵ� ����
        }
        else
        {
            PlayerMove(4); // ����
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PriviewWindow")) // �÷��̾ �̸����� ȭ�鿡 ����� ���
        {
            isContactingPreview = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("PriviewWindow")) // �÷��̾ �̸����� ȭ�鿡 ��Ҵٰ� �������� ���
        {
            isContactingPreview = false;
        }
    }
}

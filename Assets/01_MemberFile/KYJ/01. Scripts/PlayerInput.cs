using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInput : PlayerMovement
{
    [SerializeField] private GameObject SettingWindow;
    [SerializeField] private List<GameObject> button = new List<GameObject>();
    private PriviewWindow priviewWindow;


    private void Awake()
    {
        priviewWindow = GameObject.Find("PriviewWindow").GetComponent<PriviewWindow>();

        for (int i = 0; i < button.Count; i++)
        {
            button[i].SetActive(false);
        }
        SettingWindow.SetActive(false);
    }

    private void Update()
    {
        Teleporting();
    }

    private void Teleporting() // �÷��̾ �̸����� ȭ�� ������ �̵�
    {
        if (priviewWindow.isContactingPreview == true && Input.GetKeyDown(KeyCode.E)) // �����쿡 Ŀ���� ���, �÷��̾ ������� EŰ�� ������ ���
        {
            print("����");
            SceneManager.LoadScene("PreviewScenes"); // �̸����� ȭ������ �� ��ȯ
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

    
}

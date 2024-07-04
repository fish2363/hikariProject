using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    private PriviewWindow priviewWindow;
    private Rigidbody2D rigid;

    private bool isCoolTime;


    private void Awake()
    {
        priviewWindow = GameObject.Find("PriviewWindow").GetComponent<PriviewWindow>();
        rigid = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Teleporting();
        PlayerMove(4f);
    }
    

    public void PlayerMove(float speed) // �÷��̾� �̵�
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(x, 0);
        moveDir = moveDir.normalized;
        rigid.velocity = moveDir * speed;
    }


    private void Teleporting() // �̸����� ȭ������ �̵�
    {
        if (priviewWindow.IsContactingPreview == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("PreviewScenes"); // �̸����� ȭ�� ������ ��ȯ
        }
    }


    public void Buffering() // ���۸� ���
    {
        int i = Random.Range(0, 100);
        if (i < 50 && !isCoolTime) // 50�� Ȯ����
        {
            PlayerMove(0.1f); // ���۸�
        }
        else
        {
            PlayerMove(4f);
        }
    }
}

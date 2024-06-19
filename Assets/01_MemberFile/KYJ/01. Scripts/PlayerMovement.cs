using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private PriviewWindow priviewWindow;
    private Rigidbody2D rigid;
    private bool isCoolTime;
    [SerializeField] private float speed = 5;


    private void Awake()
    {
        priviewWindow = GameObject.Find("PriviewWindow").GetComponent<PriviewWindow>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Teleporting();
        PlayerMove(4);
    }
    

    public void PlayerMove(float speed) // �÷��̾� �̵�
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 moveDir = new Vector3(x * speed, rigid.velocity.y);
        rigid.velocity = moveDir;
    }

    private void Teleporting() // �̸����� ȭ������ �̵�
    {
        if (priviewWindow.isContactingPreview == true && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("PreviewScenes"); // �� ��ȯ
        }
    }

    public void Buffering() // ���۸� ���
    {
        int i = Random.Range(0, 100);
        if (i < 50 && !isCoolTime)
        {
            PlayerMove(0.1f);
        }
        else
        {
            PlayerMove(4);
        }
    }


    IEnumerator BufferingCool(float cooltime) // ���۸� ��Ÿ��
    {
        isCoolTime = true;
        yield return new WaitForSeconds(cooltime);
        isCoolTime = false;
    }
}

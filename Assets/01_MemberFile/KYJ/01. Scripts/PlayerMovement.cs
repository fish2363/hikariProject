using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region ������Ʈ
    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    #endregion


<<<<<<< Updated upstream
    private void FixedUpdate()
    {
        PlayerMove(5f);
=======
    private void Update()
    {
        Teleporting();
        PlayerMove(4f);
>>>>>>> Stashed changes
    }


    protected virtual void PlayerMove(float speed) // �÷��̾� �̵�
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 moveDir = new Vector2(x, 0);
        moveDir = moveDir.normalized;
        rigid.velocity = moveDir * speed;
    }
<<<<<<< Updated upstream
=======


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
>>>>>>> Stashed changes
}

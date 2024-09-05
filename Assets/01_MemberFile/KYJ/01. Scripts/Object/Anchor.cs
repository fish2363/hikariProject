using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Rigidbody2D _rigidCompo;
    [SerializeField] private PlayerMove _agentMove;

    private float knockbackPower = 5f;
    [SerializeField] private float knockbackTime = 1.5f;

    private bool CanKnockback;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KnockedBack(_agentMove.transform.position);
        }
    }

    private void DroppedAnchor()
    {
        StartCoroutine(DropCool());
        _rigidCompo.bodyType = RigidbodyType2D.Dynamic;
    }

    private IEnumerator DropCool()
    {
        float rand = Random.Range(0, 5);
        yield return new WaitForSeconds(5f);
    }

    public void KnockedBack(Vector2 playerDirection)
    {
        _agentMove._isForce = true;
        _agentMove._rigid.AddForce(playerDirection.normalized * knockbackPower, ForceMode2D.Impulse);
        print("�˹�");
        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine() //�ڷ�ƾ �ڿ� ������ Routine ���̱�!
    {
        yield return new WaitForSeconds(knockbackTime);
        _agentMove._isForce = false;
    }
}

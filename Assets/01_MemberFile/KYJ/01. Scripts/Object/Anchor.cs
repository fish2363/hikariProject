using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private Rigidbody2D _rigidCompo;
    [SerializeField] private PlayerMove _agentMove;

    [SerializeField] private float knockbackPower = 12f;
    private float knockbackTime = 1.5f;

    private void Awake()
    {
        _rigidCompo = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            KnockedBack(_agentMove.transform.position);
        }
    }

    public void DroppedAnchor()
    {
        _rigidCompo.bodyType = RigidbodyType2D.Dynamic;
    }

    public void KnockedBack(Vector2 playerDirection)
    {
        _agentMove._isForce = true;
        _agentMove._rigid.velocity = Vector2.zero;

        _agentMove._rigid.AddForce((playerDirection - (Vector2)transform.position) * knockbackPower, ForceMode2D.Impulse);
 
        print("�˹�");
        StartCoroutine(JumpRoutine());
    }

    private IEnumerator JumpRoutine() //�ڷ�ƾ �ڿ� ������ Routine ���̱�!
    {
        yield return new WaitForSeconds(knockbackTime);
        _agentMove._isForce = false;
    }
}

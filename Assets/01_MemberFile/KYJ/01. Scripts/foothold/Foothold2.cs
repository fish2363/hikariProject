using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Foothold2 : Foothold
{
    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        StartCoroutine(MoveFoothold(3f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            isBack = true;
        }
    }

    protected override IEnumerator MoveFoothold(float stopTime)
    {
        return base.MoveFoothold(stopTime);
    }

}


//������ �ð����� ����ٰ� �������� ������. --> �����ϰ� �������� ���ǵ��� �龦���� �ϰ���. / ���� ���� ��ũ��Ʈ���� �ӹ����� �ö���� �ð��� ���������� �ٲ���.
// ��ư ������ �����. / ��ư�� �÷��̾�, ��ü�� �������� ��� -> bool ������ ���� Ȯ������
// ��ư ������ �̷������ ��! ������ �Ϸķ� ���ĵǰ� ������. -> bool ���� Ȯ�εǸ� ���� ������ ���� ��ġ�� �ǵ�����, ������ �޼����� �ð��� ���������� ������ ������ �ٲ���.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public abstract class Foothold : MonoBehaviour
{
    protected Rigidbody2D _rigid;

    [SerializeField] protected bool isBack;

    protected float startPos;
    protected float targetPos;

    protected virtual void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();

        startPos = transform.position.y;
        targetPos = transform.position.y - 15f;
    }


    protected virtual IEnumerator DownMoveFoothold(float stopTime) 
    {
        if (transform.position.y == startPos)
        {
            yield return new WaitForSeconds(stopTime);
            transform.DOMoveY(targetPos, 3f);
            isBack = true;
        }
    }


    protected virtual IEnumerator UpMoveFoothold(float stopTime)
    {
        if (/*transform.position.y != startPos/* && */!isBack)
        {
            yield return new WaitForSeconds(stopTime);
            _rigid.bodyType = RigidbodyType2D.Static;
            transform.DOMoveY(startPos, 3f);
            isBack = false;
    }
}
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureManager : MonoBehaviour
{
    [Header("ĸ�� ������")]
    [SerializeField]
    private Vector2 captureSize;
    [SerializeField]
    private LayerMask whatIsCaptureObj;

    private Vector2 mousePos;
    private bool isNowCapture;

    private void Update()
    {
        Capture();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(!isNowCapture)
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, mousePos, 10f * Time.deltaTime);
    }

    public void Capture()
    {
        Collider2D[] captureObject = Physics2D.OverlapBoxAll(gameObject.transform.position,captureSize,0,whatIsCaptureObj);

        if(Input.GetMouseButtonDown(0) && !isNowCapture)
        {
            if(captureObject != null)
            {
                isNowCapture = true;
                for(int i=0; i<captureObject.Length; i++)
                {
                    captureObject[i].GetComponent<CaptureObject>().CaptureFinish();
                }
                StartCoroutine(WaitCaptureRoutine());
            }
            print("ĸ���� �����İ� �����ϴ�");    
        }
    }

    private IEnumerator WaitCaptureRoutine()
    {
        yield return new WaitForSeconds(2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(gameObject.transform.position, captureSize);
    }
}

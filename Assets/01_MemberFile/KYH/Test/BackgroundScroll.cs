using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    private Camera mainCam;
    [SerializeField]
    private float moveSpeed = 0.15f;

    private Vector2 initialPosition; // ����� �ʱ� ��ġ�� ������ ����

    private void Awake()
    {
        mainCam = mainCam == null ? Camera.main : mainCam;
        initialPosition = transform.position; // ����� �ʱ� ��ġ ����
    }

    private void FixedUpdate()
    {
        // ����� ī�޶��� �����ӿ� ���� �ʱ� ��ġ�� �������� �̵��ϰ� ��
        transform.position = new Vector2(initialPosition.x + mainCam.transform.position.x * moveSpeed, initialPosition.y);
    }
}


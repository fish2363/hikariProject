using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImagePopUpFeedback : Feedback
{
    [SerializeField] private GameObject _popUpObject;

    public override void PlayFeedback()
    {
        
    }

    public override void StopFeedback()
    {
        
    }

    private Vector2 GetSpawnPos() //���� ��ġ ���� �żҵ�
    {
        Vector2 spawnPos = Camera.main.ViewportToScreenPoint(new Vector2(
            Random.Range(0.15f, 0.85f), Random.Range(0.15f, 0.85f)));

        return spawnPos;
    }

    private void GeneratePopUp()
    {
        GameObject popUpObject = Instantiate(_popUpObject, GetSpawnPos(), Quaternion.identity);
    }
}

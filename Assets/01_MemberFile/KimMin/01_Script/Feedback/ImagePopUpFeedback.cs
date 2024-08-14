using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagePopUpFeedback : Feedback
{
    [SerializeField] private GameObject _popUpObject; //�˾� ���ӿ�����Ʈ
    [SerializeField] private GameObject _targetToSpawn; //������ ��ġ Ÿ��
    [SerializeField] private float _spawnRadius; //Ÿ�ٿ��� ������ �Ÿ� ����
    [SerializeField] private int _timeToRepeat; //������ Ƚ��
    [SerializeField] private List<Sprite> _spriteList; //�˾� �̹��� ����Ʈ

    private SpriteRenderer _spriteRenderer;

    [Range(0, 30)] //�����Ϳ��� �����̴��� �߰� �ϴ°�
    [SerializeField] private float _spawnTime; //���� �ð�

    private void Awake()
    {
        _spriteRenderer = _popUpObject.GetComponent<SpriteRenderer>();
    }

    public override void PlayFeedback()
    {
        StartCoroutine(PopUpCoroutine());
    }

    public override void StopFeedback()
    {
        
    }

    private Vector3 GetSpawnPos() //���� ��ġ ���� �żҵ�
    {
        Vector3 spawnPos = _targetToSpawn.transform.position +
            (Vector3)Random.insideUnitCircle * _spawnRadius; //Ÿ���� �ֺ� �ݰ����� ��ġ ����

        return spawnPos;
    }

    private void GeneratePopUp()
    {
        _spriteRenderer.sprite = _spriteList[Random.Range(0, _spriteList.Count)]; //�˾� �̹��� �������� ����
        Vector3 spawnPos = GetSpawnPos(); //���� ��ġ �޾ƿ���
        Instantiate(_popUpObject, spawnPos, Quaternion.identity, transform); //�˾� ����
    }

    private IEnumerator PopUpCoroutine()
    {
        for (int i = 0; i < _timeToRepeat; i++) //�ݺ� Ƚ����ŭ �ݺ�
        {
            yield return new WaitForSeconds(_spawnTime);
            GeneratePopUp();
        }
    }
}

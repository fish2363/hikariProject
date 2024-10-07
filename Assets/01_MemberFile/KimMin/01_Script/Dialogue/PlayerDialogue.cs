using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    void Start()
    {
        PlayerChatBoxManager.Instance
            .Show("����.. �̰��� �����..?", 3f, true)
            .Show("���� �����ΰ�..", 3f, true)
            .Show("����... ��������", 3f, true)
            .Show("�� ���� ���������߁پ�.", 3f, true)
            .End();
    }

    public void LuminescentPlantDialog()
    {
        PlayerChatBoxManager.Instance
            .Show("����..�� ������ ����..?", 3f, true)
            .Show("������.. ���� ��ī����.", 3f, true)
            .Show("�̰��� �� ���� �غ��߰ھ�", 3f, true)
            .Show("�ƾ�, ���� �����ϱ�.", 3f, true)
            .End();
    }

    public void AnglerFishDialog()
    {
        PlayerChatBoxManager.Instance
            .Show("����..? �Ʊ�����..?", 3f, true)
            .Show("���� �Ʊ͵����� �� ������ ������.", 3f, true)
            .Show("�����ϴ� ��⿡ ���� �����ϴ°� ����", 3f, true)
            .End();
    }
}

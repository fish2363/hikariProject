using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    void Start()
    {
        PlayerChatBoxManager.Instance
            .Show("�̰��� �����?", 3f, true)
            .Show("���� �ٴ��ϱ�?", 3f, true)
            .Show("���� ��������", 3f, true)
            .Show("�̰��� ���������� �ҰͰ���!.", 3.5f, true)
            .End();
    }

    public void LuminescentPlantDialog()
    {
        PlayerChatBoxManager.Instance
            .Show("�� ������ ����?", 3f, true)
            .Show("���� ��ī��.. �������� �����ϳ�", 4f, true)
            .Show("�� ��ü�� ��� I�� U�� ������ ��⸦ ������ �� �־�", 4.5f, true)
            .Show("��⸦ �̿��� Ư���� ��ü���� �۵���ų �� �־�", 4f, true)
            .End();
    }

    public void LeafWallDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("�̰��� �ٻ�� ����̾�", 3f, true)
            .Show("�� ����� Ư���� ��⿡�� ��� �������", 4.5f, true)
            .Show("Ư���� ��⸦ �� ã�Ƽ� ����� �Ѿ����!", 5f, true)
            .End();
    }

    public void AnglerFishDialog()
    {
        PlayerChatBoxManager.Instance
            .Show("�Ʊ� ���� ǥ�����̾�!", 3f, true)
            .Show("�Ʊʹ� ���� ���ù����� ������", 3.5f, true)
            .Show("������ ������!", 3f, true)
            .Show("���� �ʰ� �Һ��� ���� �ʴ´ٸ� �ƱͰ� �����ϴ� ���� �����״ϱ�!", 6f, true)
            .End();
    }

    public void BrightFlowerDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("�̰��� �پ��� �ɵ��� ��Ƽ� �ö󰡾���", 3.5f, true)
            .Show("�ɵ��� Ư���� ��⿡���� �ɺ��츮�� �����ž�", 4f, true)
            .Show("���� �ؿ� \"å ��� ��ư\"�� Ŭ���� ������ �����", 5f, true)
            .Show("�������� ���� ���� ���� ��⿡ �����ϴ��� �����־�!", 5f, true)
            .End();
    }
}

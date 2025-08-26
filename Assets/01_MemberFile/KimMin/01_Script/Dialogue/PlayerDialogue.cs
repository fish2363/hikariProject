using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{
    public void StartDialogue()
    {
        new PlayerChatBoxManager()
            .Show("���� ��������", 3f, true)
            .Show("���� �����?", 3f, true)
            .Show("���� ���ط� ���Գ���..", 3f, true)
            .Show("���� �ڷᳪ ã�� ������ ������", 3.5f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void LuminescentPlantDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("�� ���� ����?", 3f, true)
            .Show("�ȿ��� ���� ������� �־�", 4f, true)
            .Show("�ű��ϳ�..�ֿ�����", 4.5f, true)
            .Show("( I �� U �� ��⸦ ������ �� �ֽ��ϴ� )", 4f, true)
            .End();

       QuestPopupUI.Instance.QuestTxt();
    }

    public void LeafWallDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("�� �ٻ�� ���� ���ͳݿ��� �����־�", 3f, true)
            .Show("Ư�� ��⸦ �Ⱦ��Ѵٰ� �ߴµ�", 4.5f, true)
            .Show("�� �Ĺ��� �̿��غ���?", 5f, true)
            .End();
    }

    public void AnglerFishDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("��� ���� ��� ����ü�� ����?", 3f, true)
            .Show("���̷����ΰ���", 3.5f, true)
            .Show("�ƱͰ� ������ ���� ���� ���� ���븦 ������", 6.5f, true)
            .End();

        QuestPopupUI.Instance.QuestTxt();
    }

    public void BrightFlowerDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("�� �� ���� ã�ҳ�", 4f, true)
            .Show("�� �ɵ� Ư�� ��⸦ �����Ѵٰ� ����", 4f, true)
            .Show("( ���� �ؿ� �ִ� \"����\"�� Ŭ���� ������ Ȯ���� �� �ֽ��ϴ� )", 5f, true)
            .Show("�������� ������ ������ �� ã���� ������?", 5f, true)
            .Show("���� �ⱸ�� ã���� �ǰھ�", 5f, true)
            .End();
    }

    public void OctopusDialogue()
    {
        PlayerChatBoxManager.Instance
            .Show("�ȿ� ��� ����ֳ�?", 3f, true)
            .Show("Ư�� �Һ��� �Ⱦ��Ѵٰ� �ߴ��� ����", 3f, true)
            .Show("�� ���� �̿��ϸ� ��� ���� �ö󰡴� �� �����ٰž�", 5.5f, true)
            .End();
    }
}

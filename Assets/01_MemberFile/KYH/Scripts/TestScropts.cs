using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScropts : MonoBehaviour
{
    private void Start()
    {
        new PlayerChatBoxManager()
            .Show("1��° �ؽ�Ʈ", 3f,true)
            .Show("2��° �ؽ�Ʈ�Դϴ�!!!!!!!!", 3f,true)
            .Show("4��° �ؽ�Ʈ�Դϴ�!!!!!!!!", 3f, true)
            .Show("5��° �ؽ�Ʈ�Դϴ�!!!!!!!!", 3f, true)
            .Show("6��° �ؽ�Ʈ�Դϴ�!!!!!!!!", 3f, true)
            .Show("7��° �ؽ�Ʈ�Դϴ�!!!!!!!!", 3f, true)
            .End();
    }
}

using UnityEngine;

public class PlayerKeyFalse : MonoBehaviour
{
    private int _randNum;

    [field: SerializeField] public bool blockKey { get; set; }
    private PlayerMove _playerMove;

    private void Awake()
    {
        // blockKey = false;
        _randNum = Random.Range(1, 3);
        _playerMove = GetComponent<PlayerMove>();
    }

    private void Start()
    {
        Debug.Log(_randNum);
        if (_randNum == 1)
        {
            Debug.Log("���� ����");
        }
        else if (_randNum == 2)
        {
            Debug.Log("Esc ����");
        }
    }
    private void Update()
    {
        if (Door._currentSceneIndex != 5 || Door._currentSceneIndex >= 3)
            BlockKey(8, 0);
    }

    private void BlockKey(int OriginJumpPower, int BlockJump)
    {
        if (blockKey == true)
        {
            switch (_randNum)
            {
                case 1:
                    _playerMove._jumpSpeed = BlockJump;
                    break;
            }
        }
        else
        {
            OpenControlPanel._isTrue = true;
            _playerMove._jumpSpeed = OriginJumpPower;
        }
    }
}

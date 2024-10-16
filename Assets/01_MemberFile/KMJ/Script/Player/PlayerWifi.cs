using DG.Tweening;
using UnityEngine;

public class PlayerWifi : MonoBehaviour
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Sprite _falseSprite;
    [SerializeField] private ButtonManager _buttonManager;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private SpriteRenderer _spriteCompo;

    private Sequence _mySequence;

    private void Awake()
    {
    }

    private void Start()
    {
        _mySequence = DOTween.Sequence()
                        .Append(transform.DOMove(new Vector3(1f, 0, 0), 0.1f))
                        .Append(transform.DOMove(new Vector3(0, 0, 0), 0.1f))
                        .AppendInterval(1f)
                        .SetLoops(-1, LoopType.Yoyo)
                        .SetAutoKill(false);
    }


    private void OnDisable()
    {
        _mySequence.Pause();
    }

    private void Update()
    {
        WifiTrue(ButtonManager.IsWifiTrue);
    }

    private void WifiTrue(bool IsWifi)
    {
        if (IsWifi == true)
        {
            _spriteCompo.sprite = _sprite;
            _spriteCompo.color = Color.green;
        }
        else if (IsWifi == false)
        {
            _spriteCompo.sprite = _falseSprite;
            _spriteCompo.color = Color.red;
        }
    }

    private void Buffering(bool IsWifi)
    {
        if (IsWifi == false)
            _mySequence.Play();

        if (IsWifi == true)
            _mySequence.Pause();

    }

    private void FixedUpdate()
    {
        Buffering(ButtonManager.IsWifiTrue);
    }
}

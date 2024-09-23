using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BrightPlants : MonoBehaviour
{
    [SerializeField]
    private LuminescentPlants luminescentPlants;
    [SerializeField]
    private Light2D _light;
    private SpriteRenderer _spriteCompo;
    [SerializeField] private PlayerAnimation _playerAnimCompo;

    public int brightStep;

    private int _cut;

    [SerializeField] private Collider2D[] _colliders;

    public Vector2 pos;
    private float size = 3f;
    public ContactFilter2D filter;

    public bool _isReach;
    public bool canPlant;

    [SerializeField]
    private IBrightDetection[] existsNowBrightObj;

    [SerializeField]
    private List<GameObject> _inLightList = new();


    private void Awake()
    {
        _light.intensity = 0;

        luminescentPlants.OnPlants += BrightnessRange;
        luminescentPlants.OnPlants += BrightnessControl;

        _spriteCompo = GetComponent<SpriteRenderer>();

        _colliders = new Collider2D[10];
    }

    private void Start()
    {
        _colliders = new Collider2D[20];

        existsNowBrightObj = GameObject.Find("BrightObjManager").GetComponentsInChildren<IBrightDetection>();
    }

    private void Update()
    {
        PlantRenderer();
    }

    private void BrightnessControl()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 0.4f);
            _light.intensity += 0.1f;
            brightStep = (int)(_light.intensity * 10);
            print(brightStep);
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            _light.intensity = Mathf.Clamp(_light.intensity, 0, 0.4f);
            _light.intensity -= 0.1f;
            brightStep = (int)(_light.intensity * 10);
            print(brightStep);
        }
    }

    //public Collider2D GetBright()
    //{
    //    _cut = Physics2D.OverlapCircleNonAlloc(transform.position, size, _colliders, foothold);
    //    return  _cut > 0 ?_colliders[0] : null;
    //}

    private void BrightnessRange()
    {
        int count = Physics2D.OverlapCircle(transform.position, size, filter, _colliders);

        for (int i = 0; i < count; i++)
        {
            var detector = _colliders[i].GetComponent<IBrightDetection>();
            if(detector != null && !_inLightList.Contains(_colliders[i].gameObject))
                _inLightList.Add(_colliders[i].gameObject);
        }

        CheckInRadius();
    }

    private void CheckInRadius()
    {
        for (int i = 0; i < _inLightList.Count; i++)
        {
            var obj = _inLightList[i];
            var item = obj.GetComponent<IBrightDetection>();
            Debug.Log(item);
            if (Vector2.Distance(item.GameObject.transform.position, transform.position) < size)
            {
                item.BrightnessDetection(true, brightStep);
            }
            else
            {
                item.BrightnessDetection(false, brightStep);
                _inLightList.RemoveAt(i);
                i--;
            }
        }
    }

    void OnDrawGizmos() // 범위 그리기
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, size);
    }

    private void PlantRenderer()
    {
        if (luminescentPlants._isHold)
        {
            _spriteCompo.color = new Color(1, 1, 1, 0);
            _playerAnimCompo.isFlower = true;
        }
        else
        {
            _spriteCompo.color = new Color(1, 1, 1, 1);
            _playerAnimCompo.isFlower = false;
        }
    }
}

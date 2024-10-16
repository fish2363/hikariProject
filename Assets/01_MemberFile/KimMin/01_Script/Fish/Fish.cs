using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fish : MonoBehaviour
{
    public Rigidbody2D RigidCompo { get; private set; }
    public FishMovement MoveCompo { get; protected set; }
    public Animator AnimCompo { get; protected set; }
    public BrightPlants BrightPlant { get; private set; }

    private GameObject _brightObj;

    protected virtual void Awake()
    {
        RigidCompo = GetComponent<Rigidbody2D>();
        MoveCompo = GetComponent<FishMovement>();
        AnimCompo = transform.Find("Visual").GetComponent<Animator>();

        _brightObj = GameObject.Find("Luminescent Plants");
        BrightPlant = _brightObj.transform.Find("Visual").GetComponent<BrightPlants>();
    }

    private bool IsFactingRight()
    {
        return Mathf.Approximately(transform.eulerAngles.y, 0);
    }

    public void SpriteFlip(Vector2 targetPosition)
    {
        bool isRight = IsFactingRight();
        if (targetPosition.x < transform.position.x && isRight)
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
        else if (targetPosition.x > transform.position.x && !isRight)
        {
            transform.eulerAngles = Vector3.zero;
        }
    }

    public void MoveFlip(Vector3 dir)
    {
        if (dir.x > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, -180f, 0);
        }
    }
}

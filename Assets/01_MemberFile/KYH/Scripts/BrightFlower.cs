using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightFlower : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject _collider;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    public void FoldFlower()
    {
        _collider.SetActive(false);
        anim.SetBool("Fold", true);
        print("����");
    }

    public void ExpandFlower()
    {
        _collider.SetActive(true);
        anim.SetBool("Fold", false);
        print("�׽����");
    }
}

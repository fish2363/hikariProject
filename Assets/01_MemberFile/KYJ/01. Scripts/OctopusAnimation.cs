using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusAnimation : MonoBehaviour
{
    [SerializeField] private Animator anim;
    public GameObject _collider;


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

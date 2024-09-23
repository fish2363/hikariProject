using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusAnimation : MonoBehaviour
{
    private Animator anim;
    public BoxCollider2D BrightCollider;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void FoldFlower()
    {
        BrightCollider.isTrigger = true;
        anim.SetBool("Fold", true);
        print("����");
    }

    public void ExpandFlower()
    {
        BrightCollider.isTrigger = false;
        anim.SetBool("Fold", false);
        print("�׽����");
    }
}

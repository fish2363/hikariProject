using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public interface IBrightDetection
{
    public void BrightnessDetection(bool canPlant, float brightStep);
    public bool isBrightOn { get; set; }
    public GameObject GameObject { get; }
}

public class BrightFoothold : MonoBehaviour, IBrightDetection
{
    public BrightPlants brightPlants;

    public UnityEvent onInvokeBrightObj;
    public UnityEvent offInvokeBrightObj;

    public float brightnessLevel;

    public Action OnBrightnessDetection;

    public bool isTure; // ��������

    public bool isBrightOn { get; set; }
    public GameObject GameObject => gameObject;

    public void BrightnessDetection(bool canPlant, float brightStep)
    {
        if (brightnessLevel == brightStep && canPlant)
        {
            onInvokeBrightObj?.Invoke();
            print("dddd");
        }
        if (brightnessLevel != brightStep || !canPlant)
        {
            offInvokeBrightObj?.Invoke();
        }
    }
}

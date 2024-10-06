using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using DG.Tweening;


public class VIdeoManager : MonoBehaviour
{
    [SerializeField]
    private VideoPlayer introVideo;

    [SerializeField]
    private GameObject introCanvas;

    [SerializeField]
    private GameObject windowVolume;

    [SerializeField]
    private Intro intro;

    [SerializeField]
    private GameObject videoRawImage;
    [SerializeField]
    private GameObject[] testActiveFalse;


    [SerializeField]
    private VideoClip computerClip;
    [SerializeField]
    private GameObject blackPanel;

    [SerializeField]
    private TextMeshProUGUI text;


    private bool sorry;
    private bool sorry2;
    private bool sorry3;
    private bool sorry4;
    private bool sorry5;
    private bool sorry6;


    public void StartHouseVideo()
    {
        introCanvas.SetActive(true);
        introVideo.Play();
    }

    public void StartComputerVideo()
    {
        introVideo.clip = computerClip;
        introVideo.Play();
        StartCoroutine(FrameBugFix());
    }

    private void Update()
    {
        if(introVideo.clip == computerClip)
        {
            if(introVideo.time > 31f)
            {
                intro.BlinkTween();
                introVideo.Stop();
                videoRawImage.SetActive(false);
                windowVolume.SetActive(true);

                for (int i =0; i<testActiveFalse.Length; i++)
                {
                    testActiveFalse[i].SetActive(false);
                }
            }
        }
        else
        {
            if(introVideo.time > 0f && !sorry)
            {
                IntroText();
            }
            if (introVideo.time > 6f && !sorry2)
            {
                FirstIntroText();
            }
            if (introVideo.time > 11f && !sorry3)
            {
                SecondIntroText();
            }
            if (introVideo.time > 18f && !sorry4)
            {
                ThirdIntroText();
            }
            if (introVideo.time > 25f)
            {
                blackPanel.SetActive(true);
                StartCoroutine(BlackPanelWateRoutine());
                text.gameObject.SetActive(false);
            }
        }
    }

    public void IntroText()
    {
        if (!sorry)
        {
            sorry = true;
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    public void FirstIntroText()
    {
        if(!sorry2)
        {
            sorry2 = true;
            text.text = "���� ���� �����ؾ߰���?";
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    public void SecondIntroText()
    {
        if (!sorry3)
        {
            sorry3 = true;
            text.text = "�̹����� ������ ������ �� ��� ������";
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    public void ThirdIntroText()
    {
        if (!sorry4)
        {
            sorry4 = true;
            text.text = "�׳� ���� ����������";
            text.TextUpDownMove(3f, Color.white, 2.5f, TextStyle.FadeIn | TextStyle.UI);
        }
    }

    private IEnumerator BlackPanelWateRoutine()
    {
        yield return new WaitForSeconds(2f);
        StartComputerVideo();
    }

    private IEnumerator FrameBugFix()
    {
        yield return new WaitForSeconds(0.3f);
        blackPanel.SetActive(false);
    }
}

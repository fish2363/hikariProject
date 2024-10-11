using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowChange : MonoBehaviour
{
    private RawImage rawImage;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
        rawImage.texture = BGManager.Instance.GetPCWallpaper();
    }

    private void Start()
    {
        //texture = BGManager.Instance.GetPCWallpaper();

        //Rect rect = new Rect(0, 0, texture.width, texture.height);
        //Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        //spriteRenderer.sprite = sprite;
    }
}

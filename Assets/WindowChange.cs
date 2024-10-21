using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowChange : MonoBehaviour
{
    private RawImage rawImage;
    public Texture2D defaultTexture;

    private void Awake()
    {
        rawImage = GetComponent<RawImage>();
        rawImage.texture = BGManager.Instance.GetPCWallpaper();
        if (rawImage.texture == null)
            rawImage.texture = defaultTexture;
    }

    private void Start()
    {
        //texture = BGManager.Instance.GetPCWallpaper();

        //Rect rect = new Rect(0, 0, texture.width, texture.height);
        //Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f));

        //spriteRenderer.sprite = sprite;
    }
}

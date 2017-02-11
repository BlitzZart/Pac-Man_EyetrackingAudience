using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderBytes : MonoBehaviour {
    private static RenderBytes instance;
    public static RenderBytes Instance { get { return instance; } }

    private SpriteRenderer sprite;

    void Awake()
    {
        instance = this;
    }

    void Start () {
        sprite = GetComponent<SpriteRenderer>();
    }


    public void Render(byte[] bytes)
    {
        Texture2D loadTex = new Texture2D(ScreenCapturing.imageSize, ScreenCapturing.imageSize, TextureFormat.RGB24, false);
        loadTex.filterMode = FilterMode.Point;
        loadTex.LoadImage(bytes);

        sprite.sprite = Sprite.Create(loadTex, new Rect(0, 0, loadTex.width, loadTex.height), new Vector2(0.5f, 0.5f));
    }
}

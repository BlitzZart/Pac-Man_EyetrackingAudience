using UnityEngine;

public class ScreenCapturing : MonoBehaviour {
    public Camera streamCamera;
    //private SpriteRenderer sprite;

    float rate = 0.1f;
    float current = 0;

    public static int imageSize = 320;

    // Use this for initialization
    void Start () {
        //DontDestroyOnLoad(gameObject);
        Initialize();
    }
	
	// Update is called once per frame
	void Update () {
        if (current < rate)
        {
            current += Time.deltaTime;
        } else
        {
            SendByteStream();
            current = 0;
        }
    }

    private void SendByteStream()
    {
        if (Communicator.Player == null)
        {
            //RenderBytes.Instance.Render(ReadSprite());
            //Debug.LogError("NO Player");
            return;
        }

        if (!Communicator.Player.isServer)
            return;

        //Communicator.Player.RpcSendByteStream(ReadSprite());
    }

    private void Initialize()
    {
        RenderTexture tempRT = new RenderTexture(imageSize, imageSize, 8);
        tempRT.filterMode = FilterMode.Point;
        // the "24" can be 0,16,24 or formats like RenderTextureFormat.Default, ARGB32 etc.

        streamCamera.targetTexture = tempRT;
        streamCamera.Render();

        RenderTexture.active = tempRT;
        Texture2D virtualPhoto = new Texture2D(imageSize, imageSize, TextureFormat.RGB24, false);
        virtualPhoto.filterMode = FilterMode.Point;
        // false, meaning no need for mipmaps
        virtualPhoto.ReadPixels(new Rect(0, 0, imageSize, imageSize), 0, 0); // you get the center section

        RenderTexture.active = null; // "just in case" 
        streamCamera.targetTexture = null;
        //////Destroy(tempRT); - tricky on android and other platforms, take care

        byte[] bytes;
        bytes = virtualPhoto.EncodeToJPG();

        //Texture2D loadTex = new Texture2D(sqr, sqr, TextureFormat.RGB24, false);
        //loadTex.LoadImage(bytes);

        //sprite.sprite = Sprite.Create(loadTex, new Rect(0, 0, loadTex.width, loadTex.height), new Vector2(0.5f, 0.5f));
    }

    private byte[] ReadSprite()
    {
        RenderTexture tempRT = new RenderTexture(imageSize, imageSize, 24);
        tempRT.filterMode = FilterMode.Point;
        // the "24" can be 0,16,24 or formats like RenderTextureFormat.Default, ARGB32 etc.

        streamCamera.targetTexture = tempRT;
        streamCamera.Render();

        RenderTexture.active = tempRT;
        Texture2D virtualPhoto = new Texture2D(imageSize, imageSize, TextureFormat.RGB24, false);
        virtualPhoto.filterMode = FilterMode.Point;

        // false, meaning no need for mipmaps
        virtualPhoto.ReadPixels(new Rect(0, 0, imageSize, imageSize), 0, 0); // you get the center section

        RenderTexture.active = null; // "just in case" 
        streamCamera.targetTexture = null;
        //////Destroy(tempRT); - tricky on android and other platforms, take care

        byte[] bytes;
        bytes = virtualPhoto.EncodeToPNG();

        //print(bytes.Length);

        //Texture2D loadTex = new Texture2D(sqr, sqr, TextureFormat.RGB24, false);
        //loadTex.LoadImage(bytes);

        //sprite.sprite = Sprite.Create(loadTex, new Rect(0, 0, loadTex.width, loadTex.height), new Vector2(0.5f, 0.5f));

        return bytes;
    }
}

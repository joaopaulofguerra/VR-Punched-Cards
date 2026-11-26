using UnityEngine;

public class CardData
{
    public const int DIGIT_COUNT = 5;
    public const int COLUMN_COUNT = 12;

    public Texture2D texture { get; private set; }

    public CardData()
    {
        texture = new Texture2D(COLUMN_COUNT, DIGIT_COUNT, TextureFormat.RGB24, false, true);
        texture.filterMode = FilterMode.Point;
        texture.wrapMode = TextureWrapMode.Clamp;
        ClearTexture();
    }

    void ClearTexture()
    {
        Color[] pixels = texture.GetPixels();

        for (var i = 0; i < pixels.Length; ++i)
        {
            pixels[i] = Color.white;
        }

        texture.SetPixels(pixels);
        texture.Apply();
    }
}
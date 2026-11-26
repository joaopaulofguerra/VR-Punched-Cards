using UnityEngine;

public class Card : MonoBehaviour
{
    [Header("Références")]
    [SerializeField] Renderer holeFillRenderer;

    [Header("Dimensions de la carte")]
    [SerializeField] float cardWidth = 0.75f;
    [SerializeField] float cardHeight = 0.3f;

    CardData cardData;

    void Start()
    {
        cardData = new CardData();
        holeFillRenderer.material.SetTexture("_HoleTex", cardData.texture);
    }

    public void SetHole(int column, int row, bool punched)
    {
        if (column < 0 || column >= CardData.COLUMN_COUNT) return;
        if (row < 0 || row >= CardData.DIGIT_COUNT) return;

        Color color;
        if (punched)
        {
            color = Color.black;
        }
        else
        {
            color = Color.white;
        }

        cardData.texture.SetPixel(column, row, color);
        cardData.texture.Apply();
    }

    public void Punch(Vector3 worldPosition)
    {
        Vector3 localPoint = transform.InverseTransformPoint(worldPosition);
        int column = Mathf.FloorToInt((0.5f - localPoint.x / cardWidth) * CardData.COLUMN_COUNT);
        int row = Mathf.FloorToInt((localPoint.y / cardHeight + 0.5f) * CardData.DIGIT_COUNT);

        Debug.Log("Punch calculé : column=" + column + " row=" + row);

        SetHole(column, row, true);
    }
}
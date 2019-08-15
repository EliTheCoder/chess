using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChessObject : MonoBehaviour
{
    public Vector4 matrixPosition;
    protected bool selected;
    protected Color color;
    protected SpriteRenderer spriteRenderer;
    

    // Don't forget to remove your temporary code :p

    public void Initialize(Vector4 pos)
    {
        matrixPosition = pos;
        transform.position = new Vector3( matrixPosition.x + ( (matrixPosition.z - 1) * Grandmaster.instance.boardSpacing ) + ((matrixPosition.z - 1) * Grandmaster.instance.boardSize.x), matrixPosition.y + ( (matrixPosition.w - 1) * Grandmaster.instance.boardSpacing ) + ((matrixPosition.w - 1) * Grandmaster.instance.boardSize.y), 0);
        UpdateColor();
    }

    public void Select()
    {
        spriteRenderer.color = Color.Lerp(color, Grandmaster.instance.selectColor, 0.3f);
        selected = true;
    }
    
    public void Deselect()
    {
        spriteRenderer.color = color;
        selected = false;
    }

    public bool isSelected()
    {
        return selected;
    }

    protected void UpdateColor()
    {
        color = CalculateColor();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;
    }

    public abstract Color CalculateColor();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Cell : MonoBehaviour
{
    const float m_separation = 0.25f;
    public static float Separation => m_separation;

    MeshRenderer m_meshRenderer;

    [SerializeField]
    int m_posX;
    [SerializeField]
    int m_posY;

    private void Awake()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        GetCellPosition();
    }

    public Vector2 GetCellSize()
    {
        float sizeX = transform.localScale.x + m_separation;
        float sizeZ = transform.localScale.z + m_separation;

        return new Vector2(sizeX, sizeZ);
    }

    public Vector2Int GetCellCoords()
    {
        return new Vector2Int(m_posX, m_posY);
    }

    public Vector2 GetCellPosition()
    {
        Vector2 cellSize = GetCellSize();

        float posX = transform.localPosition.x;
        float posZ = transform.localPosition.z;

        m_posX = Mathf.RoundToInt(posX / cellSize.x);
        m_posY = Mathf.RoundToInt(posZ / cellSize.y);

        float positionX = m_posX * cellSize.x;
        float positionZ = m_posY * cellSize.y;

        return new Vector2(positionX, positionZ);
    }

    public void ChangeColor(Color color)
    {
        m_meshRenderer.materials[0].color = color;
    }
}

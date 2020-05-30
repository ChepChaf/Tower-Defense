using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Cell))]
public class SnapEditor : MonoBehaviour
{
    TextMeshPro m_CoordsText;
    Cell m_cell;

    float m_positionXSnap;
    float m_positionZSnap;

    private void Awake()
    {
        m_cell = GetComponent<Cell>();
    }

    private void Start()
    {
        m_CoordsText = GetComponentInChildren<TextMeshPro>();
    }
    void Update()
    {
        SnapCell();
        RenameCell();
    }

    private void SnapCell()
    {
        Vector2 cellCoords = m_cell.GetCellPosition();

        m_positionXSnap = cellCoords.x;
        m_positionZSnap = cellCoords.y;

        transform.localPosition = new Vector3(cellCoords.x, transform.localPosition.y, cellCoords.y);
    }

    private void RenameCell()
    {
        Vector2Int cellCoords = m_cell.GetCellCoords();

        string coords = cellCoords.x + "," + cellCoords.y;
        m_CoordsText.text = coords;
        gameObject.name = coords;
    }
}

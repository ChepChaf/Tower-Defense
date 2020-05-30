using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Cell> m_cells = new Dictionary<Vector2Int, Cell>();

    private void Start()
    {
        LoadCells();
    }

    private void LoadCells()
    {
        Cell[] cells = GetComponentsInChildren<Cell>();

        foreach (Cell cell in cells)
        {
            if (m_cells.ContainsKey(cell.GetCellCoords()))
            {
                Debug.LogError("m_cells contains: " + cell.GetCellCoords().ToString());
            } 
            else
            {
                m_cells.Add(cell.GetCellCoords(), cell);
                cell.ChangeColor();
            }
            
        }

        Debug.Log(m_cells.Count + " cells in m_cells.");
    }
}

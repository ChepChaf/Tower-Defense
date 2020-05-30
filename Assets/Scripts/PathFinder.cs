using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Cell> m_cells = new Dictionary<Vector2Int, Cell>();

    [SerializeField]
    Cell m_beginOfPath;
    [SerializeField]
    Color m_colorOfBegin;
    [SerializeField]
    Cell m_endOfPath;
    [SerializeField]
    Color m_colorOfEnd;

    private void Start()
    {
        StartCoroutine(LoadCells());
    }

    private IEnumerator LoadCells()
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
                cell.ChangeColor(Color.red);
            }
            yield return new WaitForSeconds(0.1f);
        }

        m_beginOfPath.ChangeColor(m_colorOfBegin);
        m_endOfPath.ChangeColor(m_colorOfEnd);

        Debug.Log(m_cells.Count + " cells in m_cells.");
    }
}

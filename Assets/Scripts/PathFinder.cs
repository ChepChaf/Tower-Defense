using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class PathFinder : MonoBehaviour
{
    Dictionary<Vector2Int, Cell> m_cells = new Dictionary<Vector2Int, Cell>();

    [SerializeField]
    Cell m_beginOfPath;
    //[SerializeField]
    //Color m_colorOfBegin;
    [SerializeField]
    Cell m_endOfPath;
    //[SerializeField]
    //Color m_colorOfEnd;

    Vector2Int[] m_directions = { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    Stack<Cell> m_path = new Stack<Cell>();

    private void Start()
    {
        LoadCells();
        StartCoroutine(CalculatePathToEnd());
    }

    private IEnumerator ColorPath(Stack<Cell> path, Color color)
    {
        while (path.Count > 0)
        {
            Cell cell = path.Pop();
            cell.ChangeColor(color);
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void PrintQueue(Queue<Cell> queue)
    {
        List<Cell> cells = queue.ToList<Cell>();

        string output = "Queue: ";

        foreach (Cell cell in cells)
        {
            output += cell.GetCellCoords() + " - ";
        }
        Debug.Log(output);
    }

    private IEnumerator CalculatePathToEnd()
    {
        Queue<Cell> toVisit = new Queue<Cell>();
        toVisit.Enqueue(m_beginOfPath);

        while (toVisit.Count > 0)
        {
            // PrintQueue(toVisit);
            Cell current = toVisit.Dequeue();

            if (current.m_visited)
                continue;

            current.ChangeColor(Color.green);
            yield return new WaitForSeconds(0.1f);

            if (current == m_endOfPath)
            {
                while (current.m_previousCell != null)
                {
                    m_path.Push(current);
                    current = current.m_previousCell;
                }

                break;
            }

            current.m_visited = true;

            List<Cell> cellNeighbors = CalculateNeighborhoods(current);

            foreach (Cell neighbor in cellNeighbors)
            {
                if (!neighbor.m_visited)
                {
                    neighbor.m_previousCell = current;

                    neighbor.ChangeColor(Color.blue);
                    yield return new WaitForSeconds(0.1f);

                    toVisit.Enqueue(neighbor);
                }
            }

            current.ChangeColor(Color.red);
            yield return new WaitForSeconds(0.1f);
        }

        yield return ColorPath(m_path, Color.yellow);
    }

    private List<Cell> CalculateNeighborhoods(Cell cell)
    {
        List<Cell> neighbors = new List<Cell>();

        foreach (Vector2Int direction in m_directions)
        {
            Vector2Int coordInDirection = cell.GetCellCoords() + direction;
            if (m_cells.ContainsKey(coordInDirection))
            {
                neighbors.Add(m_cells[coordInDirection]);
            }
        }

        return neighbors;
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
                cell.ChangeColor(Color.white);
            }
        }


        Debug.Log(m_cells.Count + " cells in m_cells.");
    }
}

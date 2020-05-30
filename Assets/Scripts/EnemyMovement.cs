using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    List<Cell> m_path = new List<Cell>();

    private void Start()
    {
        StartCoroutine(PrintPath());
    }

    IEnumerator PrintPath()
    {
        Debug.Log("Enemy: Starting path");
        foreach (Cell cell in m_path)
        {
            Debug.Log("Cell: " + cell.ToString());
            transform.position = cell.transform.position;
            yield return new WaitForSeconds(1.0f);
        }
        Debug.Log("Enemy: Finihed path");
    }
}

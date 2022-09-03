using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMapGenerator : MonoBehaviour
{
    [SerializeField] private GameObject prefabCell;
    [SerializeField] private int gridSize;
    [SerializeField] private float cellSize;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCells(20, 1f, prefabCell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateGrid()
    {
        SpawnCells(gridSize, cellSize, prefabCell);
    }

    private void SpawnCells(int size, float cellSize, GameObject prefabCell)
    {
        RemoveChildren();
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var cellPosition = new Vector3(j * cellSize, 0f, i * cellSize);
                var newCell = Instantiate(prefabCell, cellPosition, prefabCell.transform.rotation);
                newCell.transform.parent = transform;
                newCell.name = "Cell_" + i + "_" + j;
            }
        }
    }

    private void RemoveChildren()
    {
        foreach (Transform child in transform)
        {
            DestroyImmediate(child.gameObject);
        }
    }
}

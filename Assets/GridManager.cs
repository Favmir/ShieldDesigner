using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    [SerializeField] private Tile _tilePrefab;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        
    }
    void GenerateGrid()
    {
        var startX = -_width / 2 + 0.5f;
        var startY = -_height / 2 + 0.5f;
        for (int x = 0; x < _width; x++)
        {
            for (int y = 0; y < _height; y++)
            {
                var tile = Instantiate(_tilePrefab, new Vector3(startX+x, startY+y, 0), Quaternion.identity);
                tile.transform.SetParent(transform);
                // set tile name as coordinate
                tile.name = $"tile{x}{y}";
                
            }
        }
    }
}

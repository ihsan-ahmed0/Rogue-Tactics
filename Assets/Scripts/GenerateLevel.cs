using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateLevel : MonoBehaviour
{
    [Header("Grass Tile Prefabs")]
    [SerializeField] GameObject GrassTile1;
    [SerializeField] GameObject GrassTile2;
    [SerializeField] GameObject GrassTile3;
    [SerializeField] GameObject GrassTile4;
    [SerializeField] GameObject GrassTile5;
    [SerializeField] GameObject GrassTile6;
    [SerializeField] GameObject GrassTile7;
    [SerializeField] GameObject GrassTile8;
    [SerializeField] GameObject GrassTile9;
    [SerializeField] GameObject GrassTile10;

    // Dimensions of the level grid.
    private int gridWidth = 10;
    private int gridLength = 10;

    // Width and height of a single tile sprite (in pixels).
    private int tileWidth = 64;
    private int tileHeight = 64;

    // The inverse of the ppi of the sprites being used for the tiles.
    private float ppiInverse = 0.01f;

    private GameObject[,] grid;

    private int[,] tileHeights = new int[10, 10] {
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };

    private void RenderGrid()
    {
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridLength; j++)
            {
                float x = (0.5f * tileWidth * i - 0.5f * tileWidth * j) * ppiInverse;
                float y = (0.25f * tileHeight * i + 0.25f * tileHeight * j) * ppiInverse;

                if (tileHeights[i , j] == 1)
                {
                    grid[i, j] = Instantiate(GrassTile1, transform);
                    grid[i, j].transform.localPosition = new Vector3(x, y, y);
                }
            }
        }
    }

    private void OnValidate()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        grid = new GameObject[gridWidth, gridLength];

        RenderGrid();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

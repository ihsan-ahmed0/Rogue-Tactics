using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GenerateLevel1 : MonoBehaviour
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

    [Header("Position of the Grid")]
    [SerializeField] float xOffset = 0;
    [SerializeField] float yOffset = -1.45f;

    // Dimensions of the level grid.
    private int gridWidth = 10;
    private int gridLength = 10;

    // Width and height of a single tile sprite (in pixels).
    private int tileWidth = 64;
    private int tileHeight = 64;

    // The inverse of the pixels per unit (ppu) of the sprites being used for the tiles.
    private float ppuInverse = 0.01f;

    private GameObject[,] grid;

    private int[,] tileHeights = new int[10, 10] {
        {3, 2, 1, 1, 1, 8, 7, 6, 6, 6},
        {3, 2, 1, 1, 1, 8, 7, 6, 6, 6},
        {3, 2, 1, 1, 1, 8, 7, 6, 6, 6},
        {3, 2, 1, 1, 1, 2, 3, 4, 5, 5},
        {3, 2, 1, 1, 1, 2, 3, 4, 5, 5},
        {3, 2, 1, 1, 1, 2, 3, 4, 5, 5},
        {3, 2, 1, 1, 1, 2, 3, 4, 5, 5},
        {3, 2, 1, 1, 1, 8, 7, 6, 6, 6},
        {3, 2, 1, 1, 1, 8, 7, 6, 6, 6},
        {3, 2, 1, 1, 1, 8, 7, 6, 6, 6}
    };

    // Function that renders the tiles of the current level.
    private void RenderGrid()
    {
        float sizeIncrement = 8 * ppuInverse;

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridLength; j++)
            {
                float x = (0.5f * tileWidth * i - 0.5f * tileWidth * j) * ppuInverse;
                float y = (0.25f * tileHeight * i + 0.25f * tileHeight * j) * ppuInverse;

                // Choose the correct tile based on the specified tile height.
                if (tileHeights[i , j] == 1)
                {
                    grid[i, j] = Instantiate(GrassTile1, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + yOffset, y);
                }
                else if (tileHeights[i, j] == 2)
                {
                    grid[i, j] = Instantiate(GrassTile2, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 3)
                {
                    grid[i, j] = Instantiate(GrassTile3, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (2 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 4)
                {
                    grid[i, j] = Instantiate(GrassTile4, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (3 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 5)
                {
                    grid[i, j] = Instantiate(GrassTile5, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (4 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 6)
                {
                    grid[i, j] = Instantiate(GrassTile6, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (5 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 7)
                {
                    grid[i, j] = Instantiate(GrassTile7, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (6 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 8)
                {
                    grid[i, j] = Instantiate(GrassTile8, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (7 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 9)
                {
                    grid[i, j] = Instantiate(GrassTile9, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (8 * sizeIncrement) + yOffset, y);
                }
                else if (tileHeights[i, j] == 10)
                {
                    grid[i, j] = Instantiate(GrassTile10, transform);
                    grid[i, j].transform.localPosition = new Vector3(x + xOffset, y + (9 * sizeIncrement) + yOffset, y);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        grid = new GameObject[gridWidth, gridLength];

        RenderGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

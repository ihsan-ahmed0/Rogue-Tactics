using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class PreviewLevel1 : MonoBehaviour
{
    [Header("Position of the Grid")]
    [SerializeField] float xOffset = 0;
    [SerializeField] float yOffset = -1.8f;

    // Dimensions of the level grid.
    private int gridWidth = 10;
    private int gridLength = 10;

    // Width and height of a single tile sprite (in pixels).
    private int tileWidth = 64;
    private int tileHeight = 64;

    // The inverse of the pixels per unit (ppu) of the sprites being used for the tiles.
    private float ppuInverse = 0.01f;

    private LevelGrid level1Grid;

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
    private void CreateGrid()
    {

        float sizeIncrement = 8 * ppuInverse;

        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridLength; j++)
            {
                float x = (0.5f * tileWidth * i - 0.5f * tileWidth * j) * ppuInverse;
                float y = (0.25f * tileHeight * i + 0.25f * tileHeight * j) * ppuInverse;

                // Create GaemObject that will define which type of tile will be generated.
                GameObject tileGameObject;

                // Choose the correct tile based on the specified tile height.
                if (tileHeights[i, j] == 1)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile1") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 2)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile2") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 3)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile3") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 4)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile4") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 5)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile5") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 6)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile6") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 7)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile7") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 8)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile8") as GameObject, transform);
                }
                else if (tileHeights[i, j] == 9)
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile9") as GameObject, transform);
                }
                else
                {
                    tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile10") as GameObject, transform);
                }

                // Create new Tile class instance and calculate the position of the tile.
                Tile newTile;
                Vector3 tilePosition = new Vector3(x + xOffset, y + ((tileHeights[i, j] - 1) * sizeIncrement) + yOffset, y);

                // Instantiate tile GameObject.
                tileGameObject.transform.localPosition = tilePosition;
                
                // Instantiate tile class.
                newTile = new Tile(
                    tileHeights[i, j],
                    tileGameObject.GetComponent<SpriteRenderer>().size.y,
                    tilePosition
                );

                // Place tile in the LevelGrid.
                level1Grid.SetTileAt(i, j, newTile);
            }
        }
    }

#if UNITY_EDITOR
    // Start is called before the first frame update
    void Start()
    {

        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        level1Grid = new LevelGrid();
        level1Grid.InitializeGrid(gridWidth, gridLength);
        level1Grid.SetOffsets(xOffset, yOffset);

        CreateGrid();

        level1Grid.SaveGrid("Level1");

        // Refresh the editor to show the new asset
        AssetDatabase.Refresh();
    }
#endif

    // Update is called once per frame
    void Update()
    {

    }
}

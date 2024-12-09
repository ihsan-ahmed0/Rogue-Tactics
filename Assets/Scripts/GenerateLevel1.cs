using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
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
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile1, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(1);
                }
                else if (tileHeights[i, j] == 2)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile2, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(2);
                }
                else if (tileHeights[i, j] == 3)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile3, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (2 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(3);
                }
                else if (tileHeights[i, j] == 4)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile4, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (3 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(4);
                }
                else if (tileHeights[i, j] == 5)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile5, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (4 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(5);
                }
                else if (tileHeights[i, j] == 6)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile6, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (5 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(6);
                }
                else if (tileHeights[i, j] == 7)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile7, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (6 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(7);
                }
                else if (tileHeights[i, j] == 8)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile8, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (7 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(8);
                }
                else if (tileHeights[i, j] == 9)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile9, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (8 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(9);
                }
                else if (tileHeights[i, j] == 10)
                {
                    level1Grid.SetTileAt(i, j, Instantiate(GrassTile10, transform));
                    level1Grid.GetTileAt(i, j).transform.localPosition = new Vector3(x + xOffset, y + (9 * sizeIncrement) + yOffset, y);
                    level1Grid.GetTileAt(i, j).GetComponent<Tile>().SetHeight(10);
                }
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

        level1Grid = ScriptableObject.CreateInstance<LevelGrid>();
        level1Grid.InitializeGrid(gridWidth, gridLength);

        RenderGrid();

        // Define a path where the the level grid will be saved.
        string folderPath = "Assets/ScriptableObjects";

        // Create the folder if it doesn't exist.
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
        }

        // Create a filename for the asset file where the level grid will be stored.
        string fileName = $"Level1Grid.asset";
        string fullPath = Path.Combine(folderPath, fileName);

        // Create and save the asset file.
        AssetDatabase.CreateAsset(level1Grid, fullPath);
        AssetDatabase.SaveAssets();

        // Refresh the editor to show the new asset
        AssetDatabase.Refresh();
    }
#endif

    // Update is called once per frame
    void Update()
    {
        
    }
}

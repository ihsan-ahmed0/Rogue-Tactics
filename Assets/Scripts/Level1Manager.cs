using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    private LevelGrid level1;
    private GameObject[,] tileObjects;

    private GameObject PlaceTile(Tile tile)
    {
        // Create GaemObject that will define which type of tile will be generated.
        GameObject tileGameObject;

        // Choose the correct tile based on the specified tile height.
        if (tile.GetHeight() == 1)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile1") as GameObject, transform);
        }
        else if (tile.GetHeight() == 2)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile2") as GameObject, transform);
        }
        else if (tile.GetHeight() == 3)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile3") as GameObject, transform);
        }
        else if (tile.GetHeight() == 4)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile4") as GameObject, transform);
        }
        else if (tile.GetHeight() == 5)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile5") as GameObject, transform);
        }
        else if (tile.GetHeight() == 6)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile6") as GameObject, transform);
        }
        else if (tile.GetHeight() == 7)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile7") as GameObject, transform);
        }
        else if (tile.GetHeight() == 8)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile8") as GameObject, transform);
        }
        else if (tile.GetHeight() == 9)
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile9") as GameObject, transform);
        }
        else
        {
            tileGameObject = Instantiate(Resources.Load("Prefabs/GrassTile10") as GameObject, transform);
        }

        tileGameObject.transform.localPosition = tile.GetTilePosition();

        return tileGameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }

        level1 = new LevelGrid();
        level1.LoadGrid("Level1");
        tileObjects = new GameObject[level1.GetRows(), level1.GetCols()];

        for (int i = 0; i < level1.GetRows(); i++)
        {
            for (int j = 0; j < level1.GetCols(); j++)
            {
                tileObjects[i, j] = PlaceTile(level1.GetTileAt(i, j));
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Manager : MonoBehaviour
{
    private LevelGrid level1;
    private GameObject[,] tileObjects;
    private List<PlayerUnit> playerUnits;
    private List<EnemyUnit> enemyUnits;
    private int cursorX;
    private int cursorY;
    private Color originalTileColor;

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

    private void ManageTileCursorInputs()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if (cursorY < tileObjects.GetLength(0) - 1)
            {
                cursorY++;
            }
            if (cursorX < tileObjects.GetLength(1) - 1)
            {
                cursorX++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if ((cursorY % 2 == 0 && cursorX % 2 == 0) || (cursorY % 2 != 0 && cursorX % 2 != 0))
            {
                if (cursorY < tileObjects.GetLength(0) - 1)
                    cursorY++;
                else if (cursorX > 0)
                    cursorX--;
            }
            else
            {
                if (cursorX > 0)
                    cursorX--;
                else if (cursorY < tileObjects.GetLength(0) - 1)
                    cursorY++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if (cursorY > 0)
            {
                cursorY--;
            }
            if (cursorX > 0)
            {
                cursorX--;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = originalTileColor;

            if ((cursorY % 2 == 0 && cursorX % 2 == 0) || (cursorY % 2 != 0 && cursorX % 2 != 0))
            {
                if (cursorX < tileObjects.GetLength(1) - 1)
                    cursorX++;
                else if (cursorY > 0)
                    cursorY--;
            }
            else
            {
                if (cursorY > 0)
                    cursorY--;
                else if (cursorX < tileObjects.GetLength(1) - 1)
                    cursorX++;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // Todo: logic for selecting unit
            Debug.Log($"Selected tile at position ({cursorX},{cursorY})");
            Unit unit = level1.GetTileAt(cursorX, cursorY).GetOccupyingUnit();
            SelectionManager.Instance.SelectUnit(unit);
        }
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
        playerUnits = new List<PlayerUnit>();
        enemyUnits = new List<EnemyUnit>();

        for (int i = 0; i < level1.GetRows(); i++)
        {
            for (int j = 0; j < level1.GetCols(); j++)
            {
                tileObjects[i, j] = PlaceTile(level1.GetTileAt(i, j));
            }
        }

        cursorX = 0;
        cursorY = 0;
        originalTileColor = tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color;

        // Todo: Place units.
        playerUnits.Add(Instantiate(Resources.Load("Prefabs/Unit/Warrior") as GameObject, transform).GetComponent<PlayerUnit>());
        playerUnits[0].Init("Gerald", ClassType.Warrior);
        // initialize each playerUnit
        level1.GetTileAt(2, 3).SetOccupyingUnit(playerUnits[0]);
        Vector3[] unitPosition = { level1.GetTileAt(2, 3).GetUnitPosition() };
  
        playerUnits[0].Move(unitPosition);
    }

    public LevelGrid GetLevel() => level1;

    // Update is called once per frame
    void Update()
    {
        tileObjects[cursorX, cursorY].GetComponent<Renderer>().material.color = new Color(0.17f, 0.68f, 1.0f, 1.0f);
        ManageTileCursorInputs();
    }
}

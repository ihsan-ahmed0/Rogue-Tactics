using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LevelGrid : ScriptableObject
{
    private GameObject[,] tileGrid; // Grid of all of the tiles used in the level.

    // Variables to make sure a coordinate out of bounds of the tile grid is never accessed.
    private int rows;
    private int columns;

    // Method to initialize the grid. Should only be called once after the LevelGrid is created.
    public void InitializeGrid(int rows, int columns)
    {
        if (tileGrid == null)
        {
            tileGrid = new GameObject[rows, columns];
            this.rows = rows;
            this.columns = columns;
        }
        else
        {
            Debug.LogError("This LevelGrid has already been initialized!");
        }
    }

    // Method to set the tile at specific coordinates on the tile grid.
    // Returns true if tile is successfully added, and returns false otherwise.
    public bool SetTileAt(int row, int col, GameObject tile)
    {
        if (tileGrid == null)
        {
            Debug.LogError("LevelGrid is not initialized!");
            return false;
        }

        if (tile.GetComponent<Tile>() == null)
        {
            Debug.LogError("Game objects must be Tiles to be added to the LevelGrid.");
            return false;
        }

        if (row < 0 || row >= rows || col < 0 || col >= columns)
        {
            Debug.LogError("Inputted coordinates are out of the LevelGrid bounds.");
            return false;
        }

        tileGrid[row, col] = tile;
        return true;
    }

    // Method to get a tile from specific coordinates on the tile grid.
    public GameObject GetTileAt(int row, int col)
    {
        if (tileGrid == null)
        {
            Debug.LogError("LevelGrid not initialized!");
            return null;
        }

        if (row < 0 || row >= rows || col < 0 || col >= columns)
        {
            Debug.LogError("Inputted coordinates are out of the LevelGrid bounds.");
            return null;
        }

        return tileGrid[row, col];
    }

    // Method to get the number of rows in the tile grid.
    public int GetRows()
    {
        if (tileGrid == null)
        {
            Debug.LogError("The LevelGrid needs to be initialized first!");
            return -1;
        }

        return rows;
    }

    // Method to get the number of columns in the tile grid.
    public int GetCols()
    {
        if (tileGrid == null)
        {
            Debug.LogError("The LevelGrid needs to be initialized first!");
            return -1;
        }

        return columns;
    }
}

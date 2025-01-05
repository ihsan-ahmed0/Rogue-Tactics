using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Serializable]
public class LevelGrid
{
    private Tile[,] tileGrid; // Grid of all of the tiles used in the level.

    // Variables to make sure a coordinate out of bounds of the tile grid is never accessed.
    private int rows;
    private int columns;

    // Variables to adjust the position of the tiles on the fiurst render.
    private float xOffset;
    private float yOffset;

    // Method to initialize the grid. Should only be called once after the LevelGrid is created.
    public void InitializeGrid(int rows, int columns)
    {
        if (tileGrid == null)
        {
            tileGrid = new Tile[rows, columns];
            this.rows = rows;
            this.columns = columns;
            xOffset = 0;
            yOffset = 0;
        }
        else
        {
            Debug.LogError("This LevelGrid has already been initialized!");
        }
    }

    // Set horizontal and vertical offsets that adjust the position of the LevelGrid when rendered.
    public void SetOffsets(float newXOffset, float newYOffset)
    {
        if (tileGrid == null)
        {
            Debug.LogError("LevelGrid is not initilaized!");
            return;
        }

        xOffset = newXOffset;
        yOffset = newYOffset;
    }

    // Method to set the tile at specific coordinates on the tile grid.
    // Returns true if tile is successfully added, and returns false otherwise.
    public bool SetTileAt(int row, int col, Tile tile)
    {
        if (tileGrid == null)
        {
            Debug.LogError("LevelGrid is not initialized!");
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
    public Tile GetTileAt(int row, int col)
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

    // Method to save the grid data into JSON files.
    public void SaveGrid(string levelName)
    {
        // Define a path where the the level grid will be saved.
        string folderPath = "Assets/LevelData";

        // Create the folder if it doesn't exist.
        if (!AssetDatabase.IsValidFolder(folderPath))
        {
            AssetDatabase.CreateFolder("Assets", "LevelData");
        }

        // Generate the file path were each crucial part of data to recreate the LevelGrid is stored.
        string rowsPath = Path.Combine(folderPath, $"{levelName}Rows.json");
        string colsPath = Path.Combine(folderPath, $"{levelName}Cols.json");
        string heightsPath = Path.Combine(folderPath, $"{levelName}Heights.json");
        string offsetsPath = Path.Combine(folderPath, $"{levelName}Offsets.json");

        // Create 2D array of all of the heights of the Tiles in the LevelGrid for saving.
        int[,] heights = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                heights[i, j] = tileGrid[i, j].GetHeight();
            }
        }

        // Place offset data into a single array for serialization.
        float[] offsetArray = new float[] {xOffset, yOffset};

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        // Serialize the data to JSON.
        string rowsJson = JsonConvert.SerializeObject(rows, settings);
        string colsJson = JsonConvert.SerializeObject(columns, settings);
        string heightsJson = JsonConvert.SerializeObject(heights, settings);
        string offsetsJson = JsonConvert.SerializeObject(offsetArray, settings);

        // Write the JSON data to files.
        File.WriteAllText(rowsPath, rowsJson);
        File.WriteAllText(colsPath, colsJson);
        File.WriteAllText(heightsPath, heightsJson);
        File.WriteAllText(offsetsPath, offsetsJson);

        Debug.Log($"Saved {levelName} grid.");
    }

    // Method to populate grid using data from JSON files.
    // This method will automatically initialize the LevelGrid and populate it with the appropriate Tile data.
    public void LoadGrid(string levelName)
    {
        // Define a path where the the level grid will be saved.
        string folderPath = "Assets/LevelData";

        // Generate the file path were each crucial part of data to recreate the LevelGrid is stored.
        string rowsPath = Path.Combine(folderPath, $"{levelName}Rows.json");
        string colsPath = Path.Combine(folderPath, $"{levelName}Cols.json");
        string heightsPath = Path.Combine(folderPath, $"{levelName}Heights.json");
        string offsetsPath = Path.Combine(folderPath, $"{levelName}Offsets.json");

        // Read JSON files.
        string rowsJson = File.ReadAllText(rowsPath);
        string colsJson = File.ReadAllText(colsPath);
        string heightsJson = File.ReadAllText(heightsPath);
        string offsetsJson = File.ReadAllText(offsetsPath);

        // Deserialize JSON files.
        int newRows = JsonConvert.DeserializeObject<int>(rowsJson);
        int newCols = JsonConvert.DeserializeObject<int>(colsJson);
        int[,] newHeights = JsonConvert.DeserializeObject<int[,]>(heightsJson);
        float[] offsetArray = JsonConvert.DeserializeObject<float[]>(offsetsJson);

        // Initialize LevelGrid with obtained data.
        InitializeGrid(newRows, newCols);
        xOffset = offsetArray[0];
        yOffset = offsetArray[1];


        // Obtain the height different between increments of Tile sizes (which is useful for placing tiles incorrection positons).
        float sizeIncrement = (Resources.Load($"Prefabs/GrassTile2") as GameObject).GetComponent<SpriteRenderer>().size.y * 0.125f;

        // Initialize each tile based on the loaded data and add it to its respective position in the Tile 2D array.
        for (int i = 0; i < newRows; i++)
        {
            for (int j = 0; j < newCols; j++)
            {
                float spriteWidth = (Resources.Load($"Prefabs/GrassTile2") as GameObject).GetComponent<SpriteRenderer>().size.x;
                float spriteHeight = (Resources.Load($"Prefabs/GrassTile2") as GameObject).GetComponent<SpriteRenderer>().size.y;

                float x = (0.5f * i - 0.5f * j) * spriteWidth;
                float y = (0.25f * i + 0.25f * j) * spriteHeight;

                Vector3 tilePosition = new Vector3(x + xOffset, y + ((newHeights[i, j] - 1) * sizeIncrement) + yOffset, y);

                Tile newTile = new Tile(newHeights[i, j], spriteHeight, tilePosition);

                SetTileAt(i, j, newTile);
            }
        }

        Debug.Log($"Loaded {levelName} grid.");
    }
}

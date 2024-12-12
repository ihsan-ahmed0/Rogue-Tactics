using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tile
{
    private int height; // Height of the tile in "half-blocks".
    private float spriteHeight; // Height of the tile sprite this Tile instance is representing (in Unity units).
    private Vector3 tilePosition;
    private GameObject occupyingUnit;

    public Tile(int height, float spriteHeight, Vector3 tilePosition)
    {
        if (height < 1 || height > 10)
        {
            Debug.LogError("Tile height must be an integer in the range of 1-10 (inclusive).");
            return;
        }
        else
        {
            this.height = height;
            this.spriteHeight = spriteHeight;
            this.tilePosition = tilePosition;
        }
    }

    // Return the position where a unit will be when standing on this tile.
    public Vector3 GetUnitPosition()
    {
        if (height == 0)
        {
            Debug.LogError("Tile not initilaized");
            return Vector3.zero;
        }
        else
        {
            return tilePosition + new Vector3(0, spriteHeight * 0.5f, 0);
        }
        
    }

    // Set the new unit currently occupying this tile as long as it is empty.
    public void SetOccupyingUnit(GameObject newUnit)
    {
        if (occupyingUnit == null)
        {
            occupyingUnit = newUnit;
        }
        else
        {
            Debug.LogError("There is already a unit here!");
        }
    }

    // Function to remove the unit occupying this tile if the unit leaves or is defeated.
    public void RemoveOccupyingUnit()
    {
        occupyingUnit = null;
    }

    // Return the height of the tile. If tile is not initialized, a value of 0 will be returned;
    public int GetHeight()
    {
        if (height == 0)
        {
            Debug.LogError("Tile not initialized!");
            return 0;
        }

        return height;
    }
}

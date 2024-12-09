using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Tile : MonoBehaviour
{
    private SpriteRenderer sprite; // Variable to access current sprite size.
    private GameObject occupyingUnit;
    private int height = 0;

    // Return the position where a unit will be when standing on this tile.
    public Vector3 GetUnitPosition()
    {
        return transform.position + new Vector3(0, sprite.size.y * 0.5f, 0);
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

    // Set the height of the current tile. Height can only be set once (usually right after the tile is created).
    public void SetHeight(int height)
    {
        if (this.height == 0)
        {
            this.height = height;
        }
        else
        {
            Debug.LogError("A tile's height can only be set once!");
        }
    }

    // Return the height of the tile.
    public int GetHeight()
    {
        return height;
    }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        occupyingUnit = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{
    [Header("Tiles used for Level Generation")]
    [SerializeField] GameObject tile;

    // Dimensions of the level grid.
    private int gridWidth = 10;
    private int gridHeight = 10;

    // Width and height of a single tile sprite (in pixels).
    private int tileWidth = 64;
    private int tileHeight = 64;

    private float ppiInverse = 0.01f;

    private GameObject[,] grid;


    private void RenderGrid() {
        for (int i = 0; i < gridWidth; i++) {
            for (int j = 0; j < gridHeight; j++) {
                float x = (0.5f * tileWidth * i - 0.5f * tileWidth * j) * ppiInverse;
                float y = (0.25f * tileHeight * i + 0.25f * tileHeight * j) * ppiInverse;
                
                grid[i, j] = Instantiate(tile, new Vector3(x, y, y), Quaternion.identity);
                Instantiate(tile, new Vector3(x, y - 0.25f * tileHeight * ppiInverse, y + 0.0001f), Quaternion.identity);
            }
        }
    }

    // Start is called before the first frame update
    void Start() {
        grid = new GameObject[gridWidth, gridHeight];
        RenderGrid();
    }

    // Update is called once per frame
    void Update() {
        
    }
}

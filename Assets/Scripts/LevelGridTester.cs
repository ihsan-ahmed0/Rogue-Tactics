using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGridTester : MonoBehaviour
{
    [Header("Level Grid Data")]
    [SerializeField] LevelGrid levelGrid;

    // Start is called before the first frame update
    void Start()
    {
        int rows = levelGrid.GetRows();
        int cols = levelGrid.GetCols();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Debug.Log(levelGrid.GetTileAt(i, j).GetComponent<Tile>().GetHeight());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

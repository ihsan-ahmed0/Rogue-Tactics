using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGridTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LevelGrid level1Grid = new LevelGrid();
        level1Grid.LoadGrid("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

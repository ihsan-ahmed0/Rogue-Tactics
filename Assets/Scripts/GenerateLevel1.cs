using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GenerateLevel1 : MonoBehaviour
{
    // Function that renders the tiles of the current level.
    private void RenderGrid()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        while (transform.childCount > 0)
        {
            DestroyImmediate(transform.GetChild(0).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

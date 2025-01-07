using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    [Header("Initial position")]
    [SerializeField] int row;
    [SerializeField] int col;
    void Start()
    {
        //Level1Manager level = GameObject.Find("Level").GetComponent<Level1Manager>();
    }

}

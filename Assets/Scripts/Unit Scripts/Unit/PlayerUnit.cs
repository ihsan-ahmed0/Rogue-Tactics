using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] ClassType classChoice;
    void Start()
    {
        unitClass = ClassCreation.Create(classChoice);
    }

    public UnitClass GetClass() => unitClass;

    // Update is called once per frame
    void Update()
    {
        
    }
}

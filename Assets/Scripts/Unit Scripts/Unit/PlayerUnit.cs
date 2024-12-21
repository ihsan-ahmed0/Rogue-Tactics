using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : Unit
{
    [SerializeField] ClassType classChoice;
    void Start()
    {
        unitClass = ClassCreation.Create(classChoice);
        var unitClass2 = ClassCreation.Create(ClassType.Warrior);

        // Debug.Log(unitClass.ShowStats());
        // unitClass.GetSkill("healthUp").Activate(unitClass);
        // Debug.Log(unitClass.ShowStats());

        Debug.Log(unitClass2.ShowStats());
        unitClass.GetSkill("strength3").Activate(unitClass, unitClass2);
        Debug.Log(unitClass2.ShowStats());

    }

    public UnitClass GetClass() => unitClass;

    // Update is called once per frame
    void Update()
    {
        
    }
}

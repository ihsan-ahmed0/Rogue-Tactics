using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSkill : Skill
{
    /// since buffs are turn-based I'll use events and delgates to notify this class when to revert them
    public BuffSkill(string stat, int mult, string id, ClassType classType)
    {
        attribute = stat;
        multiplier = mult;
        Name = id;
        Type = classType;
    }

    public override void Activate(UnitClass unit)
    {
       unit.AddBonus(attribute, multiplier);
    }

    public override void Activate(List<UnitClass> units)
    {
        foreach (UnitClass unit in units) {
            unit.AddBonus(attribute, multiplier);
        }
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{

    // The Class enum defines the four different types of units.
    public enum Class
    {
        Warrior,
        Rogue,
        Mage,
        Archer
    }

    // The stats for the the unit.
    protected int attack;
    protected int magicAttack;
    protected int defense;
    protected int magicDefense;
    protected int luck;
    protected int movementRange;

    // Other identifying information important for the Unit functions.
    protected Class unitClass;
    protected int maxExp;

    // List of skills that a unit holds.
    protected Skill[] skills;

    protected Unit(Class newUnitClass)
    {
        unitClass = newUnitClass;
        maxExp = 20;

        if (newUnitClass == Class.Warrior)
        {
            attack = 4;
            magicAttack = 2;
            defense = 3;
            magicDefense = 2;
            luck = 7;
            movementRange = 3;
        }
        else if (newUnitClass == Class.Rogue)
        {
            attack = 2;
            magicAttack = 3;
            defense = 1;
            magicDefense = 1;
            luck = 7;
            movementRange = 5;
        }
        else if (newUnitClass == Class.Mage)
        {
            attack = 1;
            magicAttack = 4;
            defense = 3;
            magicDefense = 2;
            luck = 7;
            movementRange = 2;
        }
        else
        {
            attack = 4;
            magicAttack = 2;
            defense = 2;
            magicDefense = 2;
            luck = 7;
            movementRange = 4;
        }
    }
}

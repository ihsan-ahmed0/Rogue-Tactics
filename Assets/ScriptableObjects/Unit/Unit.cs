using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// this class is used as a template for how units behave
/// 
public abstract class Unit : MonoBehaviour
{
    // UnitClass is not a unit. It's the class OF a unit.
    public UnitClass unitClass;

    // I'm guessing another class handles dmg after attack and defend?
    // methods are virtual for more flexibility
    public virtual int Defend(UnitClass stats) => stats.GetStat("Def");
    public virtual int MagDefend(UnitClass stats) => stats.GetStat("Res");
    public virtual int Attack(UnitClass stats) => stats.GetStat("Str");
    public virtual int MagAttack(UnitClass stats) => stats.GetStat("Mag");
}

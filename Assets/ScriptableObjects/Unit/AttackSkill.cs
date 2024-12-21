using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AttackSkill : Skill
{

    public AttackSkill(string stat, int dmg, ClassType type, string id)
    {
        attribute = stat;
        Damage = dmg;
        Type = type;
        Name = id;
    }


    public override void Activate(UnitClass caster, UnitClass target)
    {
        var defStat = "";
        // sees if unit will use physical or magic def stat
        if (attribute.Equals("Str"))
            defStat = "Def";
        else if (attribute.Equals("Mag"))
            defStat = "Res";

        double fixedLvl = caster.Level;
        int randMod = caster.GetStat("Luck") / 10;
        double formula = (0.4 * fixedLvl) + Damage * randMod;

        int dmg = DmgCalc(formula, target.GetStat(defStat));
        target.AddDamage(dmg);
    }

    public int DmgCalc(double damage, int defStat) 
    {
        float calc = (float) damage - defStat;
        var dmg = Mathf.FloorToInt(calc);
        // prevents a negative value from being returned
        dmg = (dmg < 0) ? 0 : dmg;  

        return dmg;
    }
}

using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AttackSkill : Skill
{

    public AttackSkill(string stat, double dmg, ClassType type, string id)
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
        double randMod = (double) caster.GetStat("Luck") / 10;
        double formula = (0.4 * fixedLvl) + caster.GetStat("Str") * Damage;
        Debug.Log(formula);

        int dmg = DmgCalc(formula, target.GetStat(defStat));
        target.AddDamage(dmg);
    }

    public int DmgCalc(double damage, int defStat) 
    {
        float calc = (float) damage - defStat;
        Debug.Log(calc);
        var dmg = Mathf.RoundToInt(calc);
        // prevents a negative value from being returned
        dmg = (dmg < 0) ? 0 : dmg;  

        return dmg;
    }
}

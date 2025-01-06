using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum Condition
{
    Equp,
    Unequip,
    HpLoss
}

public class PassiveSkill : Skill
{
    private Condition[] conditions;

    public PassiveSkill(string skillName, string skillDescription, (SkillEffect, int)[] newSkillEffects, ClassType skillClass) : base(skillName, skillDescription, newSkillEffects, skillClass)
    {

    }

    // This method is called to determine if the condition of a passive skill are met.
    public bool CheckCondition(Condition currentCondition)
    {
        if (conditions.Contains(currentCondition)) {
            return true;
        }
        return false;
    }

    // This method is called whenever the conditions of a passive skill to be activated are met.
    // For some passive skills, the condition is met upon equipping the skill to a unit, while
    // other passive skills activate through a condition that can be met during gameplay.
    public void ActivateEffect()
    {
        // Todo
    }

    // This method is called when a passive skill whose effects are activated on equip is
    // unequipped and the unit loses the effets of the skill.
    public void DeactivateEffect()
    {
        
    }

    public override string GetTypeOfSkill()
    {
        return "PassiveSkill";
    }
}

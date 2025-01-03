using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveSkill : Skill
{

    // Boolean to determine whether a psssive skill activates when it is equipped.
    private bool activateOnEquip;

    public PassiveSkill(string skillName, string skillDescription, (SkillEffect, int)[] newSkillEffects) : base(skillName, skillDescription, newSkillEffects)
    {

    }

    // This method is called to determine if the condition of a passive skill are met.
    public bool Condition()
    {
        // Todo
        return true;
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
        if (activateOnEquip)
        {
            //Todo
        }
        
    }

    public override string GetTypeOfSkill()
    {
        return "PassiveSkill";
    }
}

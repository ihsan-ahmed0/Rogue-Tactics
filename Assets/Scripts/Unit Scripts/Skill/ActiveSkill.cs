using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    public ActiveSkill(string skillName, string skillDescription, (SkillEffect, int)[] newSkillEffects) : base(skillName, skillDescription, newSkillEffects)
    {

    }

    // This method is called whenever an active skill is used by either an enemy AI or the player.
    public void InvokeSkill()
    {
        // Todo
    }

    public override string GetTypeOfSkill()
    {
        return "ActiveSkill";
    }
}

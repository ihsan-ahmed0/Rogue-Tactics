using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSkill : Skill
{
    public ActiveSkill(string skillName, string skillDescription, (SkillEffect, int)[] newSkillEffects, ClassType skillClass) : base(skillName, skillDescription, newSkillEffects, skillClass)
    {

    }

    public override string GetTypeOfSkill()
    {
        return "ActiveSkill";
    }
}

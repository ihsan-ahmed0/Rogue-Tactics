using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

public enum SkillEffect
{
    DMG,
    HP,
    ATK,
    DEF,
    MATK,
    MDEF,
    MOV,
    LCK
}

public abstract class Skill
{
    public string Name { get; protected set; }
    public string Descripion { get; protected set; }
    public ClassType Type { get; protected set; }

    private (SkillEffect, int)[] skillEffects;

    protected Skill(string skillName, string skillDescription, (SkillEffect, int)[] newSkillEffects, ClassType skillClass)
    {
        this.Name = skillName;
        this.Descripion = skillDescription;
        this.skillEffects = newSkillEffects;
        Type = skillClass;
    }

    public (SkillEffect, int)[] GetSkillEffects()
    {
        return skillEffects;
    }

    public virtual string GetTypeOfSkill()
    {
        return "Skill";
    }

    // allows skill objects to be printed like strings
    public override string ToString() {
        return Name + "\n" + Descripion;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Rogue : UnitClass
{ 
    private readonly string[] primaryStats;
    public static List<Skill> Skills { get; private set; }
    public static Dictionary<string, Skill> SkillFinder { get; private set; }
    public Rogue()
    {
        Type = ClassType.Rogue;
        Skills = new List<Skill>();
        Skills = SkillManager.Instance.GetClassSkills(Type);
        SkillFinder = new Dictionary<string, Skill>();
        SkillFinder = CreateSkillFinder(Skills);

        primaryStats = new string[] { "Str", "Luck" };
        // primary stats get a higher bonus than other stats when leveling up
        AddClassBonus();
    }

    protected override void AddClassBonus()
    {
        AddBonus(primaryStats[0], 3);
        AddBonus(primaryStats[1], 3);
    }

    public override void LevelUp()
    {
        Level++;
        AddClassBonus();
        for (int i = 0; i < attributes.Length; i++)
        {
            var stat = attributes[i];
            // stats that are not primary will receive a flat +2
            if (!primaryStats.Contains(stat))
                AddBonus(stat, 2);
        }
    }

    public override Skill GetSkill(string skillName)
    {
        if (SkillFinder.ContainsKey(skillName))
            return SkillFinder[skillName];
        else
            throw new ArgumentException("Invalid skill name, " + nameof(skillName) + " does not exist.");
    }
}

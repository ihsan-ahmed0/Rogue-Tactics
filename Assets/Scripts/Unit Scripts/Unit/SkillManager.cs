using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance {  get; private set; }
    // this will allow us to hardcode skill values in the inspector
    [SerializeField] List<Buff> buffs;
    [SerializeField] List<Attack> attacks;
    // organizes each class to it's own list of skills
    Dictionary<ClassType,List<Skill>> skillSets;
    // array of harcoded special skills
    public readonly string[] specialSkills = {"HPRegen","MPRegen","Ward",
    "ApplyPoision","Sprint","Pierce","KnockBack","LifeSteal","ManaSteal"};

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        skillSets = new Dictionary<ClassType, List<Skill>>();

        var skills = new List<Skill>();
        // create all skills listed in the inspector
        foreach (var buff in buffs)
        {
            var skill = CreateSkill(SkillType.Buff, buff);
            skills.Add(skill);
        }
        foreach (var attack in attacks)
        {
            var skill = CreateSkill(SkillType.Attack, default, attack);
            skills.Add(skill);
        }
        SortClassSkills(skills);
    }


    public static Skill CreateSkill(SkillType type, Buff buff = default, Attack attack = default) => type switch
    {
        SkillType.Buff => new BuffSkill(buff.stat, buff.mult, buff.name, buff.type),
        SkillType.Attack => new AttackSkill(attack.stat, attack.damage, attack.type, attack.name),
        _ => throw new ArgumentException("Invalid skill type", nameof(type))
    };

    public void SortClassSkills(List<Skill> allSkills)
    {
        // group skills by their class
        foreach (var skill in allSkills)
        {
            // if the dict doesn't have an entry for this class, create one
            if (!skillSets.ContainsKey(skill.Type))
            {
                skillSets[skill.Type] = new List<Skill>();
            }

            // add the skill to its corresponding class list
            skillSets[skill.Type].Add(skill);
        }
    }
   
    public List<Skill> GetClassSkills(ClassType type)
    {
        if (skillSets.ContainsKey(type))
            return skillSets[type];
        else throw new ArgumentException("Invalid class type", nameof(type));
    }

    // this navigates the hardcoded special skills that are not template skills
    public void SpecialSelect(string skillName, UnitClass unit, UnitClass enemy=default)
    {
        switch (skillName)
        {
            case "HPRegen":
                HPRegen(unit);
                break;
            case "MPRegen":
                MPRegen(unit);
                break;
            case "Ward":
                Ward(unit);
                break;
            case "ApplyPoison":
                ApplyPoison(unit);
                break;
            case "Sprint":
                Sprint(unit);
                break;
            case "Pierce":
                Pierce(unit);
                break;
            case "KnockBack":
                KnockBack(unit);
                break;
            case "LifeSteal":
                LifeSteal(unit, enemy);
                break;
            case "ManaSteal":
                ManaSteal(unit, enemy);
                break;
            default:
                throw new ArgumentException("Invalid skill type", nameof(skillName));
        }
    }


    private void HPRegen(UnitClass unit)
    {
        unit.AddHealth(1);
    }

    private void MPRegen(UnitClass unit)
    {
        unit.AddMagic(1);
    }

    private void Ward(UnitClass unit)
    {
        unit.ward = unit.GetStat("HP") / 4;
    }

    private void ApplyPoison(UnitClass target)
    {
        target.AddEffect("poison");
    }

    private void Sprint(UnitClass unit)
    {
        unit.AddEffect("sprint");
    }

    private void Pierce(UnitClass unit)
    {
        unit.AddEffect("pierce");
    }

    private void KnockBack(UnitClass unit)
    {
        unit.AddEffect("knockback");
    }

    private void LifeSteal(UnitClass caster, UnitClass target)
    {
        target.AddDamage(5);
        caster.AddHealth(5);
    }

    private void ManaSteal(UnitClass caster, UnitClass target)
    {
        target.DepleteMP(5);
        caster.AddMagic(5);
    }

    public enum SkillType
    {
        Buff,
        Attack,
        Special
    }

    [Serializable]
    public struct Buff
    {
        public string stat;
        public int mult;
        public string name;
        public ClassType type;
    }

    [Serializable]
    public struct Attack
    {
        public string stat;
        public double damage;
        public string name;
        public ClassType type;
    }

}

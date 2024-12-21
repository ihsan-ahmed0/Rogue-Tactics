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


    public enum SkillType
    {
        Buff,
        Attack
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
        public int damage;
        public string name;
        public ClassType type;
    }

}

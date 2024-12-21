using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public abstract class UnitClass
{
    /*
     * This class is abstract because warrior,mage,etc are being implemented as their own classes from what I've seen.
     * Key value pairs are used for stats since they are more effecient.
     */

    protected Dictionary<string, int> stats;
    // changes based on a unit's exp value.
    public int Level { get; protected set; } = 1;
    // the keys for the stat pairing
    protected readonly string[] attributes;
    // used for class creation 
    public ClassType Type { get; protected set; }

    protected UnitClass()
    {
        // Res is mag def and Mag is mag atk. Str and Def are the phys version
        attributes = new string[] { "HP", "MP", "Str", "Mag", "Def", "Res", "Mov","Luck" };
        stats = new Dictionary<string, int>();

        for(int i = 0; i < attributes.Length; i++)
        {
            stats[attributes[i]] = 5; // fill every stat with 5 as a base value during key-value pairing
        }   
    }

    // every class levels differently
    public abstract void LevelUp();
    // every class has different class bonuses
    protected abstract void AddClassBonus();
    // optional custom level up for units that need to have unique stat values
    public virtual void LevelUp(int[] values) 
    {
        // will input values in the order of the attributes constant
        Level++;
        for(int i = 0; i < attributes.Length; i++) {
            stats[attributes[i]] += values[i];
        }
    }

    // helper method for creating a way to store skills by name in all class types
    protected Dictionary<string,Skill> CreateSkillFinder(List<Skill> skills)
    {
        var dict = new Dictionary<string,Skill>();
        foreach(Skill skill in skills) {
            dict[skill.Name] = skill;
        }
        return dict;
    }

    public void AddBonus(string stat, int val) { 
        if (stats.ContainsKey(stat))
        {
            stats[stat] += val;
        }
    }

    public void AddDamage(int dmg)
    {
        stats["HP"] -= dmg;
    }

    public abstract Skill GetSkill(string skillName);

    public string ShowStats()
    {
        string statString = "";
        foreach (var stat in stats)
        {
            statString += $"{stat.Key}: {stat.Value}\n";
        }
        return statString;
    }

    public int GetStat(string stat)
    {
        if (stats.ContainsKey(stat))
            return stats[stat];
        else return 0;
    }
}

public enum ClassType
{
    Mage,
    Warrior,
    Rogue,
    Archer
}

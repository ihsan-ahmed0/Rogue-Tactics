using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public enum ClassType
{
    Warrior,
    Rogue,
    Mage,
    Archer,
    All // This is is equivalent to any class in game logic. Used to make skills compatible with every class.
}


public class UnitData
{
    /*
     * Dictionary that's used to keep track of a unit's various stats. The stat names are abbreviated as follows
     * for convenience:
     * 
     *   HP: Health Points
     *  ATK: Attack
     *  DEF: Defense
     * MATK: Magic Attack
     * MDEF: Magic Defense
     *  LCK: Luck
     *   XP: Experience Points
     *  MXP: Maximum Experience Points (before next level up occurs)
     * 
     */
    private Dictionary<string, int> stats = new Dictionary<string, int>()
    {
        { "HP"   , 0 },
        { "MP"   , 0 },
        { "ATK"  , 0 },
        { "DEF"  , 0 },
        { "MATK" , 0 },
        { "MDEF" , 0 },
        { "MOV"  , 0 },
        { "LCK"  , 0 },
        { "XP"   , 0 },
        { "MXP"  , 0 },
    };

    // Other important members that don't need to be grouped with stats.
    public int Level { get; private set; }
    public ClassType Type { get; private set; }

    // Constructor
    public UnitData(ClassType newUnitClass)
    {
        Type = newUnitClass;
        Level = 1;

        switch (Type)
        {
            case ClassType.Warrior:
                stats["HP"]   = 10;
                stats["MP"]   =  5;
                stats["ATK"]  =  3;
                stats["DEF"]  =  2;
                stats["MATK"] =  1;
                stats["MDEF"] =  2;
                stats["MOV"]  =  3;
                stats["LCK"]  =  7;
                stats["XP"]   =  0;
                stats["MXP"]  = 20;
                stats["Moved"] = 0;
                stats["Attacked"] = 0;
                stats["Passed"] = 0;
                break;
            case ClassType.Rogue:
                stats["HP"]   = 10;
                stats["MP"]   =  5;
                stats["ATK"]  =  3;
                stats["DEF"]  =  2;
                stats["MATK"] =  1;
                stats["MDEF"] =  2;
                stats["MOV"]  =  3;
                stats["LCK"]  =  7;
                stats["XP"]   =  0;
                stats["MXP"]  = 20;
                stats["Moved"] = 0;
                stats["Attacked"] = 0;
                stats["Passed"] = 0;
                break;
            case ClassType.Mage:
                stats["HP"]   = 10;
                stats["MP"]   =  5;
                stats["ATK"]  =  3;
                stats["DEF"]  =  2;
                stats["MATK"] =  1;
                stats["MDEF"] =  2;
                stats["MOV"]  =  3;
                stats["LCK"]  =  7;
                stats["XP"]   =  0;
                stats["MXP"]  = 20;
                stats["Moved"] = 0;
                stats["Attacked"] = 0;
                stats["Passed"] = 0;
                break;
            case ClassType.Archer:
                stats["HP"]   = 10;
                stats["MP"]   =  5;
                stats["ATK"]  =  3;
                stats["DEF"]  =  2;
                stats["MATK"] =  1;
                stats["MDEF"] =  2;
                stats["MOV"]  =  3;
                stats["LCK"]  =  7;
                stats["XP"]   =  0;
                stats["MXP"]  = 20;
                stats["Moved"] = 0;
                stats["Attacked"] = 0;
                stats["Passed"] = 0;
                break;
            default:
                break;
        }
    }

    // Method to obtatin any of a unit's stats.
    public int GetStat(string stat)
    {
        if (stats.ContainsKey(stat))
            return stats[stat];
        else return -1;
    }

    public string ShowStats()
    {
        string statString = "";
        foreach (var stat in stats)
        {
            if (!string.Equals(stat.Key, "Moved") && !string.Equals(stat.Key, "Attacked") && !string.Equals(stat.Key, "Passed"))
            {
                statString += $"{stat.Key}: {stat.Value}\n";
            }
        }
        return statString;
    }

    public void ChangeStat(string stat, int delta)
    {
        if (!stats.ContainsKey(stat)) return;

        stats[stat] += delta;
    }

    public void setMove(){
        stats["Moved"] = 1;
    }

    public void setAttack(){
        stats["Attacked"] = 1;
    }

    public void setPass(){
        stats["Passed"] = 1;
    }

    public void unsetPass(){
        stats["Passed"] = 0;
    }

    public void unsetMove(){
        stats["Moved"] = 0;
    }

    public void unsetAttack(){
        stats["Attacked"] = 0;
    }

    // every class levels differently
    public void LevelUp()
    {

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
}
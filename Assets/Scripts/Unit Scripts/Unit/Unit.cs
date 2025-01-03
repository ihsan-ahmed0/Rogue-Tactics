using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// this class is used as a template for how units behave
/// 
public class Unit : MonoBehaviour
{
    // Data that contains the stats and class type of the unit.
    private UnitData unitData;

    protected string unitName;
    private List<ActiveSkill> activeSkills;
    private List<PassiveSkill> passiveSkills;

    public Unit(string newName, ClassType newClass)
    {
        unitName = newName;
        unitData = new UnitData(newClass);
    }

    public string GetName()
    {
        return unitName;
    }

    // Obtain any of the unit's stats.
    public int GetStat(string stat)
    {
        return unitData.GetStat(stat);
    }

    public void AddSkill(Skill newSkill)
    {
        if (newSkill.GetTypeOfSkill().CompareTo("ActiveSkill") == 0)
        {
            activeSkills.Add((ActiveSkill) newSkill);
        }
        else
        {
            passiveSkills.Add((PassiveSkill) newSkill);
        }
    }

    public void Move(Vector3[] path)
    {

    }

    public void Attack(Unit defendingUnit)
    {
        int critValue = Random.Range(1, 100);
        float randomMod;
        if (critValue <= unitData.GetStat("LCK"))
        {
            randomMod = Random.Range(1.0f, 1.5f);
        }
        else
        {
            randomMod = Random.Range(3.0f, 4.0f);
        }

        int damage = (int) (0.4f * (float) unitData.Level +  (float) unitData.GetStat("ATK") * randomMod);

        defendingUnit.Defend(damage);
    }

    public void Spell(Unit defendingUnit)
    {
        int critValue = Random.Range(1, 100);
        float randomMod;
        if (critValue <= unitData.GetStat("LCK"))
        {
            randomMod = Random.Range(1.0f, 1.5f);
        }
        else
        {
            randomMod = Random.Range(3.0f, 4.0f);
        }

        // TODO: Implement spells and spell damage in this formula.
        int damage = (int) (0.4f * (float) unitData.Level + 0.2f * (float) unitData.GetStat("MATK") * randomMod);
    }

    public void InvokeSkill(Skill invokedSkill)
    {
        (SkillEffect, int)[] effects = invokedSkill.GetSkillEffects();

        for (int i = 0; i < effects.Length; i++)
        {
            switch (effects[i].Item1)
            {
                case SkillEffect.DMG:
                    break;
                case SkillEffect.HP:
                    break;
                case SkillEffect.ATK:
                    break;
                case SkillEffect.DEF:
                    break;
                case SkillEffect.MATK:
                    break;
                case SkillEffect.MDEF:
                    break;
                case SkillEffect.MOV:
                    break;
                case SkillEffect.LCK:
                    break;
                default:
                    break;
            }
        }
    }

    public void Defend(int attackDamage)
    {
        unitData.ChangeStat("HP", attackDamage - unitData.GetStat("DEF"));
    }

    public void DefendMagic(int spellDamage)
    {
        unitData.ChangeStat("HP", spellDamage - unitData.GetStat("MDEF"));
    }

    public void CheckPassiveSkills()
    {

    }
}

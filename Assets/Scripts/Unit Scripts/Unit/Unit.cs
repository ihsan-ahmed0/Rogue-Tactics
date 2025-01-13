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
    private GameObject unitGameObject;

    public void Init(string newName, ClassType newClass)
    {
        unitName = newName;
        unitData = new UnitData(newClass);
    }

    public void SetGameObject(GameObject gameObject)
    {
        unitGameObject = gameObject;
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

    public void ChangeStat(string stat, int delta)
    {
        unitData.ChangeStat(stat, delta);
    }

    public string GetInfo()
    {
        return unitData.ShowStats();
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
        for (int i = 0; i < path.Length; i++)
        {
            // I would add linear interpolation if i had time
            transform.position = path[i];
        }
    }

    // Used exclusively for placing a unit on a particular tile
    public void Move(Vector3 square)
    {
        transform.position = square;
    }


    // Method to generate a random modifier for various attacks based on a unit's Luck stat.
    private float GenerateRandomModifier()
    {
        int critValue = Random.Range(1, 100);
        float randomMod;
        if (critValue <= unitData.GetStat("LCK"))
        {
            randomMod = Random.Range(3.0f, 4.0f);
        }
        else
        {
            randomMod = Random.Range(1.0f, 1.5f);
        }
        return randomMod;
    }

    public void Attack(Unit defendingUnit)
    {
        int damage = (int) (0.4f * (float) unitData.Level +  (float) unitData.GetStat("ATK") * GenerateRandomModifier());
        defendingUnit.Defend(damage);
    }

    public void Spell(Unit defendingUnit)
    {
        // TODO: Implement spells and spell damage in this formula.
        int damage = (int) (0.4f * (float) unitData.Level + 0.2f * (float) unitData.GetStat("MATK") * GenerateRandomModifier());
        defendingUnit.Defend(damage);
    }

    public void InvokeSkill(Skill invokedSkill, Unit targetUnit)
    {
        (SkillEffect, int)[] effects = invokedSkill.GetSkillEffects();

        for (int i = 0; i < effects.Length; i++)
        {
            switch (effects[i].Item1)
            {
                case SkillEffect.DMG:
                    int damage = (int) (0.4f * (float) unitData.Level + (float) effects[i].Item2 * GenerateRandomModifier());
                    targetUnit.Defend(damage);
                    break;
                case SkillEffect.HP:
                    targetUnit.ChangeStat("HP", effects[i].Item2);
                    break;
                case SkillEffect.ATK:
                    targetUnit.ChangeStat("ATK", effects[i].Item2);
                    break;
                case SkillEffect.DEF:
                    targetUnit.ChangeStat("DEF", effects[i].Item2);
                    break;
                case SkillEffect.MATK:
                    targetUnit.ChangeStat("MATK", effects[i].Item2);
                    break;
                case SkillEffect.MDEF:
                    targetUnit.ChangeStat("MDEF", effects[i].Item2);
                    break;
                case SkillEffect.MOV:
                    targetUnit.ChangeStat("MOV", effects[i].Item2);
                    break;
                case SkillEffect.LCK:
                    targetUnit.ChangeStat("LCK", effects[i].Item2);
                    break;
                default:
                    break;
            }
        }
    }

    public void Defend(int attackDamage)
    {
        unitData.ChangeStat("HP", -1 * (attackDamage - unitData.GetStat("DEF")));
    }

    public void DefendMagic(int spellDamage)
    {
        unitData.ChangeStat("HP", -1 * (spellDamage - unitData.GetStat("MDEF")));
    }

    public void CheckPassiveSkills(Condition currentCondtion)
    {
        for (int i = 0; i < passiveSkills.Count; i++)
        {
            if (passiveSkills[i].CheckCondition(currentCondtion))
            {
                InvokeSkill(passiveSkills[i], this);
            }
        }
    }

    public void setMove(){
        unitData.setMove();
    }

    public void setAttack(){
        unitData.setAttack();
    }
    public void setPass(){
        unitData.setPass();
    }

    public void unsetPass(){
        unitData.unsetPass();
    }

    public void unsetMove(){
        unitData.unsetMove();
    }

    public void unsetAttack(){
        unitData.unsetAttack();
    }
}

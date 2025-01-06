using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class serves as a database that holds a manually-coded list of all possible skills in the game.
public class SkillDatabase
{
    public static PassiveSkill[] passiveSkills =
    {
        new PassiveSkill(
            "P. Attack Up",
            "Increases physical attack.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.ATK, 25)
            },
            ClassType.All
        ),
        new PassiveSkill(
            "M. Attack Up",
            "Increases magic attack.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.MATK, 25)
            },
            ClassType.All
        ),
        new PassiveSkill(
            "P. Defense Up",
            "Increases physical defense.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.DEF, 25)
            },
            ClassType.All
        ),
        new PassiveSkill(
            "M. Defense Up",
            "Increases magic defense.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.MDEF, 25)
            },
            ClassType.All
        ),
        new PassiveSkill(
            "Range Up",
            "Increases movement range by 2.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.MOV, 2)
            },
            ClassType.All
        ),
        new PassiveSkill(
            "Luck Up",
            "Increases luck and critical hit rate.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.LCK, 60)
            },
            ClassType.All
        ),
        new PassiveSkill(
            "Health Up",
            "Increases luck and critical hit rate.",
            new (SkillEffect, int)[]
            {
                (SkillEffect.LCK, 60)
            },
            ClassType.All
        )
    };
    public static ActiveSkill[] activeSkills = { };
}

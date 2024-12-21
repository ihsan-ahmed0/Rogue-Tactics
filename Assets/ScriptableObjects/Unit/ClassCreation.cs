using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

/// class for instaniating a specific UnitClass using enum and switching. 
/// works in a similar fashion to the factory pattern

public class ClassCreation {

    public static UnitClass Create(ClassType classType) => classType switch
    {
        ClassType.Mage => new Mage(),
        ClassType.Warrior => new Warrior(),
        ClassType.Rogue => new Rogue(),
        ClassType.Archer => new Archer(),
        _ => throw new ArgumentException("Invalid class type", nameof(classType))
    };
}

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


public abstract class Skill
{
    protected int multiplier;
    protected string attribute;
    // not all skills do damage so it's a nullable type
    public double Damage { get; protected set; }
    public string Name { get; protected set; }
    public ClassType Type { get; protected set; }

    public virtual void Activate(UnitClass cater, UnitClass target) { }
    public virtual void Activate(UnitClass unit) { }
    // aoe implemenation of buff skill
    public virtual void Activate(List<UnitClass> units) { }
    // aoe implemenation for attack skill
    public virtual void Activate(UnitClass caster, List<UnitClass> targets) { }

    // allows skill objects to be printed like strings
    public override string ToString() {
        return Name;
    }
    protected Skill(){
        // can not be private
        // only available to subclasses
    }
  
}

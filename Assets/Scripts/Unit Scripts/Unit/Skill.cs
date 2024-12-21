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

    public virtual void Activate(UnitClass cater, UnitClass Target) { Debug.Write("Abstract class"); }
    public virtual void Activate(UnitClass unit) { Debug.Write("Abstract class"); }

    protected Skill(){
        // can not be private
        // only available to subclasses
    }
  
}

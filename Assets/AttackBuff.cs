using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBuff : Skill
{
    public int attackMultiplier;
    public string attackMultType;
    // Start is called before the first frame update
    void Start()
    {
        
       
        setBuff();
    }

    // Update is called once per frame
public override void setBuffKeyValue(){
     Boost= new KeyValuePair<int,string> (attackMultiplier,attackMultType);
}
public int getBuff(int stat){
    return attackMultiplier*stat;
}
}

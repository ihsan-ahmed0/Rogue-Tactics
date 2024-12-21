using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mage : CharacterClass
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void InitializeMage()
    {
        //   MP
        // HP
        // Speed
        // Dexterity
        // Luck
       
        SetVariables(20,100,10,5,1);
    }
}

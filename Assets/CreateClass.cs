using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Mage m = new Mage();
        m.InitializeMage();
        Debug.Log("MP: "+m.GetMP()+" HP "+m.GetHP()+" Speed: "+m.GetSpeed()+" Dexterity: "+m.GetDexerity()+" Luck: "+m.GetLuck());
    }
}

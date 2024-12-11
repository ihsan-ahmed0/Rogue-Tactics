using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill 
{
   public int multiplier = 0;
   public string multType = "";
  public KeyValuePair<int,string> Boost{get; set;}
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
 public abstract void setBuff();
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterClass 
{
    public static  int MP=0;
     public static int HP=0;
        public static  int Speed=0;
        public static  int Dexterity=0;
        public static  int Luck=0 ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public CharacterClass(){
        
    }
    public int GetMP(){
        return MP;
    }
    public  void SetMP(int MPVal){
         MP =MPVal;
    }
     public int GetHP(){
        return HP;
    }
    public   void SetHP(int HPVal){
        HP =HPVal;
    }
    
      public int GetSpeed(){
        return Speed;
    }
    public  void SetSpeed(int SpeedVal){
         Speed=SpeedVal;
    }
      public int GetLuck(){
        return Luck;
    }
    public   void SetLuck(int LuckVal){
        Luck =LuckVal;
    }
       public int GetDexerity(){
        return Dexterity;
    }
    public   void SetDexerity(int DexerityVal){
      Dexterity =DexerityVal;
    }
    
    public  void SetVariables(int MPVal2, int HPVal2, int SpeedVal2, int DexterityVal2,int LuckVal2){
        SetMP(MPVal2);
        SetHP(HPVal2);
        SetSpeed(SpeedVal2);
        SetDexerity(DexterityVal2);
        SetLuck(LuckVal2);
    }
}

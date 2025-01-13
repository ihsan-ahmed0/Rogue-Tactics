using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI turnText;
    public Level1Manager level1Manager;
    // Start is called before the first frame update
    void Start()
    {
        DisplayTurnText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisplayTurnText()
    {
        string turnNumber = level1Manager.getTurn().ToString() + "/20";
        turnText.text = turnNumber;
    }
}

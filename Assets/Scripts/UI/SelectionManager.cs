using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    // Keeps track of what the cursor has selected
    public static SelectionManager Instance { get; private set; }
    private Unit selectedUnit;
    InfoBox info;
    void Awake()
    {
        if (Instance == null)
            Instance = this;

        info = GameObject.Find("InfoBox").GetComponent<InfoBox>();
    }

    public Unit GetUnit() => selectedUnit;

    public void SelectUnit(Unit unit) { 
        selectedUnit = unit;
        info.DisplayText();
    }

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoBox : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI infoText;
    void Start()
    {
        
    }

    public void DisplayText()
    {
        string infoDump = SelectionManager.Instance.GetUnit().GetInfo();
        infoText.text = infoDump;
    }

}

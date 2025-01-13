using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonManager : MonoBehaviour
{
    public Level1Manager level1Manager;
    public Button AttackButton;
    public Button MoveButton;
    public Button MagicButton;
    public Button PassButton;
    public Button SkillButton;

    public void Attack()
    {
        Unit unit = SelectionManager.Instance.GetUnit(); 
        bool attacked = level1Manager.AttackUnit();
        if (attacked){
            unit.setAttack();
            DeactivateButton(AttackButton);
        }
    }

    public void Move()
    {
        Unit unit = SelectionManager.Instance.GetUnit(); 
        bool moved = level1Manager.MoveUnit();
        if (moved){
            unit.setMove();
            DeactivateButton(MoveButton);
        }
    }

    public void Skill()
    {
        Debug.Log("Skill");
    }

    public void Magic()
    {
        Debug.Log("Magic");
    }

    public void Pass()
    {   
        Unit unit = SelectionManager.Instance.GetUnit(); 
        if (unit != null){
            unit.setMove();
            unit.setAttack();
            unit.setPass();
            DeactivateButton(PassButton);
            DeactivateButton(AttackButton);
            DeactivateButton(MoveButton);
            DeactivateButton(SkillButton);
            DeactivateButton(MagicButton);

        } else {
            Debug.Log("No unit selected");
        }
    }

    public void EndTurn()
    {
        level1Manager.newPlayerTurn();
    }

    public void showUnitUI(){
        Unit unit = SelectionManager.Instance.GetUnit(); 
        if (unit.GetStat("Passed") == 0){
            if (unit.GetStat("Moved") == 0){
                ReactivateButton(MoveButton);
            } else {
                DeactivateButton(MoveButton);
            }

            if (unit.GetStat("Attacked") == 0){
                ReactivateButton(AttackButton);
            } else {
                DeactivateButton(AttackButton);
            }

            ReactivateButton(SkillButton);
            ReactivateButton(MagicButton);
            ReactivateButton(PassButton);

        } else {
            DeactivateButton(PassButton);
            DeactivateButton(AttackButton);
            DeactivateButton(MoveButton);
            DeactivateButton(SkillButton);
            DeactivateButton(MagicButton);
        }
        
    }

    public void ReactivateButton(Button button)
    {
        if (button != null)
        {
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = Color.white;
            }

            button.interactable = true;
        }
    }

    public void DeactivateButton(Button button)
    {
        if (button != null)
        {
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = Color.gray;
            }

            button.interactable = false;
        }
    }
}

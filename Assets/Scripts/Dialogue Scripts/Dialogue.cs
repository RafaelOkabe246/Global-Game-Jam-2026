using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public int dialoguePriority;
    public DialogueLine[] dialogueLines;
    public Tip[] dialogueTriggerConditions;

    public Tip[] dialogueResultsTips;

    private void OnValidate()
    {
        dialoguePriority = 0;

        if (dialogueTriggerConditions.Length < 1)
            return;

        foreach (Tip tip in dialogueTriggerConditions)
        {
            dialoguePriority += tip.priority;
        }
    }

    public bool CheckIfConditionsTrue(List<Tip> inventoryConditions)
    {
        for (int i = 0; i < dialogueTriggerConditions.Length; i++)
        {
            if (!inventoryConditions.Contains(dialogueTriggerConditions[i]))
            {
                Debug.Log("FALSE CONDITION");

                return false;
            }
        }
        Debug.Log("TRUE CONDITION");
        return true;
    }

    public void OnDialogueStarted()
    {

    }

    public void OnDialogueEnded(DialogueInventory dialogueInventory)
    {
        foreach (Tip tip in dialogueResultsTips)
        {
            dialogueInventory.AddNewTip(tip);
        }
    }

}

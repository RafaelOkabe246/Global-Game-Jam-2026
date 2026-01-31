using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public int dialoguePriority;
    public DialogueLine[] dialogueLines;
    public Tip[] tipsConditions;

    private void Awake()
    {
        dialoguePriority = 0;
        foreach (Tip tip in tipsConditions)
        {
            dialoguePriority += tip.priority;
        }
    }

    public bool CheckIfConditionsTrue(List<Tip> inventoryConditions)
    {
        for (int i = 0; i < tipsConditions.Length; i++)
        {
            if (!inventoryConditions.Contains(tipsConditions[i]))
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

    public void OnDialogueEnded()
    {

    }

}

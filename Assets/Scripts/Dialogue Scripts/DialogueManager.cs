using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public Character character1;

    public Tip[] inventoryTips;

    private Dialogue currentDialogue;
    private DialogueLine currentDialogueLine;
    private int currentDialogueLineIndex;
    private int charIndex;

    private void Start()
    {
        SelectDialogue(character1);
    }

    private CharacterDialogue CheckConditionAndPriority(Character character)
    {
        CharacterDialogue[] characterDialogues = character.characterDialogues;

        List<CharacterDialogue> dialoguesConditionTrue = new List<CharacterDialogue>();

        //Check conditions
        for (int i = 0; i < characterDialogues.Length; i++)
        {
            if (characterDialogues[i].dialogue.CheckIfConditionsTrue(inventoryTips.ToList()))
            {
                //Conditions of the dialogue are true
                dialoguesConditionTrue.Add(characterDialogues[i]);
            }
        }

        //Check priority
        int biggestPriorityDick = 0;
        int biggestPriorityDickIndex = 0;
        for (int i = 0; i < dialoguesConditionTrue.Count; i++)
        {
            if (dialoguesConditionTrue[i].dialogue.dialoguePriority > biggestPriorityDick)
            {
                biggestPriorityDickIndex = i;
                biggestPriorityDick = dialoguesConditionTrue[i].dialogue.dialoguePriority;
            }
        }

        CharacterDialogue returnCharacterDialogue = dialoguesConditionTrue[biggestPriorityDickIndex];
        return returnCharacterDialogue;
    }

    public void SelectDialogue(Character character)
    {
        //Check the conditions and stuff to return the dialogue
        CharacterDialogue characterDialogue = CheckConditionAndPriority(character);//character.characterDialogues[0];
        Dialogue dialogue = characterDialogue.dialogue;

        if(characterDialogue.hasPlayed == true)
        {
            Debug.Log("Dialogue has played");
            return;
        }

        if (dialogue.CheckIfConditionsTrue(inventoryTips.ToList()))
        {
            characterDialogue.hasPlayed = true;
            OnStartDialogue(dialogue);
        }

    }

    public void OnStartDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
        currentDialogueLine = dialogue.dialogueLines[0];
        currentDialogueLineIndex = 0;

        PlayDialogueLine(currentDialogueLine);

    }

    public void NextDialogueLine()
    {
        int nextLineIndex = currentDialogueLineIndex + 1;
        int maxIndex = currentDialogue.dialogueLines.Length;

        if(nextLineIndex >= maxIndex)
        {
            Debug.Log("End dialogue");
            ResetDialogue();
            return;
        }

        DialogueLine nextDialogueLine = currentDialogue.dialogueLines[nextLineIndex];

        currentDialogueLine = nextDialogueLine;

        PlayDialogueLine(currentDialogueLine);
        currentDialogueLineIndex = nextLineIndex;
    }

    private void PlayDialogueLine(DialogueLine dialogueLine)
    {
        Debug.Log($"{dialogueLine.GetLineText()}");
    }

    private void ResetDialogue()
    {
        currentDialogue = null;
        currentDialogueLine = null;
        currentDialogueLineIndex = 0;
        charIndex = 0;
    }
}

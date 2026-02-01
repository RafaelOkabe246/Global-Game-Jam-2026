using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;

    private DialogueInventory dialogueInventory;

    private UiManager uiManager;
    private Ui_Dialogue ui_Dialogue;

    private Dialogue currentDialogue;
    private DialogueLine currentDialogueLine;
    private int currentDialogueLineIndex;
    private int charIndex;

    

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        uiManager = UiManager.instance;
        dialogueInventory = DialogueInventory.instance;

        ui_Dialogue = uiManager.ui_Dialogue;
    }

    private CharacterDialogue CheckConditionAndPriority(Character character)
    {
        CharacterDialogue[] characterDialogues = character.characterDialogues;

        List<CharacterDialogue> dialoguesConditionTrue = new List<CharacterDialogue>();

        //Check conditions
        for (int i = 0; i < characterDialogues.Length; i++)
        {
            if (characterDialogues[i].dialogue.CheckIfConditionsTrue(dialogueInventory.inventoryTips))
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

        if (dialogue.CheckIfConditionsTrue(dialogueInventory.inventoryTips))
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

        //Set up ui
        uiManager.OpenUI(ui_Dialogue);

        PlayDialogueLine(currentDialogueLine);
    }

    public void NextDialogueLine()
    {
        int nextLineIndex = currentDialogueLineIndex + 1;
        int maxIndex = currentDialogue.dialogueLines.Length;

        if(nextLineIndex >= maxIndex)
        {
            Debug.Log("End dialogue");
            EndDialogue();
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
        ui_Dialogue.SetText(dialogueLine.GetLineText());
    }

    private void EndDialogue()
    {
        currentDialogue.OnDialogueEnded(dialogueInventory);

        foreach (Tip tip in currentDialogue.dialogueResultsTips)
        { 
            JournalManager.instance.AddJournalEntry(tip);
        }
        currentDialogue = null;
        currentDialogueLine = null;
        currentDialogueLineIndex = 0;
        charIndex = 0;

        ui_Dialogue.SetText("");
        uiManager.CloseUi(ui_Dialogue);

        ActionsManager.instance.SpendAction();
    }
}

using UnityEngine;

[System.Serializable]
public struct CharacterDialogue
{
    public Dialogue dialogue;
    public bool hasPlayed;
}

public class Character : MonoBehaviour
{
    public CharacterDialogue[] characterDialogues;

    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

    public void StartDialgues()
    {
        dialogueManager.SelectDialogue(this);
    }

}

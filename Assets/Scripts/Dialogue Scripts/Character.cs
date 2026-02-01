using UnityEngine;

[System.Serializable]
public class CharacterDialogue
{
    public Dialogue dialogue;
    public bool hasPlayed;
}

public class Character : MonoBehaviour
{
    public CharacterDialogue[] characterDialogues;

    private DialogueManager dialogueManager;

    public Sprite characterPortraitIcon;

    private void Start()
    {
        dialogueManager = DialogueManager.instance;
    }

    public void StartDialgues()
    {
        dialogueManager.SelectDialogue(this);
    }

}

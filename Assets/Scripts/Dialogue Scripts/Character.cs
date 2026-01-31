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

    public void StartDialgues()
    {

    }

}

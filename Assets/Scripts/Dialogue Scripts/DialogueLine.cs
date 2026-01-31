using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    [TextArea(3,10)]
    public string lineText;

    public string GetLineText()
    {
        return lineText;
    }
}

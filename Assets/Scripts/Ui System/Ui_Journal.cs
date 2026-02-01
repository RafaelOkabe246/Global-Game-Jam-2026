using UnityEngine;

public class Ui_Journal : Ui_Element
{
    public CanvasGroup journalUI;

    public override void OpenUiElement()
    {
        journalUI.alpha = 1f;
        journalUI.interactable = true;
        journalUI.blocksRaycasts = true;
    }

    public override void CloseUiElement()
    {
        journalUI.alpha = 0f;
        journalUI.interactable = false;
        journalUI.blocksRaycasts = false;
    }
}

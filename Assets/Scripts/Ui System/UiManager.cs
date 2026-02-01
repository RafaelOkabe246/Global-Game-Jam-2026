using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiManager : MonoBehaviour
{
    public Ui_Dialogue ui_Dialogue;
    public JournalManager journalManager;
    public Ui_FinalAcusation ui_finalAcusation;

    public static UiManager instance;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        journalManager = FindFirstObjectByType<JournalManager>(); 
        journalManager.CloseJournal();
        CloseUi(ui_Dialogue);
    }

    public void OpenUI(Ui_Element ui_Element)
    {
        ui_Element.OpenUiElement();
        ui_Element.onOpenEvent?.Invoke();
    }

    public void CloseUi(Ui_Element ui_Element)
    {
        ui_Element.CloseUiElement();
    }
}

using UnityEngine;
using TMPro; // Make sure to use TextMesh Pro
using System.Collections.Generic;
using System.Linq;

public class JournalManager : MonoBehaviour
{
    public static JournalManager instance;

    public Ui_Journal journalUI;

    [SerializeField] private bool firstOpen;
    public Dialogue journalTutorialDialogue;

    public GameObject pagesPanel;
    public GameObject newEntryIcon;

    public JournalLine journalLinePrefab;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        firstOpen = false;
        newEntryIcon.SetActive(false);
    }

    public void AddJournalEntry(Tip newTip, Character characterThatGaveTheTip)
    {
        JournalLine journalLine = Instantiate(journalLinePrefab);
        journalLine.lineText.text = newTip.tipText;
        journalLine.transform.SetParent
            (pagesPanel.transform);
        journalLine.SetIcon(characterThatGaveTheTip.characterPortraitIcon);

        //Activate icon effect
        newEntryIcon.SetActive(true);
    }

    public void OpenJournal()
    {
        journalUI.OpenUiElement();

        if (!firstOpen)
        {
            //Play tutorial dialogue
            DialogueManager.instance.SelectDialogue(journalTutorialDialogue);
            firstOpen = true;
        }
    }

    public void CloseJournal()
    {
        newEntryIcon.SetActive(false);
        journalUI.CloseUiElement();

    }


}

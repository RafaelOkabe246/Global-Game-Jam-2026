using UnityEngine;
using TMPro; // Make sure to use TextMesh Pro
using System.Collections.Generic;
using System.Linq;

public class JournalManager : MonoBehaviour
{
    public static JournalManager instance;

    public Ui_Journal journalUI;

    public List<JournalEntry> journalEntries = new List<JournalEntry>();
   
    public JournalEntry journalEntryPrefab;
    public GameObject pagesPanel;

    private int currentEntryIndex = 0;


    private void Awake()
    {
        instance = this;
    }

    public void AddJournalEntry(Tip newTip)
    {
        //Verifica se já existe journal entry com a fonte/origem

        for (int i = 0; i < journalEntries.Count; i++)
        {
            if(journalEntries[i].tipOrigin == newTip.tipOrigin)
            {
                //Já tem entry
                journalEntries[i].AddNewJournalLine(newTip.tipText);
                return;
            }
        }

        //Senão instantiate new

        //JournalEntry journalEntry = Instantiate(journalEntryPrefab);
        //journalEntry.gameObject.transform.SetParent(pagesPanel.transform);
        //journalEntry.Initiate(newTip.tipOrigin);
    }

    public void OpenJournal()
    {
        journalUI.OpenUiElement();

        //DisplayEntry(0); // Display the first entry when opened
    }

    public void CloseJournal()
    {
        journalUI.CloseUiElement();
    }

    public void DisplayEntry(int index)
    {
        //if (index >= 0 && index < allEntries.Count)
        //{
        //    currentEntryIndex = index;
        //    JournalEntry entry = allEntries[currentEntryIndex];
        //    titleText.text = entry.entryTitle;
        //    contentText.text = entry.entryContent;
        //}
    }

    public void NextEntry()
    {
        //DisplayEntry(currentEntryIndex + 1);
    }

    public void PreviousEntry()
    {
       // DisplayEntry(currentEntryIndex - 1);
    }

}

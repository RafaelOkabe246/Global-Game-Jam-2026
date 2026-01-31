using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class JournalEntry : Ui_Element
{
    public TipOrigin tipOrigin;
    public string entryTitle;
    
    public JournalLine journalLinePrefab;
    public List<JournalLine> journalLines = new List<JournalLine>();

    [Header("UI components")]
    public Image fonteInformacaoIcon;

    public void Initiate(TipOrigin tipOrigin)
    {
        this.tipOrigin = tipOrigin;
    }

    public void AddNewJournalLine(string text)
    {
        JournalLine newJournalLine = Instantiate(journalLinePrefab);
        newJournalLine.lineText.text = text; 
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JournalLine : MonoBehaviour
{
    public TextMeshProUGUI lineText;
    public Image iconJournalLine;

    public void SetIcon(Sprite spriteIcon)
    {
        iconJournalLine.sprite = spriteIcon;
    }
}

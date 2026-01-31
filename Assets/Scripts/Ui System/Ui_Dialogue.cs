using UnityEngine;
using TMPro;

public class Ui_Dialogue : Ui_Element
{
    public TextMeshProUGUI textBox;

    public void SetText(string text)
    {
        textBox.text = text;
    }
}

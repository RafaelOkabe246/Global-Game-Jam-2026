using System.Collections.Generic;
using UnityEngine;

public class DialogueInventory : MonoBehaviour
{
    public static DialogueInventory instance;

    public List<Tip> inventoryTips = new List<Tip>();

    private void Awake()
    {
        instance = this;
    }

    public void AddNewTip(Tip newTip)
    {
        inventoryTips.Add(newTip);
    }

}

using System.Collections.Generic;
using UnityEngine;

public class DialogueInventory : MonoBehaviour
{
    public static DialogueInventory instance;

    public List<Tip> inventoryTips = new List<Tip>();

    private Tip currentMascara;

    public Tip mascaraVermelha;
    public Tip mascaraAmarela;
    public Tip mascaraAzul;

    private void Awake()
    {
        instance = this;
    }

    public void SelecteNewMascara(MascarasTypes mascara)
    {
        switch (mascara)
        {
            case MascarasTypes.Amarela:
                currentMascara = mascaraAmarela;
                inventoryTips.Remove(mascaraAzul);
                inventoryTips.Remove(mascaraVermelha);
                break;
            case MascarasTypes.Vermelha:
                currentMascara = mascaraVermelha;
                inventoryTips.Remove(mascaraAzul);
                inventoryTips.Remove(mascaraAmarela);
                break;
            case MascarasTypes.Azul:
                currentMascara = mascaraAzul;
                inventoryTips.Remove(mascaraAmarela);
                inventoryTips.Remove(mascaraVermelha);
                break;
        }
    }
    public void AddNewTip(Tip newTip)
    {
        inventoryTips.Add(newTip);
    }

    public void RemoveTip(Tip removeTip)
    {
        inventoryTips.Remove(removeTip);
    }
    
}
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueInventory : MonoBehaviour
{
    public static DialogueInventory instance;

    public List<Tip> inventoryTips = new List<Tip>();

    private Tip currentMascara;

    public Tip mascaraVermelha;
    public Tip mascaraAmarela;
    public Tip mascaraAzul;

    private GridManager gridManager;

    public Image mascaraIcon;
    public Sprite mascaraVermelhaIcon;
    public Sprite mascaraAmarelaIcon;
    public Sprite mascaraAzulIcon;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gridManager = GridManager.Instance;
        SelecteNewMascara("Azul");
    }

    public void CreateListOfItemsColetados()
    {

    }

    MascarasTypes mascara = MascarasTypes.Amarela;
    public void SelecteNewMascara(string mascaraTipo)
    {
        if (mascaraTipo == "Azul")
        {
            mascara = MascarasTypes.Azul;
        }
        if (mascaraTipo == "Amarela")
        {
            mascara = MascarasTypes.Amarela;
        }
        if (mascaraTipo == "Vermelha")
        {
            mascara = MascarasTypes.Vermelha;
        }

        switch (mascara)
        {
            case MascarasTypes.Amarela:
                currentMascara = mascaraAmarela;
                mascaraIcon.sprite = mascaraAmarelaIcon;
                if (!inventoryTips.Contains(mascaraAmarela))
                    inventoryTips.Add(mascaraAmarela);
                inventoryTips.Remove(mascaraAzul);
                inventoryTips.Remove(mascaraVermelha);
                break;
            case MascarasTypes.Vermelha:
                currentMascara = mascaraVermelha;
                mascaraIcon.sprite = mascaraVermelhaIcon;
                if (!inventoryTips.Contains(mascaraVermelha))
                    inventoryTips.Add(mascaraVermelha);

                inventoryTips.Remove(mascaraAzul);
                inventoryTips.Remove(mascaraAmarela);
                break;
            case MascarasTypes.Azul:
                currentMascara = mascaraAzul;
                mascaraIcon.sprite = mascaraAzulIcon;
                
                if(!inventoryTips.Contains(mascaraAzul))
                    inventoryTips.Add(mascaraAzul);

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
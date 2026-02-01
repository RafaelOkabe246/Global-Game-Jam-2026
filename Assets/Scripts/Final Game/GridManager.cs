using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public ItemDatabase Database;
    public GameObject ItemPrefab;
    public Transform GridParent;

    public CategorySlot OcupiedSlot;
    public CategorySlot WeaponSlot;
    public CategorySlot MotivationSlot;

    public static GridManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateGrid(List<ItemID> coletados)
    {
        foreach (Transform child in GridParent) Destroy(child.gameObject);

        foreach (ItemID id in coletados)
        {
            ItemInfo info = System.Array.Find(Database.AllItems, x => x.Id == id);
            if (info.Icon != null)
            {
                GameObject novoItem = Instantiate(ItemPrefab, GridParent);
                novoItem.transform.localScale = Vector3.one;
                novoItem.transform.localPosition = Vector3.zero;

                var script = novoItem.GetComponent<EvidenceItem>();
                script.Setup(info);
            }
        }
    }

    public void MoveItem(EvidenceItem item)
    {
        if (item.transform.parent != GridParent)
        {
            var slotAntigo = item.transform.parent.GetComponent<CategorySlot>();
            if (slotAntigo != null) slotAntigo.RemoveItem();

            item.transform.SetParent(GridParent);
            item.transform.localScale = Vector3.one;
            return;
        }

        CategorySlot slotAlvo = null;

        switch (item.Category)
        {
            case ItemCategory.Culpado: slotAlvo = OcupiedSlot; break;
            case ItemCategory.Arma: slotAlvo = WeaponSlot; break;
            case ItemCategory.Motivacao: slotAlvo = MotivationSlot; break;
        }

        if (slotAlvo != null && slotAlvo.IsEmpty)
        {
            slotAlvo.ReceiveItem(item);
        }
        else
        {
            Debug.Log("Slot ocupado ou não configurado");
        }
    }
}

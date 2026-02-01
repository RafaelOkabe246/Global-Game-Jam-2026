using UnityEngine;
using UnityEngine.UI;

public class CategorySlot : MonoBehaviour
{
    public ItemCategory RequiredCategory;
    [HideInInspector] public EvidenceItem CurrentItem;

    public bool IsEmpty => CurrentItem == null;

    public void ReceiveItem(EvidenceItem item)
    {
        CurrentItem = item;

        item.transform.SetParent(this.transform);

        RectTransform rect = item.GetComponent<RectTransform>();

        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.pivot = new Vector2(0.5f, 0.5f);

        rect.anchoredPosition = Vector2.zero;
        rect.localScale = Vector3.one;
    }

    public void RemoveItem()
    {
        CurrentItem = null;
    }
}

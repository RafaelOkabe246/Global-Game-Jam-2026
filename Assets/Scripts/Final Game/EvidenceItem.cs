using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EvidenceItem : MonoBehaviour, IPointerClickHandler //
{
    public ItemID Id;
    public ItemCategory Category;
    private Image m_displayImage;

    public void Setup(ItemInfo info)
    {
        m_displayImage = GetComponent<Image>();
        Id = info.Id;
        Category = info.Category;
        m_displayImage.sprite = info.Icon;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GridManager.Instance != null)
        {
            GridManager.Instance.MoveItem(this);
        }
    }
}

using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.EventSystems;

public class InteractionController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
{
    private float m_holdDuration = 1f;

    private bool m_isPressed = false;
    private bool m_isHolding = false;
    private float m_timer = 0f;

    protected virtual void OnSingleClick() { }
    protected virtual void OnMultiClick(int clickQuantity) { }
    protected virtual void OnHoldClick() { }

    public void OnPointerDown(PointerEventData eventData)
    {
        m_isPressed = true;
        m_isHolding = false;
        m_timer = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        m_isPressed = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (m_isHolding)
        {
            return;
        }

        if (eventData.clickCount > 3)
        {
            OnMultiClick(eventData.clickCount);
        }

        else
        {
            OnSingleClick();
        }
    }

    private void Update()
    {
        if (m_isPressed && !m_isHolding)
        {
            m_timer += Time.deltaTime;
            if (m_timer >= m_holdDuration)
            {
                m_isHolding = true;
                OnHoldClick();
            }
        }
    }
}

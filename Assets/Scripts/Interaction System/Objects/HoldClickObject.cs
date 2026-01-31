using UnityEngine;

public class HoldClickObject : InteractionController
{
    [SerializeField] private GameObject m_roomToActivate;

    protected override void OnHoldClick()
    {

        if (m_roomToActivate != null)
        {
            m_roomToActivate.SetActive(true);
        }
        else
        {
            return;
        }
        transform.root.gameObject.SetActive(false);
    }
}

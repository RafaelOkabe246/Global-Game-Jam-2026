using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class Ui_Element : MonoBehaviour
{
    public UnityEvent onOpenEvent;

    public virtual void OpenUiElement()
    {
        gameObject.SetActive(true);
    }

    public virtual void CloseUiElement()
    {
        gameObject.SetActive(false);
    }
}

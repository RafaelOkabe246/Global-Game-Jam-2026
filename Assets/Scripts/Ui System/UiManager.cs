using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiManager : MonoBehaviour
{
    public Ui_Dialogue ui_Dialogue;
    

    public static UiManager instance;
    private void Awake()
    {
        instance = this;
    }


    public void OpenUI(Ui_Element ui_Element)
    {
        ui_Element.onOpenEvent?.Invoke();
        ui_Element.gameObject.SetActive(true);
    }

    public void CloseUi(Ui_Element ui_Element)
    {
        ui_Element.gameObject.SetActive(false);
    }
}

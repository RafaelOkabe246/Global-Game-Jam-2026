using UnityEngine;

public class MultiClickObject : InteractionController
{
    protected override void OnMultiClick(int clickQuantity)
    {
        Debug.Log("Multi Clicado");
    }
}

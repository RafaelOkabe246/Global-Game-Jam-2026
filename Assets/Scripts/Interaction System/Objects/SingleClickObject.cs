using UnityEngine;

public class SingleClickObject : InteractionController
{
    protected override void OnSingleClick()
    {
        Debug.Log("Conversa com o NPC");
    }
}

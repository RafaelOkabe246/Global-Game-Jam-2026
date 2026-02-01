using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour //Esse script serve apenas para testar o inventario na cena
{
    public GridManager GridManager;
    public List<ItemID> ItensToTest;

    private void Start()
    {
        Invoke(nameof(InventorySimulation), 1.0f);
    }

    public void InventorySimulation()
    {

        if (GridManager == null)
        {
            return;
        }

        if (ItensToTest.Count == 0)
        {
            return;
        }

        GridManager.UpdateGrid(ItensToTest);
    }
}

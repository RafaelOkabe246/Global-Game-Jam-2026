using UnityEngine;

public enum ItemCategory { Culpado, Arma, Motivacao }

public enum ItemID { Nenhum, Faca, dica1, joao, }

[System.Serializable]
public struct ItemInfo
{
    public Tip tipInfo;
    //public ItemID Id;
    public ItemCategory Category;
    public Sprite Icon;
}


//Essa parte precisa adaptar, pq n queria mexer no sistema de dialogo que vc fez.
[CreateAssetMenu(fileName = "DatabaseItens", menuName = "Inventario/Database")]
public class ItemDatabase : ScriptableObject
{
    public ItemInfo[] AllItems;
}

using UnityEngine;

[CreateAssetMenu(fileName = "New Ending", menuName = "Test")]
public class EndingsSO : ScriptableObject
{
    public string EndingName;

    public ItemID Culprit;
    public ItemID Weapon;
    public ItemID Motivation;

    [TextArea(5, 10)]
    public string EndingDescription;
}

using UnityEngine;

[CreateAssetMenu(fileName ="Tip Event",menuName ="Events")]
public class Tip : ScriptableObject
{
    [TextArea(3,10)]
    public string tipText;
    [Range(1,3)]
    public int priority;
}

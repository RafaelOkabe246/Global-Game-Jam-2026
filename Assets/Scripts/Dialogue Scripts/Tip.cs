using UnityEngine;


[CreateAssetMenu(fileName ="Tip Event",menuName ="Tip Events")]
public class Tip : ScriptableObject
{
    [TextArea(3,10)]
    public string tipText;
    [Range(1,3)]
    public int priority;

    public TipOrigin tipOrigin;
}

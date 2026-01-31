using UnityEngine;
using UnityEngine.UI;

public class MinimapUpdater : MonoBehaviour
{
    [System.Serializable]
    public struct RoomSprite
    {
        public Rooms Room;
        public Sprite Sprite;
    }

    [SerializeField] private Image m_minimapImage;
    [SerializeField] private RoomSprite[] m_roomSprites;

    private void OnEnable()
    {
        RoomIdentifier.OnRoomChanged += UpdateMinimap;

        UpdateMinimap(RoomIdentifier.CurrentRoom);
    }

    private void OnDisable()
    {
        RoomIdentifier.OnRoomChanged -= UpdateMinimap;
    }

    private void UpdateMinimap(Rooms newRoom)
    {
        foreach (var item in m_roomSprites)
        {
            if (item.Room == newRoom)
            {
                m_minimapImage.sprite = item.Sprite;
                break;
            }
        }
    }
}

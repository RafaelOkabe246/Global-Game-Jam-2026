using UnityEngine;
using System;

public class RoomIdentifier : MonoBehaviour
{
    public static Rooms CurrentRoom { get; private set; } = Rooms.Saguão;

    public static event Action<Rooms> OnRoomChanged; //não quis fazer uma classe separada pq é só um evento

    public Rooms RoomID;

    private void OnEnable()
    {
        if (CurrentRoom != RoomID)
        {
            CurrentRoom = RoomID;
            OnRoomChanged?.Invoke(CurrentRoom);
        }
    }
}

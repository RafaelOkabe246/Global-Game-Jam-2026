using UnityEngine;

public class LevelMusic : MonoBehaviour
{
    public AudioClip Music;
    void Start()
    {
        SoundSystem.Instance.PlayMusic(Music);
    }
}

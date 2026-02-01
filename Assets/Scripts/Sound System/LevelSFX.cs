using UnityEngine;

public class LevelSFX : MonoBehaviour
{
    public float Cooldown = 0.5f;
    public AudioClip SFX;

    private float m_lastPlayTime;

    public void PlaySomeSFX()
    {
        if (Time.time - m_lastPlayTime >= Cooldown)
        {
            SoundSystem.Instance.PlaySFX(SFX);
            m_lastPlayTime = Time.time;
        }
    }
}

using UnityEngine;
using UnityEngine.Audio;

public class SoundSystem : MonoBehaviour
{
    public static SoundSystem Instance;

    [Header("Audio Mixer")]
    public AudioMixer AudioMixer;

    [Header("Audio Options")]
    [Range(0.0001f, 1f)] public float MasterVolume = 0.5f;
    [Range(0.0001f, 1f)] public float MusicVolume = 0.5f;
    [Range(0.0001f, 1f)] public float SFXVolume = 0.5f;

    [Header("Audio Sources")]
    public AudioSource MusicSource;
    public AudioSource SFXSource;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject); 
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        LoadConfig();
    }

    public void SetMasterVolume(float value)
    {
        MasterVolume = value;
        ApplyVolume("MasterVolume", value);
        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        MusicVolume = value;
        ApplyVolume("MusicVolume", value);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value)
    {
        SFXVolume = value;
        ApplyVolume("SFXVolume", value);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

    public void ApplyVolume(string parameterName, float linearVolume)
    {
        float dB = Mathf.Log10(Mathf.Clamp(linearVolume, 0.0001f, 1f)) * 20f;
        AudioMixer.SetFloat(parameterName, dB);
    }

    public void LoadConfig()
    {
        SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume", 0.5f));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.5f));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 0.5f));
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (MusicSource.clip == clip)
        {
            return;    
        }
        MusicSource.clip = clip;
        MusicSource.Play();
    }
}

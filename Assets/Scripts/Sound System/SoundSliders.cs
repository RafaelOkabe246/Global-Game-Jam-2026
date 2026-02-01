using UnityEngine;
using UnityEngine.UI;

public class SoundSliders : MonoBehaviour
{
    public enum VolumeType { Master, Music, SFX }

    [Header("Config")]
    public VolumeType Type;
    private Slider m_slider;

    private void Awake()
    {
        m_slider = GetComponent<Slider>();
    }

    private void Start()
    {
        UpdateSliderValue();

        m_slider.onValueChanged.AddListener(delegate { OnSlideValueChanged(); });
    }

    private void UpdateSliderValue()
    {
        if (SoundSystem.Instance == null)
        {
            return;
        }

        switch (Type)
        {
            case VolumeType.Master:
                m_slider.value = SoundSystem.Instance.MasterVolume;
                break;
            case VolumeType.Music:
                m_slider.value = SoundSystem.Instance.MusicVolume;
                break;
            case VolumeType.SFX:
                m_slider.value = SoundSystem.Instance.SFXVolume;
                break;
        }
    }

    private void OnSlideValueChanged()
    {
        if (SoundSystem.Instance == null)
        {
            return;
        }

        switch (Type)
        {
            case VolumeType.Master:
                SoundSystem.Instance.SetMasterVolume(m_slider.value);
                break;
            case VolumeType.Music:
                SoundSystem.Instance.SetMusicVolume(m_slider.value);
                break;
            case VolumeType.SFX:
                SoundSystem.Instance.SetSFXVolume(m_slider.value);
                break;
        }
    }
}

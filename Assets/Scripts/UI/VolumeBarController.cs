using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeBarController : MonoBehaviour
{
    public AudioMixer mixer;
    public string volumeParameter = "Volume";
    private Slider slider;

    void Start()
    {
        slider = GetComponent<Slider>();

        if (!PlayerPrefs.HasKey(volumeParameter))
        {
            Debug.Log("Volume not set");
            PlayerPrefs.SetFloat(volumeParameter, 1f);
        }

        LoadSetting();


    }

    void LoadSetting()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter);
    }

    public void Save()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
        PlayerPrefs.Save();
        Apply();
    }

    void Apply()
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(PlayerPrefs.GetFloat(volumeParameter)) * 20);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Toggle screenShakeToggle;

    [SerializeField] private AudioMixer sfxMixer;
    [SerializeField] private AudioMixer musicMixer;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("SFXVolume"))
        {
            Debug.Log("SFX volume not set");
            PlayerPrefs.SetFloat("SFXVolume", 1f);
        }

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            Debug.Log("Music volume not set");
            PlayerPrefs.SetFloat("MusicVolume", 1f);
        }

        if (!PlayerPrefs.HasKey("ScreenShake"))
        {
            Debug.Log("Screen shake not set");
            PlayerPrefs.SetInt("ScreenShake", 1);
        }

        //Debug.Log("SFX volume: " + PlayerPrefs.GetFloat("SFXVolume"));
        //Debug.Log("Music volume: " + PlayerPrefs.GetFloat("MusicVolume"));
        Load();
    }

    private void Load()
    {
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        screenShakeToggle.isOn = PlayerPrefs.GetInt("ScreenShake") == 1;

        Set();
    }

    public void Save()
    {
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        PlayerPrefs.SetInt("ScreenShake", screenShakeToggle.isOn ? 1 : 0);

        PlayerPrefs.Save();
        
        Set();
    }

    private void Set()
    {
        sfxMixer.SetFloat("SFXVolume", Mathf.Log10(sfxSlider.value) * 20);
        musicMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
    }

    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
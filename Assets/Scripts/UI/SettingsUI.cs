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

    private const string SFX_PARAM = "SFXVolume";
    private const string MUSIC_PARAM = "MusicVolume";
    private const string SCREENSHAKE_PARAM = "ScreenShake";

    void Start()
    {
        /*if (!PlayerPrefs.HasKey(SFX_PARAM))
        {
            Debug.Log("SFX volume not set");
            PlayerPrefs.SetFloat(SFX_PARAM, 1f);
        }

        if (!PlayerPrefs.HasKey(MUSIC_PARAM))
        {
            Debug.Log("Music volume not set");
            PlayerPrefs.SetFloat(MUSIC_PARAM, 1f);
        }
        */
        if (!PlayerPrefs.HasKey(SCREENSHAKE_PARAM))
        {
            Debug.Log("Screen shake not set");
            PlayerPrefs.SetInt(SCREENSHAKE_PARAM, 1);
        }
        /*
        Debug.Log("SFX volume: " + PlayerPrefs.GetFloat(SFX_PARAM));
        Debug.Log("Music volume: " + PlayerPrefs.GetFloat(MUSIC_PARAM));
        */
        Load();
    }

    private void Load()
    {
        /*
        sfxMixer.SetFloat(SFX_PARAM, Mathf.Log10(PlayerPrefs.GetFloat(SFX_PARAM)) * 20);
        musicMixer.SetFloat(MUSIC_PARAM, Mathf.Log10(PlayerPrefs.GetFloat(MUSIC_PARAM)) * 20);

        sfxSlider.value = PlayerPrefs.GetFloat(SFX_PARAM);
        musicSlider.value = PlayerPrefs.GetFloat(MUSIC_PARAM);
        */
        screenShakeToggle.isOn = PlayerPrefs.GetInt(SCREENSHAKE_PARAM) == 1;
    }

    public void Save()
    {
        /*
        PlayerPrefs.SetFloat(SFX_PARAM, sfxSlider.value);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat(MUSIC_PARAM, musicSlider.value);
        PlayerPrefs.Save();
        */
        PlayerPrefs.SetInt(SCREENSHAKE_PARAM, screenShakeToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();

        
        //Set();
    }
    /*
    private void Set()
    {
        sfxMixer.SetFloat(SFX_PARAM, Mathf.Log10(sfxSlider.value) * 20);
        musicMixer.SetFloat(MUSIC_PARAM, Mathf.Log10(musicSlider.value) * 20);
    }
    */
    public void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
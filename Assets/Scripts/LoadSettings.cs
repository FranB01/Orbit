using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSettings : MonoBehaviour
{

    private const string SFX_PARAM = "SFXVolume";
    private const string MUSIC_PARAM = "MusicVolume";
    private const string SCREENSHAKE_PARAM = "ScreenShake";

    [SerializeField] private AudioMixer sfxMixer;
    [SerializeField] private AudioMixer musicMixer;
    

    void Start()
    {
        if (!PlayerPrefs.HasKey(SFX_PARAM))
        {
            Debug.Log("SFX volume not set");
            PlayerPrefs.SetFloat(SFX_PARAM, 1f);
        }

        if (!PlayerPrefs.HasKey(MUSIC_PARAM))
        {
            Debug.Log("Music volume not set");
            PlayerPrefs.SetFloat(MUSIC_PARAM, 1f);
        }

        if (!PlayerPrefs.HasKey(SCREENSHAKE_PARAM))
        {
            Debug.Log("Screen shake not set");
            PlayerPrefs.SetInt(SCREENSHAKE_PARAM, 1);
        }

        sfxMixer.SetFloat(SFX_PARAM, Mathf.Log10(PlayerPrefs.GetFloat(SFX_PARAM)) * 20);
        musicMixer.SetFloat(MUSIC_PARAM, Mathf.Log10(PlayerPrefs.GetFloat(MUSIC_PARAM)) * 20);
        
        
        
    }


}

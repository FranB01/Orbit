using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private bool paused = false;
    public bool canPause = true;
    private AudioSource sfxAudioSource;
    private int coins = 0;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip musicClip;

    void Start()
    {
        sfxAudioSource = GetComponentInChildren<AudioSource>();
        //Time.timeScale = 1;
    }

    public void TogglePause()
    {
        if (canPause)
        {
            paused = !paused;
            if (paused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    void Pause()
    {
        Time.timeScale = 0;
    }

    void Unpause()
    {
        Time.timeScale = 1;
    }

    public bool IsPaused()
    {
        return paused;
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator GameOver()
    {
        canPause = false;
        yield return new WaitForSecondsRealtime(1f);
        RestartLevel();
    }

    public void GetCoin()
    {
        coins++;
        Debug.Log("Current coins: " + coins);
        sfxAudioSource.PlayOneShot(coinClip);
        
    }

    public IEnumerator Win()
    {
        Debug.Log("Win! :D");
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<UIController>().Win(coins);
    }
}
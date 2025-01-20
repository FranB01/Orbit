using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    private bool paused = false;
    private AudioSource sfxAudioSource;
    private int coins = 0;
    [SerializeField] private AudioClip coinClip;
    [SerializeField] private AudioClip musicClip;

    // Start is called before the first frame update
    void Start()
    {
        sfxAudioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TogglePause()
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
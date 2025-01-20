using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    private GameControl gc;
    private GameObject pausePanel;
    [SerializeField] private SettingsUI settingsUI;
    [SerializeField] private Sprite[] coinCounterSprites;
    
    // Start is called before the first frame update
    void Start()
    {
        gc = FindObjectOfType<GameControl>();
        pausePanel = transform.Find("PausePanel").gameObject;
    }   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
            settingsUI.gameObject.SetActive(false);
        }
    }

    public void TogglePause()
    {
        pausePanel.SetActive(!pausePanel.activeSelf);
        gc.TogglePause();
    }

    public void ButtonRestart()
    {
        gc.RestartLevel();
    }

    public void ButtonSettings()
    {
        settingsUI.gameObject.SetActive(true);
    }

    public void ButtonMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ButtonNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    public void Win(int coins)
    {
        transform.Find("WinPanel").gameObject.SetActive(true);
        GameObject.Find("Coin Counter").GetComponent<Image>().sprite = coinCounterSprites[coins];
    }
}

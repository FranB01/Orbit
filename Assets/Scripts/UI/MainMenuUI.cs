using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void ButtonOpenSettings()
    {
        transform.Find("SettingsMenu").gameObject.SetActive(true);
    }

    public void ButtonOpenLevelSelect()
    {
        transform.Find("LevelSelect").gameObject.SetActive(true);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }

    // CRAPPY, CHANGE IN FINAL VERSION
    public void ButtonLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ButtonCloseLevelSelect()
    {
        transform.Find("LevelSelect").gameObject.SetActive(false);
    }
}
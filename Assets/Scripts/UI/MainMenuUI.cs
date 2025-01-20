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
    public void ButtonLv1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonLv2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void ButtonLv3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void ButtonCloseLevelSelect()
    {
        transform.Find("LevelSelect").gameObject.SetActive(false);
    }
}
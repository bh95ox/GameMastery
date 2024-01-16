using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Panel_Nav : MonoBehaviour
{
    [SerializeField] private GameObject Save_Panel;
    [SerializeField] private GameObject Load_Panel;
    [SerializeField] private GameObject UI_Container;
    [SerializeField] private GameObject PlayOption_Container_;
    [SerializeField] private GameObject Setting_Panel;
    [SerializeField] private GameObject Guide_Panel;

    public void OpenPlayOpt()
    {
        Save_Panel.SetActive(false);
        Load_Panel.SetActive(false);
        PlayOption_Container_.SetActive(true);
    }

    public void OpenLoadPanel()
    {
        UI_Container.SetActive(false);
        Save_Panel.SetActive(false);
        Load_Panel.SetActive(true);
        PlayOption_Container_.SetActive(false);
    }

    public void OpenSavePanel()
    {
        UI_Container.SetActive(false);
        Save_Panel.SetActive(true);
        Load_Panel.SetActive(false);
        PlayOption_Container_.SetActive(false);
    }

    public void MainMenu_Panel()
    {
        UI_Container.SetActive(true);
        Save_Panel.SetActive(false);
        Load_Panel.SetActive(false);
        PlayOption_Container_.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenSetting()
    {
        Setting_Panel.SetActive(true);
    }

    public void OpenGuide()
    {
        Guide_Panel.SetActive(true );
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}

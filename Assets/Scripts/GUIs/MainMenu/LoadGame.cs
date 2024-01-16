using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using Managers;

public class LoadGame : MonoBehaviour
{
    [SerializeField] private GameObject Content_Container;
    [SerializeField] private GameObject Warning_Msg_Container;
    [SerializeField] private TextMeshProUGUI Warning_Msg;

    private GameDataManager DataManager;
    private GameManager GameManager;
    private int FileIndex;
    private string FileDirectory;

    private void Awake()
    {
        FileDirectory = Application.persistentDataPath + "/Saves";
    }

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject getDataManager = GameObject.FindWithTag("GameDataManager");
        if (getDataManager != null) { DataManager = getDataManager.GetComponent<GameDataManager>(); }
        else { GameManager.NeedManager("GameDataManager"); }

        for (int i = 0; i < Content_Container.transform.childCount; i++)
        {
            if (Content_Container.transform.GetChild(i).gameObject == this.gameObject)
            {
                FileIndex = i;
            }
        }

    }

    public void LoadData()
    {
        if(File.Exists(FileDirectory + "/File" + FileIndex + ".Json"))
        {
            DataManager.LoadGame(FileIndex);
        }
        else
        {
            Warning_Msg_Container.SetActive(true);
            Warning_Msg.text = "No File Found! Try another File";
        }
    }

    public void CloseMSGBox()
    {
        Warning_Msg_Container.SetActive(false);
    }

}

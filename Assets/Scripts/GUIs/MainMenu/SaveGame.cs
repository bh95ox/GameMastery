using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;
using Managers;

public class SaveGame : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI Warning_Msg;
    [SerializeField] private GameObject Content_Container;
    [SerializeField] private GameObject Load_Container;


    public GameObject WarningObjPanel;

    private GameDataManager DataManager;
    private GameManager GameManager;
    private string FileDirectory;
    private int FileIndex;
    private bool CanSave;

    private void Awake()
    {
        FileDirectory = Application.persistentDataPath + "/Saves";
    }

    private void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        GameObject getDataManager = GameObject.FindWithTag("GameDataManager");
        if(getDataManager != null) { DataManager = getDataManager.GetComponent<GameDataManager>(); }
        else { GameManager.NeedManager("GameDataManager");}

        for (int i = 0; i < Content_Container.transform.childCount; i++)
        {
            if(Content_Container.transform.GetChild(i).gameObject == this.gameObject)
            {
                FileIndex = i;  
            }
        }
    }

    public void SaveData()
    {
        if (File.Exists(FileDirectory + "/File" + FileIndex + ".Json"))
        {
            WarningObjPanel.SetActive(true);
            Warning_Msg.text = "This file contains saved data! would you like to Override the data?";
            
            if (Load_Container.GetComponent<OverriderConfirmation>().Confirmation() == true)
            { DataManager.SaveGame(FileIndex); 
                Debug.Log("File"+FileIndex+".Json has been Override");
            }
        }
        else
        {
            using FileStream Fs = File.Create(FileDirectory + "/File" + FileIndex + ".Json");
            Fs.Close();
            DataManager.SaveGame(FileIndex);
        }
    }

}

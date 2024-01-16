using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverriderConfirmation : MonoBehaviour
{
    public GameObject WarningObjPanel;
    public bool CanSave;

    public bool Confirmation()
    {
        return CanSave;
    }

    public void Yes()
    {
        CanSave = true;
        WarningObjPanel.SetActive(false);
    }

    public void No()
    {
        CanSave = false;
        WarningObjPanel.SetActive(false);
    }
}

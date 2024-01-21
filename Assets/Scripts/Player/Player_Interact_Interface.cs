using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Managers;
using Interfaces;

public class Player_Interact_Interface : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float Interaction_Distance = 3f;
    [SerializeField] private GameObject interaction_UI;
    [SerializeField] private TextMeshProUGUI Interaction_Description;

    private InputManager input;

    private void Start()
    {
        GetNeededManagers();
    }

    private void GetNeededManagers()
    {
        //Grapes the Game Manager
        GameObject GameM = GameObject.FindWithTag("GameManager");

        GameObject GetInputManager = GameObject.FindWithTag("InputManager");// Checks if there is an Input Manager in the scene
        if (GetInputManager != null) { input = GetInputManager.GetComponent<InputManager>(); }//set input from inputManager
        else
        {
            // if No inputManager is found sends request to GameManager to get access to a new InputManager
            GameObject getInputM = GameM.GetComponent<GameManager>().NeedManager("InputManager");// Get the Manager gameobject from the GameManager
            input = getInputM.GetComponent<InputManager>();//set input from new inputManager
        }
    }

    private void Update()
    {
        CheckInterface();
    }

    private void CheckInterface()
    {
        Ray ray = _camera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitObject = false;

        // Checks for IInteractable
        if (Physics.Raycast(ray, out hit, Interaction_Distance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)            {
                hitObject = true;

                Interaction_Description.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                    Debug.Log("Interacting");
                }

            }
        }

        // Checks for IPickable
        if (Physics.Raycast(ray, out hit, Interaction_Distance))
        {
            IPickable pickable = hit.collider.GetComponent<IPickable>();

            if (pickable != null)
            {
                hitObject = true;

                Interaction_Description.text = pickable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    pickable.PickUp();
                    Debug.Log("Picking up");
                }

            }
        }

        interaction_UI.SetActive(hitObject);
    }

   

}

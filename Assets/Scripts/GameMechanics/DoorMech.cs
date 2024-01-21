using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interfaces;

[RequireComponent(typeof(Animator))]
public class DoorMech : MonoBehaviour, IInteractable
{
    private readonly string Description = "Interact with Door";
    private Animator animator;
    private bool isDoorOpen;

    void Start()
    {
        animator = GetComponent<Animator>();
        isDoorOpen = false;
    }

    public string GetDescription()
    {
        return Description;
    }

    public void Interact()
    {
        isDoorOpen = !isDoorOpen; 
    }

    private void Update()
    {
        if (isDoorOpen)
        {
            animator.SetBool("IsDoorOpen", true);
        }
        else
        {
            animator.SetBool("IsDoorOpen", false);
        }
    }


}

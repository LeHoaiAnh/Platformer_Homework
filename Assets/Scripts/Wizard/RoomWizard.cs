using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomWizard : MonoBehaviour
{
    private Wizard wizard;

    private void Awake()
    {
        wizard = GetComponentInChildren<Wizard>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<PlayerMovement>();
            wizard.SetTargetPlayer(player);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            wizard.SetTargetPlayer(null);
        }
    }
}

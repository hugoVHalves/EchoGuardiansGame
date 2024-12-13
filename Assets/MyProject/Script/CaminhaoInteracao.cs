using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhaoInteracao : MonoBehaviour, IInteractable {

    public bool alreadyInteracted;
    public int objetivo = 5;

    public string GetDescription()
    {
        if (alreadyInteracted)
        {
            return "Já interagiu!";
        }
        return "Sabote esse veículo";
    }

    public void Interact()
    {
        if (alreadyInteracted)
        {
            objetivo--;
            Debug.Log("Restam" + objetivo + "caminhões para sabotar");
        }
        else return;
    }
}

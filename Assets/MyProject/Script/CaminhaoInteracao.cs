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
            return "J� interagiu!";
        }
        return "Sabote esse ve�culo";
    }

    public void Interact()
    {
        if (alreadyInteracted)
        {
            objetivo--;
            Debug.Log("Restam" + objetivo + "caminh�es para sabotar");
        }
        else return;
    }
}

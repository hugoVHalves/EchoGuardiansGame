using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaminhaoInteracao : MonoBehaviour, IInteractable {
    [SerializeField] GameObject particula;
    public bool alreadyInteracted = false;
    public int objetivo = 5;

    public string GetDescription()
    {
        if (alreadyInteracted == true)
        {
            return "Já interagiu!";
        }
        return "Sabote esse veículo";
    }

    public void Interact()
    {
        if (alreadyInteracted == true) return;
        else
        {
            ObjManager.instance.Sabote();
            objetivo = ObjManager.instance.objective;
            Debug.Log("Restam " + objetivo + " caminhões para sabotar");
            alreadyInteracted = true;
            particula.SetActive(true);
        }
    }
}

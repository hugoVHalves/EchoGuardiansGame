using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static ObjManager instance;

    public int objective = 5;
    public bool ganhou = false; 

    private void Awake()
    {
        instance = this;
    }

    public void Sabote()
    {      
        objective -= 1;      
    }
    private void Update()
    {
        End();

    }
    private void End()
    {
        if (ganhou == false && objective == 0)
        {
            WinScreenManager.Instance.TelaDeVitoria();
            ganhou = true;
        }

    }
}

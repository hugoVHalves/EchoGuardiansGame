using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    public static ObjManager instance;

    public int objective = 5;

    private void Awake()
    {
        instance = this;
    }

    public void Sabote()
    {
        objective -= 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class apagar : MonoBehaviour
{
    GameObject painelConfig;
    bool gamePaused;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            painelConfig.SetActive(!painelConfig.activeInHierarchy);
            gamePaused = painelConfig.activeInHierarchy;
        }
    }



}

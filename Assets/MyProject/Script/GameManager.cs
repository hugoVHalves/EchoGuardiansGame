using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject painelConfig;
    private bool gamePaused;

    public static GameManager instance;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            painelConfig.SetActive(!painelConfig.activeInHierarchy);
            gamePaused = painelConfig.activeInHierarchy;
        }
    }

}
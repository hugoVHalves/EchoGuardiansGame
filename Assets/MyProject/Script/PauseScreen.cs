using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private Button play, returnToMenu;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject araraScreen;
    public bool gamePaused;

    private void Start()
    {
        play.onClick.AddListener(PauseMenu); returnToMenu.onClick.AddListener(ReturnToMenu);

        pauseScreen.SetActive(false);
        gamePaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) PauseMenu();
    }

    private void PauseMenu()
    {
        pauseScreen.SetActive(!pauseScreen.activeInHierarchy);
        araraScreen.SetActive(!araraScreen.activeInHierarchy);
        gamePaused = pauseScreen.activeInHierarchy;

        if (gamePaused)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    private void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
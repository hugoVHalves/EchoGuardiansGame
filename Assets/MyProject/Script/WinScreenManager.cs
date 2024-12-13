using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreenManager : MonoBehaviour
{
    public static WinScreenManager Instance;
    [SerializeField] private GameObject telaDeVitoria;
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource vitoria;
    [SerializeField] private AudioSource derrota;
    [SerializeField] private AudioSource SomMenu;
    [SerializeField] private GameObject GameplayArara;

    private void Awake()
    {
        Instance = this;
        telaDeVitoria.SetActive(false);
    }

    public void TelaDeVitoria()
    {
        telaDeVitoria.SetActive(true);
        GameplayArara.SetActive(false);
        vitoria.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
    public void JogarNovamente()
    {
        SceneManager.LoadScene(1);
    }
    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(0);
    }
}

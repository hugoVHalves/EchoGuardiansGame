using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uimanager : MonoBehaviour
{
   
    [SerializeField]private GameObject painelMenuinicial;
    [SerializeField] GameObject painelConfig;
    private bool gamePaused;
    [SerializeField] private GameObject GameplayArara;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        painelMenuinicial.SetActive(true);
    }

    public void Jogar()
    {
        SceneManager.LoadScene(1);
        GameplayArara.SetActive(true);
        painelMenuinicial.SetActive(false);

    }
    
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
    }
}

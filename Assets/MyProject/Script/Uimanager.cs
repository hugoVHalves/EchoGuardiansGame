using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Uimanager : MonoBehaviour
{
    
    public static Uimanager Instance;
    [SerializeField]private GameObject painelMenuinicial;
    [SerializeField] GameObject painelConfig;
    private bool gamePaused;
    [SerializeField] private GameObject GameplayArara;
    
    
    [SerializeField] private AudioSource button;
    [SerializeField] private AudioSource vitoria;
    [SerializeField] private AudioSource derrota;
    [SerializeField] private AudioSource SomMenu;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
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
        SomMenu.Stop();
        button.Play();
        

    }
    
    public void SairJogo()
    {
        Debug.Log("Sair do Jogo");
        Application.Quit();
        button.Play();
    }
   

   
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     [SerializeField] private Button Start;
    [SerializeField] private Button Quit;
    [SerializeField] private Button menu;



    private void Awake()
    {
        Start.onClick.AddListener(StartButtonHandler);
        Quit.onClick.AddListener(QuitButtonHandler);
        menu.onClick.AddListener(MainMenuHanlder);
    }

    private void StartButtonHandler()
    {
        SceneManager.LoadScene("LVL");
    }
       private void MainMenuHanlder()
    {
        SceneManager.LoadScene("MainMenu"); 
    }
    private void QuitButtonHandler()
    {
        Application.Quit();
    }
}

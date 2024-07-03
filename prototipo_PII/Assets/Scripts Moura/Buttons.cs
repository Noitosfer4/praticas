using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importante ressaltar o uso disso
using UnityEngine.UI;

public class Buttons : MonoBehaviour // Nomes das cenas, entre aspas, devem ser os mesmos nomes das cenas na pasta Scenes
{
    [SerializeField] private GameObject thisPanel; //Vulgo pause panel - Mas pode funcionar para mais coisas, por isso não pus um nome específico
    [SerializeField] private GameObject nextPanel; //Vulgo option panel - - Mas pode funcionar para mais coisas, por isso não pus um nome específico
    [SerializeField] private GameObject pauseButton;
    public void MenuButton()
    {
        SceneManager.LoadScene("Menu"); 
    }//Ele pode ser usado como o botão de [retorno] para o menu das cenas de créditos,opçoes,etc.

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits"); 
    }

    public void GameButton()
    {
        SceneManager.LoadScene("Chapter 1"); 
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("Options"); 
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void SwitchPanelButton()
    {
        thisPanel.SetActive(false);
        nextPanel.SetActive(true);
    }

    public void TurnOffPanelButton()
    {
        thisPanel.SetActive(false);
    }

    public void PauseButton()
    {
        pauseButton.SetActive(false);
        thisPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void UnPauseButton()
    {
        pauseButton.SetActive(true);
        thisPanel.SetActive(false);
        Time.timeScale = 1;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Importante ressaltar o uso disso

public class Buttons : MonoBehaviour // Nomes das cenas, entre aspas, devem ser os mesmos nomes das cenas na pasta Scenes
{
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
    public void BackButton()
    {
        Application.Quit();
    }
}
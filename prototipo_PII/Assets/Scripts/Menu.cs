using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pause;
    public GameObject opcoes;
   public static void LoadScenes(string cena) { 
        SceneManager.LoadScene(cena);
    }

    public void socorro(){
        opcoes.SetActive(true);
        pause.SetActive(false);
    }

    public void pausaai() { 
        pause.SetActive(true);
    }

    public void voltaai() { 
        pause.SetActive(false);
    }
    public void fechaessaporra(){
        Application.Quit();
    }

    public void voltapause(){
        opcoes.SetActive(false);
        pause.SetActive(true);
    }

    
}

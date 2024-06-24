using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] public float typingSpeed = 0.03f; //N�o quero que essa vari�vel seja alterada por outros c�digos.
    private string fullText;
    private string currentText = "";
    [SerializeField] private GameObject thisPanel;
    [SerializeField] private GameObject nextPanel;


    //Rotina de inic�o para evitar bugs
    void Start()
    {
        fullText = GetComponent<TextMeshProUGUI>().text;
        StartCoroutine(TypeSentences());
        nextPanel.SetActive(false);
        Time.timeScale = 1;
    }

    //Serve para mostrar o texto aos poucos
    private IEnumerator TypeSentences()
    {
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        thisPanel.SetActive(false);
        nextPanel.SetActive(true); //Caso n�o tenha um pr�ximo painel. Use um objeto vazio como refer�ncia (Da pra testar com texto tamb�m depois)
    }
}
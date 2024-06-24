using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] public float typingSpeed = 0.03f; //Não quero que essa variável seja alterada por outros códigos.
    private string fullText;
    private string currentText = "";
    [SerializeField] private GameObject thisPanel;
    [SerializeField] private GameObject nextPanel;


    //Rotina de inicío para evitar bugs
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
        nextPanel.SetActive(true); //Caso não tenha um próximo painel. Use um objeto vazio como referência (Da pra testar com texto também depois)
    }
}
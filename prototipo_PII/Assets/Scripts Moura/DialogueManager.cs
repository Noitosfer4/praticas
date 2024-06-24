using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] dialogueBoxes; // Array/Lista de caixas de dialogo (Uso isso pois os personagens tem caixas de dialogo com cores e icones diferentes)
    public TextMeshProUGUI[] dialogueTexts; // Array/Lista de componentes de texto (Associei um "espaço" de texto para que haja as linha de dialogos)
    // Como o ícone de cada personagem já está associado a sua caixa de dialogo, não há necessidade de pedi-lo.(Ent Caixa de dialogo é o "Índice")
    [SerializeField]private float typingSpeed = 0.03f; //Não quero que essa variável seja alterada por outros códigos.
    public bool isTyping = false;
    public bool dialogueBoxesAreOpen = false;

    private Coroutine typingCoroutine;//Talvez eu possa usar o enumarator de vez

    public void ShowDialogue(int characterIndex, string dialogueText)
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        HideAllDialogues(); //Primeiro limpa o dialogo anterior
        dialogueBoxes[characterIndex].SetActive(true); //Depois ativa a caixa de dialogo.
        typingCoroutine = StartCoroutine(TypeSentences(dialogueTexts[characterIndex], dialogueText));
        dialogueBoxesAreOpen = true;
    }

    public void HideAllDialogues()
    {
        foreach (var dialogueBox in dialogueBoxes) //Faz uma varredura para limpar os dialogos(Um pouco mal otimizado)
        {
            dialogueBox.SetActive(false);
        }
        dialogueBoxesAreOpen = false;
    }
    private IEnumerator TypeSentences(TextMeshProUGUI dialogueTexts, string sentence)
    {
        isTyping = true;
        dialogueTexts.text = "";

        for (int i = 0; i < sentence.Length; i++)
        {
            dialogueTexts.text += sentence[i];
            yield return new WaitForSeconds(typingSpeed);
            
            //while (isTyping && Input.GetKeyDown(KeyCode.Space))
            //{
            //    dialogueTexts.text = sentence; // Display the entire sentence
            //    isTyping = false;
            //    yield break; // Exit the coroutine
            //}
        }
        isTyping = false;
    }
}

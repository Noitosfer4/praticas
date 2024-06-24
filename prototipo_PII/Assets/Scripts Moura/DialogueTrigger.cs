using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager; //Cria um espa�o para associar o objeto DialogueManager que contem o script de mesmo nome.
    public string[] dialogueSentences; //Cria um array/lista de strings/linhas de falas.
    public int[] characterIndices; // Array/lista para especificar qual personagem fala na senten�a.
    private int currentSentenceIndex = 0; //Contador de index de senten�as.Serve como indicador para que o ultimo dialogo possa ser encerrado.
    private bool dialogueStarted = false; //Precurssor ao trigger. Inicia desativo, mas em contato com o trigger ativa o dialogo.

    private void OnTriggerEnter2D(Collider2D other) //Trigger de inicio do dialogo.
    {
        if (other.CompareTag("Player") && !dialogueManager.isTyping) //Compara tag para saber se � player.
        {
            if (!dialogueStarted) //Meio redundante, mas pode ser considerada como uma safety measure.
            {
                StartDialogue(); //Chama a fun��o de inicio de dialogo
                BoxCollider2D collider = GetComponent<BoxCollider2D>(); //Pega informa��o do colisor
                collider.enabled = false; //Desativa o colisor e ,consequentemente, o trigger. Impossibilitando do dialogo iniciar mais de uma vez.
            }
        }
    }
    private void Update() //Tive que separar a continua��o do dialogo do trigger e associa-la a uma tecla
    {
        if(dialogueStarted && Input.GetKeyDown(KeyCode.Space)) //A tecla escolhida foi o espa�o
        {
            ShowNextSentence(); //Chama a fun��o de pr�ximo dial�go/senten�a
        }
    }

    public void StartDialogue() //Fun��o de start do dialogo
    {
        dialogueStarted = true;//Essa fun��o tem apenas o objetivo de dizer que o dialogo iniciou
        currentSentenceIndex = 0;
        ShowNextSentence(); //Por isso, ela chama a fun��o ShowNextSentence que � a fun��o que armazena e mostra os index e os dialogos. 
    }

    public void ShowNextSentence() //Fun��o de pr�ximo dialogo
    {
        if (currentSentenceIndex < dialogueSentences.Length) //Index serve como guia para o loop (5 dialogos = index vai at� 5 = ele mostra os 5 dialogos)
        {
            int characterIndex = characterIndices[currentSentenceIndex]; //Introduz a variavel de index do personagem e associa ela ao indice do personagem.
            dialogueManager.ShowDialogue(characterIndex, dialogueSentences[currentSentenceIndex]); //Chama a fun��o do otro script - O DialogueManager e associa tudo.
            currentSentenceIndex++; //Incrementa o index da fala atual para poder mudar de fala.
        }
        else
        {
            dialogueManager.HideAllDialogues(); //chama a fun��o de finaliza��o de dialogo do DialogueManager.
            dialogueStarted = false;
        }
    }
}

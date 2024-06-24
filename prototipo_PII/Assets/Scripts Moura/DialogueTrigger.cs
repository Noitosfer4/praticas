using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager; //Cria um espaço para associar o objeto DialogueManager que contem o script de mesmo nome.
    public string[] dialogueSentences; //Cria um array/lista de strings/linhas de falas.
    public int[] characterIndices; // Array/lista para especificar qual personagem fala na sentença.
    private int currentSentenceIndex = 0; //Contador de index de sentenças.Serve como indicador para que o ultimo dialogo possa ser encerrado.
    private bool dialogueStarted = false; //Precurssor ao trigger. Inicia desativo, mas em contato com o trigger ativa o dialogo.

    private void OnTriggerEnter2D(Collider2D other) //Trigger de inicio do dialogo.
    {
        if (other.CompareTag("Player") && !dialogueManager.isTyping) //Compara tag para saber se é player.
        {
            if (!dialogueStarted) //Meio redundante, mas pode ser considerada como uma safety measure.
            {
                StartDialogue(); //Chama a função de inicio de dialogo
                BoxCollider2D collider = GetComponent<BoxCollider2D>(); //Pega informação do colisor
                collider.enabled = false; //Desativa o colisor e ,consequentemente, o trigger. Impossibilitando do dialogo iniciar mais de uma vez.
            }
        }
    }
    private void Update() //Tive que separar a continuação do dialogo do trigger e associa-la a uma tecla
    {
        if(dialogueStarted && Input.GetKeyDown(KeyCode.Space)) //A tecla escolhida foi o espaço
        {
            ShowNextSentence(); //Chama a função de próximo dialógo/sentença
        }
    }

    public void StartDialogue() //Função de start do dialogo
    {
        dialogueStarted = true;//Essa função tem apenas o objetivo de dizer que o dialogo iniciou
        currentSentenceIndex = 0;
        ShowNextSentence(); //Por isso, ela chama a função ShowNextSentence que é a função que armazena e mostra os index e os dialogos. 
    }

    public void ShowNextSentence() //Função de próximo dialogo
    {
        if (currentSentenceIndex < dialogueSentences.Length) //Index serve como guia para o loop (5 dialogos = index vai até 5 = ele mostra os 5 dialogos)
        {
            int characterIndex = characterIndices[currentSentenceIndex]; //Introduz a variavel de index do personagem e associa ela ao indice do personagem.
            dialogueManager.ShowDialogue(characterIndex, dialogueSentences[currentSentenceIndex]); //Chama a função do otro script - O DialogueManager e associa tudo.
            currentSentenceIndex++; //Incrementa o index da fala atual para poder mudar de fala.
        }
        else
        {
            dialogueManager.HideAllDialogues(); //chama a função de finalização de dialogo do DialogueManager.
            dialogueStarted = false;
        }
    }
}

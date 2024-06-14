using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleD : MonoBehaviour
{
    public bool cantDialogue;
    public GameObject hidesomething;

    public TextMeshProUGUI maria;
    public TextMeshProUGUI lucinda; 
    public GameObject qmaria; 
    public GameObject qlucinda; 
    public GameObject pan; 
    private bool panelActive; 
    public GameObject cap1; 
    public float delayObjeto = 6f;
    public int currentDialogueIndex = 0; 
    private int currentCharIndex = 0; 
    public bool firstDialogueCalled = false; 
    private bool isTyping = false; 
    public bool skip = false; 
    private string[] falas = {
        "Oi pessoal, como vocês estão? Tudo bem? Eu sou a Maria. hoje é o dia do meu primeiro desfile pelo Ilê Aiyê! Ele está fazendo 50 anos. Eu tô tão feliz!!! Tem muito tempo que eu espero por isso. Eu tô muito ansiosa também.",
        "Ahh! Pra quem não sabe, o Ilê Aiyê é o primeiro bloco afro do Brasil. Nasceu aqui na Liberdade, na ladeira do Curuzu. É aqui que eu moro com minha Vó Lucinda. Eu e ela também somos filhas da liberdade, que nem o Ilê Aiyê.",
        "Benção Vó",
        "Benção Vó, cheguei",
        "Como foi a aula, minha filha?",
        "Foi boa, vó.",
        "Essa minha vó é fada madrinha, Dona Lucinda. Ela tem um restaurante aqui na Liberdade. Todo mundo conhece ela, porque ela foi Deusa do Ébano, mas também porque ela é muito simpática.",
        "E aí, tá animada?",
        "Muito!!!",
        "E ansiosa?",
        "Um pouco também.",
        "Só um pouquinho?",
        "Muitão.",
        "Venha, vamos almoçar. Vó fez um almoço especial pra você se animar.",
        "E aí, tava bom?",
        "Tava delicioso, Vó.",
        "Agora suba, minha princesa. Vá tomar um banho que nós precisamos pegar a sua fantasia.",
        "Terminei, Vó, tô pronta!",
        "Pois venha que eu vou fazer as suas tranças.",
        "Ficaram bonitas?",
        "Lindas! Tá parecendo uma Candace.",
        "Pronto, trança feita. Agora vamos buscar sua fantasia."
    };

    private string[] nomes = {
        "Maria",
        "Maria",
        "Maria",
        "Maria",
        "Lucinda",
        "Maria",
        "Maria",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Lucinda"
    };

    
    void Start(){
        qlucinda.SetActive(false);
        qmaria.SetActive(false);
        panelActive = false;
        
    }

   void Update(){
        
        if (Input.GetKeyDown(KeyCode.Space)){
            skip = false; 
            if (!panelActive){
                ShowNextDialogue();
            }
        }
        if (hidesomething.active == false) { ShowFirstDialogue(); }

    }

  public void ShowFirstDialogue(){
    if (!firstDialogueCalled){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Maria"){
            ShowMariaDialogue();
        } else {
            ShowLucindaDialogue();
        }
        firstDialogueCalled = true;
        
    }
}
    public GameObject qMaria;
public void ShowNextDialogue(){
    if (firstDialogueCalled && currentDialogueIndex < falas.Length && !isTyping){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Maria"){
            ShowMariaDialogue();
        } else {
            ShowLucindaDialogue();
        }
            if (currentDialogueIndex == 3)
            {
                cantDialogue = true;
                
            }
            if(cantDialogue == true)
            {
                qmaria.SetActive(false);
            }
            else
            {
                qmaria.SetActive(true);
                
            }
        }
}

    void ShowMariaDialogue(){
        ActivateDialogueBox(qmaria); 
        DeactivateDialogueBox(qlucinda); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], maria));
        currentDialogueIndex++;
    }

    void ShowLucindaDialogue(){
        ActivateDialogueBox(qlucinda); 
        DeactivateDialogueBox(qmaria); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], lucinda));
        currentDialogueIndex++;
    }

    
    void ActivateDialogueBox(GameObject dialogueBox){
        dialogueBox.SetActive(true);
        panelActive = true; 
    }

    
    void DeactivateDialogueBox(GameObject dialogueBox){
        dialogueBox.SetActive(false);
        panelActive = false; 
    }

    IEnumerator DisplayText(string text, TextMeshProUGUI textComponent){
        isTyping = true; // Inicia a digitação
        textComponent.text = ""; 

        while (currentCharIndex < text.Length){
            textComponent.text += text[currentCharIndex];
            currentCharIndex++;
            if (skip) { // Se o botão de skip foi pressionado
                textComponent.text = text; // Exibe todo o texto imediatamente
                break; // Sai do loop
            }
            yield return new WaitForSeconds(0.05f); 
        }

        currentCharIndex = 0;
        isTyping = false; // Termina a digitação
        panelActive = false; 
        skip = false; // Reseta o botão de skip

        // Verifica se o diálogo atual é o último diálogo
        if (text == "Pronto, trança feita. Agora vamos buscar sua fantasia.") {
            // Carrega a nova cena
            SceneManager.LoadScene("avisop"); // Substitua "NomeDaNovaCena" pelo nome da sua cena
        }
    }

    public void SkipDialogue(){
        skip = true; // Define isSkipping como true quando o botão "skip" é pressionado
    }
}

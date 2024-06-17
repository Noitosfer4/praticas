using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleD4 : MonoBehaviour
{
    public TextMeshProUGUI maria;
    public TextMeshProUGUI lucinda;
    public TextMeshProUGUI dete; 
    public GameObject qmaria; 
    public GameObject qlucinda;
    public GameObject qdete; 
    public GameObject cap2; 
    public GameObject mariaper; 
    public GameObject lucindaper; 
    public float delayObjeto = 6f;
    private int currentDialogueIndex = 0; 
    private int currentCharIndex = 0; 
    public bool firstDialogueCalled = false; 
    private bool isTyping = false; 
    public bool skip = false;
    bool panelActive;
    public GameObject deteper;

    private string[] falas = {
        "A gente vai na casa de Dona Elisabete pegar o seu turbante. Tá pronta?",
        "Tô pronta. ",
        "Ô de casa! Ô Elisabete!",
        "Oi! É tú Lucinda?",
        "É ela mesma. ",
        "Chegue pra cá. Entre."
        
    };

    private string[] nomes = {
        "Lucinda",
        "Maria",
        "Lucinda",
        "Elisabete",
        "Lucinda",
        "Elisabete"
    };

    
    void Start(){
        qlucinda.SetActive(false);
        qmaria.SetActive(false);
        qdete.SetActive(false);
        mariaper.SetActive(false); 
        lucindaper.SetActive(false); 
        deteper.SetActive(false); 
        
    }

   void Update(){
        
        if (Input.GetKeyDown(KeyCode.Space)){
            skip = false; 
            if (!panelActive){
                ShowNextDialogue();
            }
        }

        if(cap2.active == false){
            mariaper.SetActive(true); 
            lucindaper.SetActive(true); 
        }
    }

  public void ShowFirstDialogue(){
    if (!firstDialogueCalled){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Lucinda"){
            ShowLucindaDialogue();
        } else if (currentNome == "Maria"){
            ShowMariaDialogue();
        } else if (currentNome == "Elisabete"){
            ShowVavaDialogue();
        }
        firstDialogueCalled = true;
    }
}

public void ShowNextDialogue(){
    if (firstDialogueCalled && currentDialogueIndex < falas.Length && !isTyping){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Lucinda"){
            ShowLucindaDialogue();
        } else if (currentNome == "Maria"){
            ShowMariaDialogue();
        } else if (currentNome == "Elisabete"){
            ShowVavaDialogue();
        }
    }
}


    void ShowMariaDialogue(){
        ActivateDialogueBox(qmaria); 
        DeactivateDialogueBox(qlucinda); 
        DeactivateDialogueBox(qdete); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], maria));
        currentDialogueIndex++;
    }

    void ShowLucindaDialogue(){
        ActivateDialogueBox(qlucinda); 
        DeactivateDialogueBox(qmaria);
        DeactivateDialogueBox(qdete); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], lucinda));
        currentDialogueIndex++;
    }

   void ShowVavaDialogue(){
    deteper.SetActive(true);
    ActivateDialogueBox(qdete); 
    DeactivateDialogueBox(qmaria); 
    DeactivateDialogueBox(qlucinda); 
    StartCoroutine(DisplayText(falas[currentDialogueIndex], dete));
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
        isTyping = true; 
        textComponent.text = ""; 

        while (currentCharIndex < text.Length){
            textComponent.text += text[currentCharIndex];
            currentCharIndex++;
            if (skip) { 
                textComponent.text = text; 
                break;
            }
            yield return new WaitForSeconds(0.05f); 
        }

        currentCharIndex = 0;
        isTyping = false; 
        panelActive = false; 
        skip = false; 

        
        if (text == "Chegue pra cá. Entre." && !isTyping && qdete.active == true)
        {
            StartCoroutine(LoadSceneAfterDelay("cap3c", 2f));
        }
    }

    public void SkipDialogue(){
        skip = true; 
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(sceneName);
    }
}


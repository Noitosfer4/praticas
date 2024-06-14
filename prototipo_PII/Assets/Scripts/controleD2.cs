using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleD2 : MonoBehaviour
{
    public TextMeshProUGUI maria;
    public TextMeshProUGUI lucinda;
    public TextMeshProUGUI vava; 
    public GameObject qmaria; 
    public GameObject qlucinda;
    public GameObject qvava; 
    public GameObject cap2; 
    public float delayObjeto = 6f;
    private int currentDialogueIndex = 0; 
    private int currentCharIndex = 0; 
    public bool firstDialogueCalled = false; 
    private bool isTyping = false; 
    public bool skip = false;
    bool panelActive;
    private string[] falas = {
        "Ô Vavá, tá aí, Vavá?",
        "Opa, rapaz, olha quem apareceu. Chegue pra cá. Como é que está, Maria?",
        "Tô bem, seu Vavá. E o senhor?"
    };

    private string[] nomes = {
        "Lucinda",
        "Vava",
        "Maria"
    };

    
    void Start(){
        qlucinda.SetActive(false);
        qmaria.SetActive(false);
        qvava.SetActive(false);
    }

   void Update(){
        
        if (Input.GetKeyDown(KeyCode.Space)){
            skip = false; 
            if (!panelActive){
                ShowNextDialogue();
            }
        }
    }

  public void ShowFirstDialogue(){
    if (!firstDialogueCalled){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Lucinda"){
            ShowMariaDialogue();
        } else {
            ShowLucindaDialogue();
        }
        firstDialogueCalled = true;
        
    }
}

public void ShowNextDialogue(){
    if (firstDialogueCalled && currentDialogueIndex < falas.Length && !isTyping){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Vava"){
            ShowMariaDialogue();
        } else {
            ShowLucindaDialogue();
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

    void ShowVavaDialogue(){
        ActivateDialogueBox(qvava); 
        DeactivateDialogueBox(qvava); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], vava));
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

        
        if (text == "Tô bem, seu Vavá. E o senhor?") {
            SceneManager.LoadScene("cap2c");
        }
    }

    public void SkipDialogue(){
        skip = true; 
    }
}


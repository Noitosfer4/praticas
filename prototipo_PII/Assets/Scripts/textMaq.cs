using System.Collections;
using TMPro;
using UnityEngine;

public class textMaq : MonoBehaviour
{
    public float delay = 0.1f; 
    private string fullText;
    private string currentText = "";
    private TextMeshProUGUI textComponent; 
    public GameObject image;
    

    void Start(){
        textComponent = GetComponent<TextMeshProUGUI>();
        fullText = textComponent.text; 
        StartCoroutine(ShowText());        
    }

    IEnumerator ShowText(){
        for (int i = 0; i <= fullText.Length; i++){
            currentText = fullText.Substring(0, i);
            textComponent.text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(1f);
        textComponent.CrossFadeAlpha(0f, 1.5f, false);
        yield return new WaitForSeconds(1.5f);
        image.SetActive(false);
    }
}

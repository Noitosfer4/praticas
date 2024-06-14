using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class maqE : MonoBehaviour
{
    public float delay = 0.1f; 
    private string fullText;
    private string currentText = "";
    private float delayObjeto = 6f;
    public GameObject pane;
    private float delayObjeto1 = 2f;
    public GameObject cap1;
 
    
    void Start(){
        fullText = GetComponent<TextMeshProUGUI>().text; 
        StartCoroutine(ShowText()); 
        cap1.SetActive(false);
    }

    IEnumerator ShowText(){
        for (int i = 0; i <= fullText.Length; i++){
            currentText = fullText.Substring(0, i);
            GetComponent<TextMeshProUGUI>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield return new WaitForSeconds(delayObjeto1);
        pane.SetActive(false);
        cap1.SetActive(true);
    }

    public void UpdateDelay(){
        delay = -1.6f;
        StartCoroutine(DeactivateObjectAfterDelay());
    }

    IEnumerator DeactivateObjectAfterDelay(){
    yield return new WaitForSeconds(delayObjeto);
    pane.SetActive(false);
    cap1.SetActive(true);    
    }
}

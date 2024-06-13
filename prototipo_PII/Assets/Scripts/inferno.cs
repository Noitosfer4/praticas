using System.Collections;
using UnityEngine;

public class Inferno : MonoBehaviour
{
    public GameObject mariaper;
    public GameObject lucindaper;
    public GameObject cap1;
    float delayObjeto = 0.1f;
    public GameObject pandes;

    void Start(){
        mariaper.SetActive(false);
        lucindaper.SetActive(false);
    }

    void Update(){
        if(!cap1.activeInHierarchy && !pandes.activeInHierarchy){
        AtivarPersonagens();
        }
    }

    public void AtivarPersonagens(){

        StartCoroutine(ActivateObjectsAfterDelay());
    }
        
    IEnumerator ActivateObjectsAfterDelay(){
        yield return new WaitForSeconds(delayObjeto);
        lucindaper.SetActive(true);
        mariaper.SetActive(true);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject thisTrigger1;
    [SerializeField] private GameObject thisTrigger2;
    [SerializeField] private Collider2D thatTriggerCollider;
    private void Update()
    {
        if (!thatTriggerCollider.enabled)
        {
            thisTrigger1.SetActive(true);
            thisTrigger2.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player")) //Compara tag para saber se é player.
        {
            SceneManager.LoadScene("avisop");
        }
    }
}

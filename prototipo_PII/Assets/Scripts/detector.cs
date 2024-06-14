using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector : MonoBehaviour
{
    public ControleD2 controleD2; 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "porta")
        {
            Debug.Log("entrou");
            if (!controleD2.firstDialogueCalled)
            {
                controleD2.ShowFirstDialogue();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detector2 : MonoBehaviour
{
    public ControleD4 controleD4; 

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "porta")
        {
            Debug.Log("entrou");
            if (!controleD4.firstDialogueCalled)
            {
                controleD4.ShowFirstDialogue();
            }
        }
    }
}

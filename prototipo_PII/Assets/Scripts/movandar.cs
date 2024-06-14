using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movandar : MonoBehaviour
{
    public float velocidade = 5.0f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * velocidade * Time.deltaTime;
        }
    }
}

using UnityEngine;

public class moverobj2 : MonoBehaviour
{
    public float pontoInicialX;
    public float pontoFinalX;
    public float velocidade = 1.0f;

    void Start()
    {
        transform.position = new Vector3(pontoInicialX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        float novaPosicaoX = Mathf.MoveTowards(transform.position.x, pontoFinalX, velocidade * Time.deltaTime);
        transform.position = new Vector3(novaPosicaoX, transform.position.y, transform.position.z);
    }
}

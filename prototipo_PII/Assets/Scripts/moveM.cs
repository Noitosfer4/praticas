using UnityEngine;

public class moveM : MonoBehaviour
{
    public float pontoInicialX;
    public float pontoFinalX;
    public float velocidade = 1.0f;
    private float startTime;
    private float journeyLength;
    

    void Start()
    {
        startTime = Time.time;
        journeyLength = Mathf.Abs(pontoFinalX - pontoInicialX);
        transform.position = new Vector3(pontoInicialX, transform.position.y, transform.position.z);
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * velocidade;
        float fracJourney = distCovered / journeyLength;
        transform.position = new Vector3(Mathf.Lerp(pontoInicialX, pontoFinalX, fracJourney), transform.position.y, transform.position.z);
    }
}

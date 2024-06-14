using UnityEngine;

public class moveV : MonoBehaviour
{
    public float pontoInicialX;
    public float pontoFinalX;
    public float velocidade = 1.0f;
    private float startTime;
    private float journeyLength;
    private SpriteRenderer spriteRenderer; 
    private bool hasFlipped = false; 
    public ControleD3 controleD3;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Mathf.Abs(pontoFinalX - pontoInicialX);
        transform.position = new Vector3(pontoInicialX, transform.position.y, transform.position.z);
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * velocidade;
        float fracJourney = distCovered / journeyLength;
        transform.position = new Vector3(Mathf.Lerp(pontoInicialX, pontoFinalX, fracJourney), transform.position.y, transform.position.z);

        if (!hasFlipped && Mathf.Abs(transform.position.x - pontoFinalX) < 0.01f)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            hasFlipped = true;
            controleD3.ShowFirstDialogue();
        }
    }
}

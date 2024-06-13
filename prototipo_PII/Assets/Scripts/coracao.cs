using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coracao : MonoBehaviour
{
    public GameObject objetoBase;
    public float velocidadePulso = 1.0f;
    public float magnitudePulso = 0.2f;
    public float escalaMinima = 515f;
    public float escalaMaxima = 520f;
    public Image barra;
    public string CenaDestino;
    private Vector3 escalaOriginal;
    private bool estaPulsando = true;
    private AudioSource audioSource;
    public GameObject pause;
    public GameObject opcoes;

    void Start()
    {
        escalaOriginal = transform.localScale;
        audioSource = GetComponent<AudioSource>();
        pause.gameObject.SetActive(false);
        opcoes.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float escalaAtual = transform.localScale.x;
            if (escalaAtual >= escalaMinima && escalaAtual <= escalaMaxima)
            {
                PararPulso();
                AjustarParaEscalaBase();
                DesativarImagemFacil();
                TrocarDeCenaComDelay(1f);
            } else {
                audioSource.Play();
            }
        }

        if (estaPulsando)
        {
            float fatorEscala = 1.0f + Mathf.Sin(Time.time * velocidadePulso) * magnitudePulso;
            transform.localScale = escalaOriginal * fatorEscala;
        }
    }

    private void PararPulso()
    {
        estaPulsando = false;
    }

    private void AjustarParaEscalaBase()
    {
        transform.localScale = objetoBase.transform.localScale;
    }

    private void DesativarImagemFacil()
    {
        barra.gameObject.SetActive(false);
    }

    public void TrocarDeCenaComDelay(float delay)
    {
        // Invoca a função para trocar de cena após o atraso especificado
        Invoke("TrocarDeCena", delay);
    }

    private void TrocarDeCena()
    {
        // Carrega a cena de destino
        SceneManager.LoadScene(CenaDestino);
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coracaoM : MonoBehaviour
{
    public GameObject objetoBase;
    public float velocidadePulso = 1.0f;
    public float magnitudePulso = 0.2f;
    public float escalaMinima = 515f;
    public float escalaMaxima = 520f;
    public Image barra;
    public string CenaDestino;
    public float brilhoAlvo = 0.5f;
    private Vector3 escalaOriginal;
    private bool estaPulsando = true;
    private AudioSource audioSource;
    public float delay = 1f;
    public GameObject pause;
    public GameObject opcoes;

    void Start()
    {
        escalaOriginal = transform.localScale;
        Camera cameraPrincipal = Camera.main;
        audioSource = GetComponent<AudioSource>();
        pause.gameObject.SetActive(false);
        opcoes.gameObject.SetActive(false);

        if (cameraPrincipal != null)
        {
            // Obtém a cor atual de fundo da câmera
            Color corFundo = cameraPrincipal.backgroundColor;

            // Define uma nova cor de fundo com base no brilho alvo
            Color novaCorFundo = new Color(brilhoAlvo, brilhoAlvo, brilhoAlvo, corFundo.a);

            // Define a nova cor de fundo para a câmera
            cameraPrincipal.backgroundColor = novaCorFundo;
        }
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
                Invoke("voltarp", delay);
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

    public void voltarp()
    {
        // Carrega a cena de destino
        SceneManager.LoadScene("puzzlecoraF");
    }
}

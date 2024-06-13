using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class Musica : MonoBehaviour
{
    public static Musica instancia;
    private AudioSource audioSource;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        string cenaAtual = SceneManager.GetActiveScene().name;
        if(cenaAtual != "menu" && cenaAtual != "creditos" && cenaAtual != "opcoes")
        {
            if(audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
        else
        {
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}

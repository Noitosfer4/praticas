using UnityEngine;

public class cliquemgp : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Minigamescript : MonoBehaviour
{
    public Image sr;
    public List<Sprite> AllSprites;
    private static string[] DialogueWrong = { "Seila, acho que esta faltando algo...", "Nao combina!", "Deve ter uma melhor...", "Essa roupa nao combina com um desfile do Ile!",
    "Tem uma escolha melhor.", "Nao esta certo.", "Nao parece bom", "Tem roupas melhores nao acha Maria?", "Nao!", "Escolha melhor minha filha..."};

    private static string[] DialogueRight = { "Perfeito!!", "Este esta perfeito", "Amei! Perfeito para o desfile", "Este te serviu muito bem!", "Voce está linda com esse" };

    public TMP_Text text;
    public bool correto;
    private void Start()
    {
        correto = false; 
        continuebutton.interactable = false;
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0f);

    }
    private void Update()
    {
        if (correto)
        {
            continuebutton.interactable = true;
           
        }
        else
        {
            continuebutton.interactable = false;
        }
    }
    public void Roupa1() //Correto
    {
        correto = true;
        randomBox();
        dialogotextrg();
    }

    public void Roupa2()
    {
        correto= false;
        randomBox();
        dialogotext();
    }

    public void Roupa3()
    {
        correto = false;
        randomBox();
        dialogotext();
    }
    public void Roupa4()
    {
        correto = false;
        randomBox();
        dialogotext();
    }


    public void randomBox()
    {
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
        if (sr) sr.sprite = AllSprites[Random.Range(0, AllSprites.Count)];
    }
    public void dialogotext()
    {
        string wordToDisplay = RandomWrong();
        text.text = wordToDisplay;
    }
    public void dialogotextrg()
    {
        string wordToDisplay = RandomRight();
        text.text = wordToDisplay;
    }

    private string RandomWrong()
    {
        string randomWord = DialogueWrong[Random.Range(0, DialogueWrong.Length)];
        return randomWord;
    }
    private string RandomRight()
    {
        string randomWord = DialogueRight[Random.Range(0, DialogueRight.Length)];
        return randomWord;
    }

    public Button continuebutton;

    public void Conitunar()
    {
        Debug.Log("faz algo aq, mudar de cena talvez");
    }
}

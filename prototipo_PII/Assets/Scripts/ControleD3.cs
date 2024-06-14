using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControleD3 : MonoBehaviour
{
    public TextMeshProUGUI maria;
    public TextMeshProUGUI lucinda;
    public TextMeshProUGUI vava; 
    public GameObject qmaria; 
    public GameObject qlucinda;
    public GameObject qvava; 
    public float delayObjeto = 6f;
    private int currentDialogueIndex = 0; 
    private int currentCharIndex = 0; 
    public bool firstDialogueCalled = false; 
    private bool isTyping = false; 
    public bool skip = false;
    bool panelActive;
    public GameObject pause;
    public GameObject opcoes;

    private string[] falas = {
        "Tô bem também. Eita. Primeiro desfile! Eu lembro do primeiro desfile da sua Avó.",
        "Tá com um tempo já, viu Vavá.",
        "Tá. Eita e o nosso Ilê Aiyê fazendo cinquenta anos.",
        "Cinquenta anos de história não são 50 dias.",
        "Lembra dos primeiros desfiles? Todo mundo simples vestido de mortalha?",
        "Era umas cem pessoas tocando e cantando por essa rua aí. Minha mãe tinha medo e não deixou eu ir.",
        "O começo foi meio difícil, viu minha filha, precisou de coragem pra botar esse bloco na rua.",
        "Mas medo porquê?",
        "Foi. 74, a ditadura tava em plena força, e as pessoas desapareciam e nunca mais eram vistas pela família. Tem gente que até hoje ninguém sabe o paradeiro.",
        "Eram anos terríveis. E tinha outra coisa, não se podia falar de preconceito, eles diziam que o que existia no Brasil era uma democracia racial.",
        "Hahai, e o preconceito solto no mundo, pior do que hoje.",
        "Para você ver como as coisas eram difíceis, quando o Ilê saiu, os jornais vieram pra cima, acusaram eles de vermelhos, de estarem a serviço de Moscou, disseram que eram negros rebeldes que estavam espalhando o racismo na cidade, “bloco racista, nota destoante”, dizendo que era um espetáculo feio com uma exploração imprópria do tema do racismo! Veja se pode um negócio desses?!",
        "Se uma das razões de ser do bloco é que o povo negro não encontrava lugar nós carnavais de Salvador. O carnaval também não nos incluía. Então a gente fez o nosso espaço, positivamente e de modo pacífico. Mas, sim… na época Antônio Vovô tinha muita influência das revoluções que estavam acontecendo nos Estados Unidos, dos Panteras Negras, do movimento Black Power, então ele queria botar o nome do bloco de Poder Negro. Mas Mãe Hilda aconselhou a ele que era melhor não, que aquele nome poderia dar problema com as autoridades da época.",
        "Outra pessoa que repetiu o conselho foi Seu Arquimedes, que disse a Antônio Vovô a mesma história, que ele não colocasse aquele nome.",
        "Foi. Então decidiu-se por uma votação. Na votação tinha uns quatro nomes. E Antônio Vovô não queria justamente esse nome de Ilê Ayiê, mas não teve jeito. Todo mundo gostou do nome Ilê Ayiê, porque era muito forte e muito significativo.",
        "Mas porque Ilê Aiyê, seu Vavá?",
        "Ilê Aiyê, se for traduzir pro português quer dizer algumas coisas: Barro Preto, Mundo Negro, e outras traduções. O povo gostou muito e ficou esse nome mesmo. O Ilê, minha filha, é um presente que os orixás estavam guardando para a gente. E naquele carnaval de 75, Antônio Vovô, Apolônio e mais quase cem pessoas começaram a trazer esse presente para nós, que foi crescendo e tá aí até hoje, depois de 50 anos",
        "firme, forte e lindo. O mais belo dos belos.",
        "50 anos… Eita que você tá ficando velho, viu Vavá?!",
        "Velho eu já estou. E por falar em velho… Maria, sua vó já lhe contou a história de quando Obaluaiê foi a uma festa no Orun?",
        "Contou não.",
        "Quer que eu conte?",
        "Mas é claro, seu Vavá!",
        "Pois foi assim… Um dia houve uma festa no Orum e todos os orixás foram convidados. Mas Obaluaiê, que tinha acabado de chegar de viagem, não podia entrar.",
        "Oxe, mas porquê não deixaram ele entrar?",
        "por causa da aparência dele e ele ficou só olhando enquanto os outros orixás dançavam no salão.",
        "E ninguém fez nada?",
        "Ó pa isso… Calma. Era esse ponto que eu ia chegar agora mesmo. Pois foi Ogum, tão engenhoso, que viu logo tudo que se passava e não gostou daquilo e tratou de resolver o assunto.",
        "Ahh bom…",
        "Ogum inventou logo uma roupa de palha e deu para Obaluaiê se vestir.",
        "E ele gostou da roupa?",
        "Se gostou? Oxe, gostou demais. Entrou para o meio da festa e foi dançar com os outros orixás. Já Iansã, olhava tudo aquilo de canto. Esperando sua vez de ajudar o tímido Obaluaiê. E assim, quando na dança de Obaluaiê ele alcançou o centro do salão, Oiá mandou um vento que levantou as palhas de seu vestido e mostrou a todo mundo a beleza que se escondia por trás delas. As chagas de Omulú saltaram transformadas em pipoca, e todos os orixás se admiraram da beleza daquele que se escondia sob as palhas de dendê. E desse dia em diante, todos ficaram sabendo que o que aquelas palhas escondiam não era a feiúra e sim o belo. E muito belo!",
        "Que história linda seu Vavá!",
        "muito linda a história Vavá. Ó, Maria, tá na hora de nós irmos.",
        "Já vó? Queria ouvir outra.",
        "Seria muito bom passar a tarde toda aqui escutando as histórias de Vavá, mas temos que ir agora, Maria. A gente ainda tem que passar na casa de Elisabete.",
        "Tá bom. Diga a ela que eu mandei um abraço. Até mais.",
        "Até, Vavá.",
        "Maria. Boa sorte no seu desfile.",
        "Muito obrigado, seu Vavá. Até mais.",
        "Até, Maria."
    };

    private string[] nomes = {
        "Vavá",
        "Lucinda",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Maria",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Maria",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Maria",
        "Vavá",
        "Maria",
        "Vavá",
        "Maria",
        "Vavá",
        "Maria",
        "Vavá",
        "Maria",
        "Lucinda",
        "Maria",
        "Lucinda",
        "Vavá",
        "Lucinda",
        "Vavá",
        "Maria",
        "Vavá"
    };

    void Start()
    {
        qlucinda.SetActive(false);
        qmaria.SetActive(false);
        qvava.SetActive(false);
        pause.SetActive(false);
        opcoes.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            skip = false;
            if (!panelActive)
            {
                ShowNextDialogue();
            }
        }
    }

    public void ShowFirstDialogue()
    {
        if (!firstDialogueCalled)
        {
            string currentNome = nomes[currentDialogueIndex];
            if (currentNome == "Maria")
            {
                ShowMariaDialogue();
            }
            else if (currentNome == "Lucinda")
            {
                ShowLucindaDialogue();
            }
            else
            {
                ShowVavaDialogue();
            }
            firstDialogueCalled = true;
        }
    }

    public void ShowNextDialogue()
    {
        if (firstDialogueCalled && currentDialogueIndex < falas.Length && !isTyping)
        {
            string currentNome = nomes[currentDialogueIndex];
            if (currentNome == "Maria")
            {
                ShowMariaDialogue();
            }
            else if (currentNome == "Lucinda")
            {
                ShowLucindaDialogue();
            }
            else
            {
                ShowVavaDialogue();
            }
        }
    }

    void ShowMariaDialogue()
    {
        ActivateDialogueBox(qmaria);
        DeactivateDialogueBox(qlucinda);
        DeactivateDialogueBox(qvava);
        StartCoroutine(DisplayText(falas[currentDialogueIndex], maria));
        currentDialogueIndex++;
    }

    void ShowLucindaDialogue()
    {
        ActivateDialogueBox(qlucinda);
        DeactivateDialogueBox(qmaria);
        DeactivateDialogueBox(qvava);
        StartCoroutine(DisplayText(falas[currentDialogueIndex], lucinda));
        currentDialogueIndex++;
    }

    void ShowVavaDialogue()
    {
        ActivateDialogueBox(qvava);
        DeactivateDialogueBox(qmaria);
        DeactivateDialogueBox(qlucinda);
        StartCoroutine(DisplayText(falas[currentDialogueIndex], vava));
        currentDialogueIndex++;
    }

    void ActivateDialogueBox(GameObject dialogueBox)
    {
        dialogueBox.SetActive(true);
        panelActive = true;
    }

    void DeactivateDialogueBox(GameObject dialogueBox)
    {
        dialogueBox.SetActive(false);
        panelActive = false;
    }

    IEnumerator DisplayText(string text, TextMeshProUGUI textComponent)
    {
        isTyping = true;
        textComponent.text = "";

        while (currentCharIndex < text.Length)
        {
            textComponent.text += text[currentCharIndex];
            currentCharIndex++;
            if (skip)
            {
                textComponent.text = text;
                break;
            }
            yield return new WaitForSeconds(0.05f);
        }

        currentCharIndex = 0;
        isTyping = false;
        panelActive = false;
        skip = false;

        if (text == "Até, Maria.")
        {
            SceneManager.LoadScene("cap3");
        }
    }

    public void SkipDialogue()
    {
        skip = true;
    }
}

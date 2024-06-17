using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controleD5 : MonoBehaviour
{
    public TextMeshProUGUI maria;
    public TextMeshProUGUI lucinda;
    public TextMeshProUGUI dete; 
    public GameObject qmaria; 
    public GameObject qlucinda;
    public GameObject qdete; 
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
    "Nós viemos pegar o turbante de Maria.",
    "Oi dona Elisabete, a senhora tá bem?",
    "To bem, sim, minha filha. E você, tá animada pro desfile? Cheguem entrem pra cá.",
    "Muito. Dona Elisabete, é verdade que a senhora era muito amiga de mãe Hilda?",
    "Era sim, é verdade.",
    "E como ela era?",
    "Ô minha filha, mãe Hilda era um ser de muito axé, de muita luz.",
    "Ela era daqui mesmo, era?",
    "Era, Ela nasceu aqui mesmo em Salvador, lá no bairro de Brotas. Ela veio com a família morar aqui no Curuzu com 13 anos. Ela foi mãe, mãe-de-santo, conselheira, e tantas coisas mais. Madrinha do Ilê, fundadora de escola, Ialorixá.",
    "Não sei como que dava conta.",
    "Mas dava. Ela até foi indicada a um Nobel, sabia?",
    "Sério? Que incrível!",
    "Pois foi. Aquela música “Comando doce” é em homenagem a ela.",
    "Pra que um elogio melhor do que esse?",
    "É mesmo. Ela liderava através do respeito e do amor que as ações dela geravam.",
    "É verdade que ela desfilou junto com o bloco?",
    "Sim. No primeiro desfile do Ilê ela tava lá. Ela disse a Antônio Vovô que se os filhos dela fossem presos, ela também iria e saiu junto com o bloco pela avenida.",
    "Corajosa!",
    "É, mas não só isso, Mãe Hilda via à frente do seu tempo também.",
    "Você veja as preocupações daquela mulher, naquele tempo, são todas essas questões que nós vivemos discutindo nos dias de hoje: direitos das mulheres, direito a educação para todos, a valorização do povo negro e da história negra, uma educação que emancipe a mente e o corpo.",
    "Quando Antônio Vovô saiu com a ideia do Ilê ela perguntou logo se as meninas iam brincar também.",
    "Tudo isso já passava pela cabeça dela naquela época. E por todas e cada uma dessas questões ela fez um tanto, direta ou indiretamente.",
    "A escolinha mãe Hilda foi uma dessas ações. Ela viu que as crianças mais simples do nosso bairro não tinham com quem ficar quando os pais saiam para trabalhar e teve a ideia de que podia fazer algo por elas e então montou essa escolinha.",
    "Ela deu educação àquelas crianças que estavam ali, de certa forma expostas. E, mais até do que caridade, o que ela fez foi uma política pública, que o estado não podia ou não estava disposto a fazer.",
    "Parece que ela era uma mulher incrível!",
    "Era, ela era uma mulher arretada.",
    "É verdade que a senhora foi Deusa do Ébano, que nem a minha avó?",
    "Sim, Maria. Eu fui Deusa do Ébano. Já faz um tempo, mas eu carrego essa experiência comigo até hoje.",
    "Sempre teve a Noite da Beleza Negra no Ilê?",
    "Ahh. Desde o primeiro ano que se escolhe a rainha, mas a deusa do ébano e a noite da beleza negra vieram um pouco depois.",
    "Mas é tudo parte de uma mesma história, minha filha.",
    "A estética afro era desvalorizada, não havia mulheres negras disputando concursos de beleza. E o que a sociedade dizia influenciava a forma como a gente se via.",
    "Muitas gente tinha vergonha dos seus cabelos, dos seus cachos, de fazer uma trança, de colocar um turbante.",
    "É tanto que no começo só as meninas mais simples vindas da periferia, vindas do candomblé, como eu e sua vó, tinham a coragem de participar do concurso.",
    "E o concurso da beleza negra veio justamente contra isso, para mostrar que ninguém precisava se medir por uma regra que alguém inventou para nos desumanizar, uma padrão que nos faz sentir desconfortável com quem nós somos.",
    "É muito bonito ver a transformação das meninas que passaram por lá, como elas começaram a se sentir mais confiantes, com uma coragem renovada de ser quem são e de seguir o que querem, de conquistar o que querem.",
    "Foi Assim que a senhora se sentiu Vó?",
    "Foi. Eu senti uma Lucinda diferente nascendo ali e depois dali, uma Lucinda mais corajosa, com mais entendimento do meu lugar e da minha história, mais disposição para defender e expor minha religião, minha beleza e cultura negras.",
    "Antes eu não tinha a noção de negritude, de consciência negra, foi o Ilê Aiyê que me ensinou.",
    "Isso é uma revolução minha filha, é uma mudança muito potente no interior da pessoa.",
    "Minha filha, olhe a hora! A conversa tá muito boa Elisabete. Mas nós temos que pegar o resto da fantasia. Vamo, Maria.",
    "Até de noite, dona Elisabete.",
    "Até, Maria, boa sorte. Bom desfile.",
    "Tchau, Até mais tarde."
};


    private string[] nomes = {
    "Lucinda",
    "Maria",
    "Elisabete",
    "Maria",
    "Elisabete",
    "Maria",
    "Elisabete",
    "Maria",
    "Elisabete",
    "Lucinda",
    "Elisabete",
    "Maria",
    "Lucinda",
    "Elisabete",
    "Lucinda",
    "Maria",
    "Elisabete",
    "Maria",
    "Elisabete",
    "Elisabete",
    "Lucinda",
    "Elisabete",
    "Elisabete",
    "Lucinda",
    "Elisabete",
    "Maria",
    "Lucinda",
    "Maria",
    "Elisabete",
    "Maria",
    "Elisabete",
    "Lucinda",
    "Elisabete",
    "Lucinda",
    "Elisabete",
    "Lucinda",
    "Maria",
    "Lucinda",
    "Elisabete",
    "Lucinda",
    "Maria",
    "Elisabete",
    "Lucinda"
};

    void Start()
    {
        qlucinda.SetActive(false);
        qmaria.SetActive(false);
        qdete.SetActive(false);
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

    public void ShowFirstDialogue(){
    if (!firstDialogueCalled){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Lucinda"){
            ShowLucindaDialogue();
        } else if (currentNome == "Maria"){
            ShowMariaDialogue();
        } else if (currentNome == "Elisabete"){
            ShowVavaDialogue();
        }
        firstDialogueCalled = true;
    }
}

    public void ShowNextDialogue(){
    if (firstDialogueCalled && currentDialogueIndex < falas.Length && !isTyping){
        string currentNome = nomes[currentDialogueIndex];
        if (currentNome == "Lucinda"){
            ShowLucindaDialogue();
        } else if (currentNome == "Maria"){
            ShowMariaDialogue();
        } else if (currentNome == "Elisabete"){
            ShowVavaDialogue();
        }
    }
}

    void ShowMariaDialogue(){
        ActivateDialogueBox(qmaria); 
        DeactivateDialogueBox(qlucinda); 
        DeactivateDialogueBox(qdete); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], maria));
        currentDialogueIndex++;
    }

    void ShowLucindaDialogue(){
        ActivateDialogueBox(qlucinda); 
        DeactivateDialogueBox(qmaria);
        DeactivateDialogueBox(qdete); 
        StartCoroutine(DisplayText(falas[currentDialogueIndex], lucinda));
        currentDialogueIndex++;
    }

   void ShowVavaDialogue(){
    ActivateDialogueBox(qdete); 
    DeactivateDialogueBox(qmaria); 
    DeactivateDialogueBox(qlucinda); 
    StartCoroutine(DisplayText(falas[currentDialogueIndex], dete));
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

        if (text == "Tchau, Até mais tarde.")
        {
            SceneManager.LoadScene("cap4");
        }
    }

    public void SkipDialogue()
    {
        skip = true;
    }
}

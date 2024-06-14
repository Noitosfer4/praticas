using UnityEngine;

public class moverobj2 : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    float horizontal;
    float vertical;
    public ControleD controleD;

    public float runSpeed = 20.0f;

    void Update()
    {
        // Verifica se o contador de diálogos é maior que 2
        if (controleD.currentDialogueIndex > 2)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            if (horizontal > 0 || horizontal == 0 && spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = false;
            }
            else if(horizontal < 0 || horizontal == 0 && spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = true;
            }
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Dialogo"))
        {
            controleD.cantDialogue = false;
            controleD.qmaria.SetActive(true);
            runSpeed = 0;
            // Incrementa o contador de diálogos
            controleD.currentDialogueIndex++;
        }
    }
}

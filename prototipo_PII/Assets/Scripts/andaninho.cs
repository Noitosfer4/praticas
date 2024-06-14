using UnityEngine;

public class andaninho : MonoBehaviour
{

    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer, sprite2;
    float horizontal;
    float vertical;
    public ControleD2 controleD2;

    public float runSpeed = 20.0f;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        {
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

        controleD2.ShowFirstDialogue();
        runSpeed = 0;

       }

    }


}
using UnityEngine;

public class moverobj2 : MonoBehaviour
{

    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    float horizontal;
    float vertical;

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

          Debug.Log("awake");

       }

    }


}
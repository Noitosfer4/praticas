using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{
    public float speed;
    public Transform target;
    public SpriteRenderer spriteRenderer;

    void Update()
    {
       
        Vector2 direction = (target.position - transform.position).normalized;
       
        spriteRenderer.flipX = direction.x > 0;
       
    }
}

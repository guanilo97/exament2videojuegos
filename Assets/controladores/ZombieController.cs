using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private bool morir;
    private const int animacion_muerte = 1;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    public int velocidad = 2;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.flipX = true;
        if (morir != true)
        {
            rb.velocity = new Vector2(-velocidad, rb.velocity.y);
        }
        else
        {
            animator.SetInteger("estado", animacion_muerte);
            Destroy(this.gameObject, 1);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "kunai")
            morir = true;
    }
}

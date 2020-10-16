using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    private PuntajeController puntajeController;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 5);
        puntajeController = FindObjectOfType<PuntajeController>();
        Debug.Log(puntajeController.Getpuntaje());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(10, rb.velocity.y);
        spriteRenderer.flipX = false;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombie")
        {
            Destroy(this.gameObject);
            puntajeController.addpunto(10);
            Debug.Log(puntajeController.Getpuntaje());
        }

    }
}

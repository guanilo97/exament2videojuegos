using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ninjaController : MonoBehaviour
{
    public PuntajeController puntajeController;
    public float altura = 0;
    private bool caer;
    private bool morir;
    private bool trepar;
    public AudioClip audiosalto;
    public AudioClip audiodisparo;
    private AudioSource _audioSource;
    public GameObject kunai;
    public GameObject kunai1;
    public Transform position;
    public Transform position1;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sp;
    public int velocidad = 3;
    public int saltar = 1;
    public static int vidas = 3;
    public Text VidasText;
    private const int animacion_quieto = 0;
    private const int animacion_correr = 1;
    private const int animacion_saltar = 2;
    private const int animacion_deslizar = 4;
    private const int animacion_morir = 6;
    private const int animacion_lanzar = 7;
    private const int animacion_trepar = 3;
    private const int animacion_caer = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
        _audioSource = GetComponent<AudioSource>();
        Debug.Log(puntajeController.Getpuntaje());
    }

    // Update is called once per frame
    void Update()
    {
        VidasText.text = "Vidas : " + vidas;
        if (morir != true)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            rb.gravityScale = 10;
            animator.SetInteger("estado_animacion", animacion_quieto);
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.velocity = new Vector2(velocidad, rb.velocity.y);
                animator.SetInteger("estado_animacion", animacion_correr);
                sp.flipX = false;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.velocity = new Vector2(-velocidad, rb.velocity.y);
                animator.SetInteger("estado_animacion", animacion_correr);
                sp.flipX = true;
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                rb.velocity = new Vector2(rb.velocity.x, saltar);
                animator.SetInteger("estado_animacion", animacion_saltar);
                _audioSource.PlayOneShot(audiosalto);
            }
            if (Input.GetKey(KeyCode.A))
            {
                
                rb.gravityScale = 0.1f;
                animator.SetInteger("estado_animacion", animacion_caer);
                caer = true;
            }
            if (Input.GetKey(KeyCode.C))
            {

                animator.SetInteger("estado_animacion", animacion_deslizar);
            }
            if (trepar == true)
            {

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.velocity = new Vector2(0, 5);
                    animator.SetInteger("estado_animacion", animacion_trepar);

                }
               if (Input.GetKey(KeyCode.DownArrow))
                {
                    rb.velocity = new Vector2(0, -5);
                    animator.SetInteger("estado_animacion", animacion_trepar);

                }
               
                //trepar = false;
            }
            if (Input.GetKeyUp(KeyCode.X))
            {
                if (sp.flipX == false)
                {
                    Instantiate(kunai, position.position, Quaternion.identity);
                    animator.SetInteger("estado_animacion", animacion_lanzar);
                    _audioSource.PlayOneShot(audiodisparo);
                }
                //else
                //{
                //    Instantiate(kunai1, position1.position, Quaternion.identity);
                //    animator.SetInteger("estado_animacion", animacion_lanzar);
                //    _audioSource.PlayOneShot(audiodisparo);
                //}

            }

        }
        else
        {
            animator.SetInteger("estado_animacion", animacion_morir);
        }



    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "zombie")
        {
            vidas = vidas - 1;

            if (vidas == 0)
            {
                morir = true;
            }
        }
        if(other.gameObject.tag=="suelo")
        {
            if (altura >= 10 && caer == false)
            {
                altura = 0;
                morir = true;
            }
        }
        if (other.gameObject.name == "piso2")
        {
            altura = 1.90f;
        }
        if (other.gameObject.name == "piso3")
        {
            altura = 10f;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "escalera")
        {
            trepar = true;
            Debug.Log("colision jajaja");
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "escalera")
        {
            trepar = false;
            Debug.Log("colision");
        }
    }
}

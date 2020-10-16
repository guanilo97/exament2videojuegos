using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonajeController : MonoBehaviour
{
    // Start is called before the first frame update
    public PuntajeController puntajeController;
    private bool morir;
    private bool atacar;
    private bool trepar;
    private bool caer;
    public AudioClip audiosalto;
    public AudioClip audiodisparo;
    public AudioClip audiomoneda;
    private AudioSource _audioSource;
    public GameObject kunai;
    public GameObject kunai1;
    public Transform position;
    public Transform position2;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sp;
    public int velocidad = 3;
    public int saltar = 1;
    private const int animacion_quieto = 0;
    private const int animacion_correr = 1;
    private const int animacion_saltar = 2;
    private const int animacion_lanzar = 3;
    private const int animacion_morir = 4;
    private const int animacion_trepar = 5;
    private const int animacion_caer = 6;
    private const int animacion_atacarninja = 7;
    //private const int animacion_morir = 4;
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
        if (morir != true || atacar!=true) {
            //atacar = false;
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
            if (Input.GetKey(KeyCode.C))
            {
               
                rb.gravityScale = 1;
                animator.SetInteger("estado_animacion", animacion_caer);
            }
            if (Input.GetKey(KeyCode.A))
            {
                atacar = true;
                
                animator.SetInteger("estado_animacion", animacion_atacarninja);
            }
            atacar = false;

            if (trepar == true)
            {
               
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    rb.velocity = new Vector2(0,5);
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
            else
            {
                Instantiate(kunai1, position2.position, Quaternion.identity);
                animator.SetInteger("estado_animacion", animacion_lanzar);
                    _audioSource.PlayOneShot(audiodisparo);
                }

        }
        }
        else
        {
            animator.SetInteger("estado_animacion", animacion_morir);
        }

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (atacar == false)
        {
            if (other.gameObject.tag == "zombie")
            {
                Destroy(other.gameObject);
                //atacar = false;
            }
            
        }
        if (other.gameObject.tag == "zombie") { 
            morir = true;
        }
       

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "moneda")
        {
            Destroy(other.gameObject);
            _audioSource.PlayOneShot(audiomoneda);
            puntajeController.addpunto(5);
            Debug.Log(puntajeController.Getpuntaje());
            //   Monedas++;
        }
        if (other.gameObject.name == "escalera")
        {
            trepar = true;
            Debug.Log("colision jajaja");
        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "escalera")
        {
            trepar = false;
            Debug.Log("colision");
        }
    }
}

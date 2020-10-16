using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuntajeController : MonoBehaviour
{
    public Text monedasText;
    private int puntaje =0;
    public void addpunto(int p)
    {
        this.puntaje += p;
        monedasText.text = "puntaje : " +this.puntaje;
    }
    public int Getpuntaje()
    {
        return puntaje;
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

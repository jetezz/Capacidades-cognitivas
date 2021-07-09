using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    
    public static MonoBehaviour sonidos;
    public AudioClip boton;
    public AudioClip atras;
    public AudioClip correcto;
    public AudioClip incorrecto;
    public AudioClip terminar;
    public AudioClip drag;
    public AudioClip drop;
    public AudioClip money;
    public AudioClip click;


    /*
        Memoria     0
        Lenguaje    1
        Percepcion  2
        Atencion    3
        Gnosia      4
        Praxia      5
        Orientacion 6
        Calculo     7
     */
  


    


    AudioSource reproductor;    
    Dictionary<int, AudioClip> listaSonidos;

    private void Awake()
    {
        reproductor = GetComponent<AudioSource>();        
        if (sonidos == null)
        {
            sonidos = this;
            DontDestroyOnLoad(gameObject);
            listaSonidos = new Dictionary<int, AudioClip>();
            listaSonidos.Add(0, boton);
            listaSonidos.Add(1, atras);
            listaSonidos.Add(2, correcto);
            listaSonidos.Add(3, incorrecto);
            listaSonidos.Add(4, terminar);
            listaSonidos.Add(5, drag);
            listaSonidos.Add(6, drop);
            listaSonidos.Add(7, money);
            listaSonidos.Add(8, click);
        }
        else if (sonidos != this)
        {
            Destroy(gameObject);
        }
    }

    public void repSonido(int i)
    {

        reproductor.PlayOneShot(listaSonidos[i]);
    }
  

   
}

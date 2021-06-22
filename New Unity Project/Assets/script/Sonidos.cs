using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos : MonoBehaviour
{
    public GameObject audios;
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
  


    private List<List <AudioClip>> listaAudios;


    AudioSource reproductor;
    AudioSource reproductor2;
    Dictionary<int, AudioClip> listaSonidos;

    private void Awake()
    {
        reproductor = GetComponent<AudioSource>();
        reproductor2 = GetComponent<AudioSource>();
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

            

            listaAudios = new List<List<AudioClip>>();
            listaAudios.Add(audios.GetComponent<audioMemoria>().audiosMemoria);
            listaAudios.Add(audios.GetComponent<audioLenguaje>().audiosLenguaje);
            listaAudios.Add(audios.GetComponent<audioPercepcion>().audiosPercepcion);
            listaAudios.Add(audios.GetComponent<audioAtencion>().audiosAtencion);
            listaAudios.Add(audios.GetComponent<audioGnosia>().audiosgnosias);
            listaAudios.Add(audios.GetComponent<audioPraxia>().audiosPraxia);
            listaAudios.Add(audios.GetComponent<audioOrientacion>().audiosOrientacion);
            listaAudios.Add(audios.GetComponent<audioCalculo>().audiosCalculo);



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
    public void repAudio(int capacidad, int i)
    {
        reproductor2.PlayOneShot(listaAudios[capacidad][i]);
        Debug.Log(i);
    }

   
}

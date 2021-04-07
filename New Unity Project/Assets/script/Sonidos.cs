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





    AudioSource reproductor;
    Dictionary<int, AudioClip> listaAudios;

    private void Awake()
    {
        reproductor = GetComponent<AudioSource>();
        if (sonidos == null)
        {
            sonidos = this;
            DontDestroyOnLoad(gameObject);
            listaAudios = new Dictionary<int, AudioClip>();
            listaAudios.Add(0, boton);
            listaAudios.Add(1, atras);
            listaAudios.Add(2, correcto);
            listaAudios.Add(3, incorrecto);
            listaAudios.Add(4, terminar);
            listaAudios.Add(5, drag);
            listaAudios.Add(6, drop);
            listaAudios.Add(7, money);
            listaAudios.Add(8, click);
        }
        else if (sonidos != this)
        {
            Destroy(gameObject);
        }
    }

    public void repSonido(int i)
    {

        reproductor.PlayOneShot(listaAudios[i]);
    }
    
}

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

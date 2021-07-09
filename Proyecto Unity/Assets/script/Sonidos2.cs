using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonidos2 : MonoBehaviour
{
    public static MonoBehaviour sonidos2;
    AudioSource reproductor;
    private List<List<AudioClip>> listaAudios;
    public GameObject audios;
    public AudioClip click;



    private void Awake()
    {
        reproductor = GetComponent<AudioSource>();
       
        if (sonidos2 == null)
        {
            sonidos2 = this;
            DontDestroyOnLoad(gameObject);
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
        else if (sonidos2 != this)
        {
            Destroy(gameObject);
        }
    }

    public void repAudio(int capacidad, int i)
    {
        reproductor.Stop();
        reproductor.PlayOneShot(listaAudios[capacidad][i]);

        Debug.Log(i);
    }

    public void repSonido()
    {

        reproductor.PlayOneShot(click);
    }
}

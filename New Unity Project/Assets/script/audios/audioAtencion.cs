using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioAtencion : MonoBehaviour
{
    public List<AudioClip> audiosAtencion = new List<AudioClip>();
    public AudioClip audioA0;
    public AudioClip audioA1;
    public AudioClip audioA2;
    public AudioClip audioA3;

    public AudioClip audioF4;
    public AudioClip audioF5;
    public AudioClip audioF6;
    public AudioClip audioF7;
    public AudioClip audioF8;
    public AudioClip audioF9;
   


    private void Awake()
    {       
        audiosAtencion.Add(audioA0);
        audiosAtencion.Add(audioA1);
        audiosAtencion.Add(audioA2);
        audiosAtencion.Add(audioA3);

        audiosAtencion.Add(audioF4);
        audiosAtencion.Add(audioF5);
        audiosAtencion.Add(audioF6);
        audiosAtencion.Add(audioF7);
        audiosAtencion.Add(audioF8);
        audiosAtencion.Add(audioF9);
       
    }
}

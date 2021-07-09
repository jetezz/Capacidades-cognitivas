using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioPercepcion : MonoBehaviour
{
    public List<AudioClip> audiosPercepcion = new List<AudioClip>();
    public AudioClip audioP0;
    public AudioClip audioP1;
   

    private void Awake()
    {

       
        audiosPercepcion.Add(audioP0);
        audiosPercepcion.Add(audioP1);



    }
}

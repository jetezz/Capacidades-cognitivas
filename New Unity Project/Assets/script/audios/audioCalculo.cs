using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioCalculo : MonoBehaviour
{
    public List<AudioClip> audiosCalculo = new List<AudioClip>();
    public AudioClip audioC0;
    public AudioClip audioC1;
    public AudioClip audioC2;
    public AudioClip audioC3;
    public AudioClip audioC4;
    public AudioClip audioC5;
    public AudioClip audioC6;    
    public AudioClip audioC7;
    public AudioClip audioC16;
    public AudioClip audioC17;
   
    private void Awake()
    {

     audiosCalculo.Add(audioC0);
     audiosCalculo.Add(audioC1);
     audiosCalculo.Add(audioC2);
     audiosCalculo.Add(audioC3);
     audiosCalculo.Add(audioC4);
     audiosCalculo.Add(audioC5);
     audiosCalculo.Add(audioC6);
     audiosCalculo.Add(audioC7);     
     audiosCalculo.Add(audioC16);
     audiosCalculo.Add(audioC17);



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioGnosia : MonoBehaviour
{
    public List<AudioClip> audiosgnosias = new List<AudioClip>();
    public AudioClip audioG0;
    public AudioClip audioG1;
    public AudioClip audioG2;
    public AudioClip audioG3;
    

    private void Awake()
    {     
        
       audiosgnosias.Add(audioG0);
       audiosgnosias.Add(audioG1);
       audiosgnosias.Add(audioG2);
       audiosgnosias.Add(audioG3);  

    }
}

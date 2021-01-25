using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class Lista : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject buttonTemplate;
    public GameObject yo;
    


    void Start()
    {
        crearLista();
    }

      public void crearLista()
    {
       
        List<Usuario> usuarios = mainMenu.GetComponent<menu>().usuarios;        
        GameObject g;
        int N = usuarios.Count;

        if (N > 1)
        {
            borrarLista();
        }

        

        for (int i = 0; i < N; i++)
        {            
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = usuarios[i].Name;
            g.transform.GetChild(1).GetComponent<Text>().text = usuarios[i].Description;
            g.transform.GetChild(2).GetComponent<Image>().sprite = usuarios[i].Icon;
        }
        
    }
    public void borrarLista()
    {
        List<Usuario> usuarios = mainMenu.GetComponent<menu>().usuarios;
        int N = usuarios.Count;
        for (int i = 0; i < N-1; i++)
        {
            Debug.Log("entra");
            Destroy(gameObject.transform.GetChild(i).gameObject);
        }
        
    }

    


}

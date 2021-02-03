using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class Lista : MonoBehaviour
{
   
    private GameObject managerUsuarios;  

    public string nombre;
    public string descripcion;
    public bool borrar = false;



    void Start()
    {
        managerUsuarios = GameObject.FindWithTag("MUsu");
        crearLista();
    }

      public void crearLista()
    {
       
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;        
        GameObject g;
        int N = usuarios.Count;        

        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        for (int i = 0; i < N; i++)
        {            
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = usuarios[i].Name;
            g.transform.GetChild(1).GetComponent<Text>().text = usuarios[i].Description;
            g.transform.GetChild(2).GetComponent<Image>().sprite = usuarios[i].Icon;            
            g.SetActive(true);
            g.GetComponent<IdUsuario>().id = usuarios[i].id;
        }
        
    }
    public void anadieUsuario()
    {
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        GameObject g;
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        g = Instantiate(buttonTemplate, transform);
        g.transform.GetChild(0).GetComponent<Text>().text = usuarios[usuarios.Count-1].Name;
        g.transform.GetChild(1).GetComponent<Text>().text = usuarios[usuarios.Count-1].Description;
        g.transform.GetChild(2).GetComponent<Image>().sprite = usuarios[usuarios.Count-1].Icon;
        int newId= darId();
        usuarios[usuarios.Count - 1].id = newId;
        g.GetComponent<IdUsuario>().id = newId;


        g.SetActive(true);
    }
    public void borrarLista()
    {
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        int N = usuarios.Count;
        for (int i = 0; i < N-1; i++)
        {            
            Destroy(gameObject.transform.GetChild(i+1).gameObject);
        }
    }
    public void borrarUsuario(int id)
    {
       
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        int N = usuarios.Count;
        

            for (int i = 0; i < N; i++)
            {            
                if(gameObject.transform.GetChild(i+1).gameObject.GetComponent<IdUsuario>().id == id)
                {               
                Destroy(gameObject.transform.GetChild(i+1).gameObject);
                }
            }
        borrar = false;

        for (int i = 0; i < N; i++)
        {
            if (usuarios[i].id == id)
            {                
                managerUsuarios.GetComponent<ManagerUsuario>().usuarios.Remove(managerUsuarios.GetComponent<ManagerUsuario>().usuarios[i]);
                break;
            }
            
        }

    }
    public int darId()
    {
        int id = 0;
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        int N = usuarios.Count;

        for(int i = 0; i < N; i++)
        {
            if(usuarios[i].id == id)
            {
                id++;
                i = -1;
            }
        }
        
        return id;
    }

    public void botonNuevoUsuario()
    {
        if (nombre.Length != 0)
        {
            List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
            managerUsuarios.GetComponent<ManagerUsuario>().addUser(new Usuario(nombre, descripcion));            
            anadieUsuario();
            managerUsuarios.GetComponent<ManagerUsuario>().guardarUsuarios();
        }
    }


    public void userNom(string n)
    {
        
        nombre = n;
    }
    public void userDesc(string d)
    {
        descripcion = d;
    }

    public void borrarUsuario()
    {
        borrar = true;
    }

}

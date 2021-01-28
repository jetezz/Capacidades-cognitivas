using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ManagerUsuario : MonoBehaviour
{
    public GameObject maincamera;
    public GameObject lista;
    public List<Usuario> usuarios;

    public string nombre;
    public string descripcion;
    public bool borrar = false;



    private void Start()
    {
        usuarios = maincamera.GetComponent<Ejemplojson>().cargarUsuarios();
    }
    public void botonNuevoUsuario()
    {

        if (nombre.Length != 0)
        {
            usuarios.Add(new Usuario(nombre, descripcion));
            lista.GetComponent<Lista>().anadieUsuario();
            maincamera.GetComponent<Ejemplojson>().guardarUsuario(usuarios);
        }
    }

    public void botonGuardar()
    {
        maincamera.GetComponent<Ejemplojson>().guardarUsuario(usuarios);       
    }

    public void borrarUsuario()
    {
        borrar = true;
    }

    public void userNom(string n)
    {
        Debug.Log(n);
        nombre = n;
    }
    public void userDesc(string d)
    {
        descripcion = d;
    }

}

[System.Serializable]
public class Usuario
{
    
   public Usuario(string nombre, string detalles)
   {
       Name = nombre;
       Description = detalles;
   }
   public string Name;
   public string Description;
   public Sprite Icon;
   public int id;
   

}


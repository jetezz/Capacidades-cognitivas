using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public GameObject lista;
    public List<Usuario> usuarios;
    public int contador = 0;
    public string nombre;
    public string descripcion;
    public bool borrar = false;
    public int yo;

    
    public void botonEjercicios()
    {
        SceneManager.LoadScene(1);
    }
    public void botonUsuarios()
    {
        SceneManager.LoadScene(2);
    }
    public void botonEstadisticas()
    {
        SceneManager.LoadScene(3);
    }
    public void botonAtras()
    {
        SceneManager.LoadScene(0);
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
    public void botonNuevoUsuario()
    {

        if (nombre.Length != 0)
        {
            usuarios.Add(new Usuario(nombre, descripcion));
            lista.GetComponent<Lista>().anadieUsuario();
        }
    }  
    
  

    public void borrarUsuario()
    {
        borrar = true;
    }


}

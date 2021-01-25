using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class menu : MonoBehaviour
{
    public GameObject lista;
    public List<Usuario> usuarios;
    public int contador = 0;
    
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
    public void botonNuevoUsuario()
    {        
        usuarios.Add(new Usuario("asd", "asd"));
        lista.GetComponent<Lista>().crearLista();
    }
    public void botonEliminarLista()
    {        
        lista.GetComponent<Lista>().borrarLista();
    }


}

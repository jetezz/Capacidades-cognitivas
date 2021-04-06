using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ManagerEjercicios : MonoBehaviour
{
    public static ManagerEjercicios managerEjercicios;
    public GameObject panelSalir;
    public int respuestaSalir;
    public int ejercicio;
    public int nivel;
    private GameObject managerUsuario;
    public Usuario usuario;
    public List<int> listaEjercicios;


    public static List<T> DesordenarLista<T>(List<T> input)
    {
        List<T> arr = input;
        List<T> arrDes = new List<T>();


        while (arr.Count > 0)
        {
            int val = Random.Range(0, arr.Count);
            arrDes.Add(arr[val]);
            arr.RemoveAt(val);
        }


        return arrDes;
    }
    private void Awake()
    {
        if (managerEjercicios == null)
        {
            managerEjercicios = this;
            DontDestroyOnLoad(gameObject);
            listaEjercicios = new List<int>();          
        }
        else if (managerEjercicios != this)
        {
            Destroy(gameObject);
        }
    }
  


    public void ejerciciosAutomaticos()
    {
        managerUsuario = GameObject.FindWithTag("MUsu");
        usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioSeleccionado();
        
        listaEjercicios = usuario.getPeorEstadistica();
        listaEjercicios = DesordenarLista<int>(listaEjercicios);
        iniciarEjercicio();
    }

    public void iniciarEpecial(int eje, int niv) 
    {
        managerUsuario = GameObject.FindWithTag("MUsu");
        usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioSeleccionado();
        nivel = niv;
        ejercicio = eje;
        irEscena();
        
    }
    public void recibirLista(List<int> ejer)
    {
        listaEjercicios = ejer;
        iniciarEjercicio();
    }
  
    public void iniciarEjercicio()
    {
        if (listaEjercicios.Count > 0)
        {
            managerUsuario = GameObject.FindWithTag("MUsu");
            ejercicio = listaEjercicios[0];
            usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioSeleccionado();
            nivel = usuario.getNivelEstadistica(listaEjercicios[0]);
            listaEjercicios.RemoveAt(0);
            irEscena();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
    void irEscena()
    {
        switch (ejercicio)
        {
            case 0:
                {
                    SceneManager.LoadScene(9);
                    break;
                }
            case 1:
                {
                    SceneManager.LoadScene(8);
                    break;
                }
            case 2:
                {
                    SceneManager.LoadScene(11);
                    break;
                }
            case 3:
                {
                    SceneManager.LoadScene(5);
                    break;
                }
            case 4:
                {
                    SceneManager.LoadScene(7);
                    break;
                }
            case 5:
                {
                    SceneManager.LoadScene(12);
                    break;
                }
            case 6:
                {
                    SceneManager.LoadScene(10);
                    break;
                }
            case 7:
                {
                    SceneManager.LoadScene(6);
                    break;
                }
        }
    }
}



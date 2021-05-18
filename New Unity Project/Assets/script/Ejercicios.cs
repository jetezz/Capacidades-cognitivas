using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Ejercicios : MonoBehaviour
{
    GameObject sonidos;    
    public int id;
    public GameObject panel;
    public string valoresCapacidades;
    public GameObject panelCapacidades;
    public int ejercicio;
    public int nivel;
    public GameObject panelElegirEjercicio;
    public GameObject panelElegirEjercicios;
    List<int> listaEjercicios=new List<int>();
    public void botonCerrarPanel()
    {
        panel.SetActive(false);
       
    }
    public void ActivarPanel()
    {        

        panel.SetActive(true);
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        panel.transform.GetChild(2).GetComponent<Text>().text = usuario.Name;
        panel.transform.GetChild(3).GetComponent<Text>().text = usuario.Description;
        if (usuario.estadisticas.textInicial == false)
        {
            
            panelCapacidades.SetActive(false);
            panel.transform.GetChild(6).gameObject.SetActive(false);
            panel.transform.GetChild(7).gameObject.SetActive(false);
            panel.transform.GetChild(8).gameObject.SetActive(false);
            panel.transform.GetChild(9).gameObject.SetActive(false);


        }
        else
        {
            
            panelCapacidades.SetActive(true);
            valoresCapacidades = string.Format(usuario.getMemoria() + "{0}{0}" + usuario.getLenguaje() + "{0}{0}" + usuario.getPercepcion() + "{0}{0}" + usuario.getAtencion() + "{0}{0}" + usuario.getGnosias() + "{0}{0}" +usuario.getPraxias() + "{0}{0}" + usuario.getOrientacion() + "{0}{0}" + usuario.getCalculo(), Environment.NewLine);

            panelCapacidades.transform.GetChild(2).GetComponent<Text>().text = valoresCapacidades;

            panel.transform.GetChild(6).gameObject.SetActive(true);
            panel.transform.GetChild(7).gameObject.SetActive(true);
            panel.transform.GetChild(8).gameObject.SetActive(true);
            panel.transform.GetChild(9).gameObject.SetActive(true);
        }

        
        
    }

    public void botonTextInicial()
    {
        SceneManager.LoadScene(4);
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);
    }
    public void activarPanelElegir()
    {
        panelElegirEjercicio.SetActive(true);
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);

    }

    public void botonEmpezarEjercicios(int niv)
    {
        GameObject managerEjercicios;
        managerEjercicios = GameObject.FindWithTag("MEje");       
        managerEjercicios.GetComponent<ManagerEjercicios>().iniciarEpecial(ejercicio,niv);
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);


    }


    public void botonSelecionarEjercicio(int eje)
    {
        ejercicio = eje;
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);

    }
    public void ejerciciosEspecificos()
    {
        panelElegirEjercicios.SetActive(true);
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);

    }
    public void sumarEjercicio(int ejer)
    {
        if (listaEjercicios.Count < 8)
        {
            listaEjercicios.Add(ejer);
            sonidos = GameObject.FindWithTag("Sonido");
            sonidos.GetComponent<Sonidos>().repSonido(0);
        }

        mostrarEjercicios();


    }

    void mostrarEjercicios()
    {
        string aux="";
        
        for (int i = 0; i < listaEjercicios.Count; i++)
        {
           switch (listaEjercicios[i])
            {
                case 0:
                    {
                        aux += "Memoria,";
                        break;
                    }
                case 1:
                    {
                        aux += "Lenguaje,";
                        break;
                    }
                case 2:
                    {
                        aux += "Percepción,";
                        break;
                    }
                case 3:
                    {
                        aux += "Atención,";

                        break;
                    }
                case 4:
                    {
                        aux += "Gnosias,";

                        break;
                    }
                case 5:
                    {
                        aux += "Prasias,";
                        break;
                    }
                case 6:
                    {
                        aux += "Orientación,";
                        break;
                    }
                case 7:
                    {
                        aux += "Cálculo,";
                        break;
                    }



            }
        }

        panelElegirEjercicios.transform.GetChild(1).GetComponent<Text>().text = aux;
    }

    public void empezarEjerciciosSeleccionados()
    {
        sonidos = GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);
        GameObject managerEjercicios;
        managerEjercicios = GameObject.FindWithTag("MEje");
        managerEjercicios.GetComponent<ManagerEjercicios>().recibirLista(listaEjercicios);
    }
    public void ejerciciosAutomaticos()
    {
        sonidos=GameObject.FindWithTag("Sonido");
        sonidos.GetComponent<Sonidos>().repSonido(0);
        GameObject managerEjercicios;
        managerEjercicios = GameObject.FindWithTag("MEje");
        managerEjercicios.GetComponent<ManagerEjercicios>().ejerciciosAutomaticos();
    }

    public void cerrarElegirEspecificos()
    {
        panelElegirEjercicios.SetActive(false);
        listaEjercicios.Clear();
        mostrarEjercicios();

    }
}



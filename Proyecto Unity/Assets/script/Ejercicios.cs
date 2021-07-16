using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class Ejercicios : MonoBehaviour
{
    GameObject sonidos;
    public GameObject informacion;
    public int id;
    public GameObject panel;
    public string valoresCapacidades;
    public GameObject panelCapacidades;
    public int ejercicio;
    public int nivel;
    public GameObject panelElegirEjercicio;
    public GameObject panelElegirEjercicios;
    List<int> listaEjercicios=new List<int>();

    private void Start()
    {
        sonidos = GameObject.FindWithTag("Sonido");
    }
    public void botonCerrarPanel()
    {
        panel.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(1);

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
            panel.transform.GetChild(12).gameObject.SetActive(true);


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
            panel.transform.GetChild(12).gameObject.SetActive(false);

        }



    }

    public void botonTextInicial()
    {
        SceneManager.LoadScene(4);
        
        sonidos.GetComponent<Sonidos>().repSonido(0);
    }
    public void activarPanelElegir()
    {
        panelElegirEjercicio.SetActive(true);
        
        sonidos.GetComponent<Sonidos>().repSonido(0);

    }

    public void botonEmpezarEjercicios(int niv)
    {
        GameObject managerEjercicios;
        managerEjercicios = GameObject.FindWithTag("MEje");       
        managerEjercicios.GetComponent<ManagerEjercicios>().iniciarEpecial(ejercicio,niv);
        
        sonidos.GetComponent<Sonidos>().repSonido(0);


    }


    public void botonSelecionarEjercicio(int eje)
    {
        ejercicio = eje;
        if (eje == 0)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text="Memoria";
        }else if (eje == 1)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Lenguaje";
        }
        else if (eje == 2)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Percepci�n";
        }
        else if (eje == 3)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Atenci�n";
        }
        else if (eje == 4)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Gnosias";
        }
        else if (eje == 5)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Praxias";
        }
        else if (eje == 6)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Orientaci�n";
        }
        else if (eje == 7)
        {
            panelElegirEjercicio.transform.GetChild(14).GetComponent<Text>().text = "Calculo";
        }
        
        sonidos.GetComponent<Sonidos>().repSonido(0);

    }
    public void ejerciciosEspecificos()
    {
        panelElegirEjercicios.SetActive(true);
        
        sonidos.GetComponent<Sonidos>().repSonido(0);

    }
    public void sumarEjercicio(int ejer)
    {
        if (listaEjercicios.Count < 8)
        {
            listaEjercicios.Add(ejer);
            
            sonidos.GetComponent<Sonidos>().repSonido(0);
        }

        mostrarEjercicios();


    }
    public void cerrarPanelEjercicioEspecifico()
    {
        panelElegirEjercicio.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(1);
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
                        aux += "Percepci�n,";
                        break;
                    }
                case 3:
                    {
                        aux += "Atenci�n,";

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
                        aux += "Orientaci�n,";
                        break;
                    }
                case 7:
                    {
                        aux += "C�lculo,";
                        break;
                    }



            }
        }

        panelElegirEjercicios.transform.GetChild(1).GetComponent<Text>().text = aux;
    }

    public void empezarEjerciciosSeleccionados()
    {
       
        sonidos.GetComponent<Sonidos>().repSonido(0);
        GameObject managerEjercicios;
        managerEjercicios = GameObject.FindWithTag("MEje");
        managerEjercicios.GetComponent<ManagerEjercicios>().recibirLista(listaEjercicios);
    }
    public void ejerciciosAutomaticos()
    {
        
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
    public void abrirInformacion()
    {
        informacion.SetActive(true);
        sonidos.GetComponent<Sonidos>().repSonido(5);

    }

    public void cerrarInformacion()
    {
        informacion.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(5);


    }
}


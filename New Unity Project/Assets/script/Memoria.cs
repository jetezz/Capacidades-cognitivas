using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Memoria : MonoBehaviour
{
    public GameObject panelFin;
    private GameObject managerEjercicios;
    public GameObject panelNivel1;
    private List<string> preguntasNivel1;
    public int contadorNivel1 = 0;
    public int puntos = 0;
    string maximos;
    public int preguntasMaximas=0;
    
    void Start()
    {
        preguntasNivel1 = new List<string>();
        
        managerEjercicios = GameObject.FindWithTag("MEje");

        if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 1)
        {
            nivel1();
        }else if(managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 2)
        {
            nivel2();
        }
        else if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 3)
        {
            nivel3();
        }
        else if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 4)
        {
            nivel4();
        }
    }

    void nivel1()
    {
        preguntasNivel1.Add("¿Dónde está el hombre?");
        preguntasNivel1.Add("¿Dónde está la pelota?");
        preguntasNivel1.Add("¿Dónde está la sombrilla?");
        maximos = "Puntuacion maxima = 3";
        preguntasMaximas = preguntasNivel1.Count;
       
        panelNivel1.SetActive(true);
        panelNivel1.transform.GetChild(1).GetComponent<Text>().text = preguntasNivel1[contadorNivel1];

    }
    public void botonHombre()
    {
        contadorNivel1++;
        if (contadorNivel1 == 1)
            puntos++;
        siguientePreguntaNivel1();
    }
    public void botonPelota()
    {
        contadorNivel1++;
        if (contadorNivel1 == 2)
            puntos++;
        siguientePreguntaNivel1();
    }
    public void botonSombrilla()
    {
        contadorNivel1++;
        if (contadorNivel1 == 3)
            puntos++;
        siguientePreguntaNivel1();
    }
    public void siguientePreguntaNivel1()
    {
        if (contadorNivel1 < preguntasNivel1.Count)
        {
            panelNivel1.transform.GetChild(1).GetComponent<Text>().text = preguntasNivel1[contadorNivel1];
        }
        else
        {
            panelFin.SetActive(true);
            panelFin.transform.GetChild(3).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(4).GetComponent<Text>().text = maximos;
            if (puntos == 3)
            {
                panelFin.transform.GetChild(5).GetComponent<Text>().text = "Mejora de nivel en memoria a nivel 2";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(2);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(5).GetComponent<Text>().text = "Se mantiene el nivel 1 en memoria";
            }

        }

    }
    void nivel2()
    {

    }
    void nivel3()
    {

    }
    void nivel4()
    {

    }

    public void botonInicio()
    {
        SceneManager.LoadScene(0);
    }
  
}

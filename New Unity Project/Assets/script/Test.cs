using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject panelAviso;
    public GameObject panelPreguntas;
    public List<string> preguntas;
    public int contador = 0;
    public int puntos = 0;
    public int nivel = 0;
    private GameObject managerUsuario;
   

    public void Start()
    {
        preguntas = new List<string>();
        preguntas.Add("¿Sabe en qué año estamos (1 punto)?");
        preguntas.Add("¿En qué época del año? (1 punto)");
        preguntas.Add("¿En qué mes estamos? (1 punto)");
        preguntas.Add("¿Qué día de la semana es hoy? (1 punto)");
        preguntas.Add("¿Qué día del mes es hoy? (1 punto)");
        preguntas.Add("¿En qué país estamos? (1 punto)");
        preguntas.Add("¿Sabes en qué provincia estamos? (1 punto)");
        preguntas.Add("¿En qué ciudad estamos? (1 punto)");
        preguntas.Add("¿Sabes dónde estamos ahora? (1 punto)");       
        preguntas.Add("¿y en qué planta (piso, numero, calle, etc? (1 punto)");
        preguntas.Add("¿Repita estas tres palabras: PESETA-CABALLO-MANZANA? (1 punto por palabra)");
        preguntas.Add("¿Si tinene 30 pesetas y me las vas dando de 3 en 3 ¿Cuantas le van quedando? (1 punto por casa sustracción)");
        preguntas.Add("¿Recuerda las tres palabras que te he dicho antes (PESETA-CABALLO-MANZANA) (1 punto por palabra");
        preguntas.Add("¿Qué es esto?, (mostrar un boligrafo) ¿Qué es esto? (mostrar un reloj)(1 punto por cada objeto)");
        preguntas.Add("Le voy a pedir que repita la siguiente frase: EN UN TRIGAL HABIA CINCO PERROS (1 punto)");
        preguntas.Add("(1)Coja este papel con la mano derecha, (2)doblelo por la mitar, (3)póngalo en la mesa (1 punto por acción)");
        preguntas.Add("Lea esto y haga lo que dice ahí. (Entregar en papel un texto con ordenes concretas (1 punto)");
        preguntas.Add("Escriba una frase, algo que tenga sentido(1 punto)");
        preguntas.Add("Reproduzca este dibujo (entregar en cartulina grande) (1 punto)");


        panelPreguntas.transform.GetChild(0).GetComponent<Text>().text = preguntas[contador];
        managerUsuario = GameObject.FindWithTag("MUsu");
    }

    public void botonQuitarAviso()
    {
        panelAviso.SetActive(false);
    }
    public void botonSiguientePregunta()
    {        
        contador++;
        if (contador < preguntas.Count)
        {
            panelPreguntas.transform.GetChild(0).GetComponent<Text>().text = preguntas[contador];
        }else      
        {
            panelAviso.SetActive(true);
            panelAviso.transform.GetChild(1).gameObject.SetActive(false);
            panelAviso.transform.GetChild(2).gameObject.SetActive(true);
            panelAviso.transform.GetChild(3).gameObject.SetActive(true);
            panelAviso.transform.GetChild(0).GetComponent<Text>().text = "Test finalizado";

            if (puntos > 35)
            {
                panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Error vuelve a realizar la prueba";
            }
            else if(puntos<=35 && puntos >= 24)
            {
                panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Probablemente sin deterioro (nivel 4)";
                nivel = 4;
            }
            else if(puntos <=23 && puntos >= 19)
            {
                panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Deterioro leve (nivel 3)";
                nivel = 3;
            }
            else if(puntos <= 18 && puntos >=14)
            {
                panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Deterioro moderado (nivel 2)";
                nivel = 2;
            }
            else if (puntos <14 )
            {
                panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Deterioro grave (nivel 1)";
                nivel = 1;
            }

            if (nivel > 0)
            {
                Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().usuarios[managerUsuario.GetComponent<ManagerUsuario>().usuarioSeleccionado];
                usuario.memoria(nivel);
                usuario.lenguaje(nivel);
                usuario.percepcion(nivel);
                usuario.atencion(nivel);
                usuario.gnosia(nivel);
                usuario.praxia(nivel);
                usuario.orientacion(nivel);
                usuario.calculo(nivel);
                usuario.estadisticas.textInicial = true;
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();

            }
        }
    }
    public void botonPunto()
    {
        puntos++;
        panelPreguntas.transform.GetChild(3).GetComponent<Text>().text = puntos.ToString();
    }
    public void botonInicio()
    {
        SceneManager.LoadScene(0);
    }
}

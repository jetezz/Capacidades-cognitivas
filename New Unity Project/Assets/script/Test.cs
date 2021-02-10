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
    public int ultimosPuntos = 0;
   

    public void Start()
    {
        preguntas = new List<string>();
        preguntas.Add("¿Sabe en qué año estamos?");
        preguntas.Add("¿En qué época del año?");
        preguntas.Add("¿En qué mes estamos?");
        preguntas.Add("¿Qué día de la semana es hoy?");
        preguntas.Add("¿Qué día del mes es hoy?");
        preguntas.Add("¿En qué país estamos?");
        preguntas.Add("¿Sabes en qué provincia estamos?");
        preguntas.Add("¿En qué ciudad estamos?");
        preguntas.Add("¿Sabes dónde estamos ahora?");       
        preguntas.Add("¿y en qué planta? (numero, calle, etc)");
        preguntas.Add("Repita y recuerda estas palabras: PESETA-CABALLO-MANZANA");       
        preguntas.Add("Si tinene 30 pesetas y le restas 3 ¿Cuantas le quedan? (27)");
        preguntas.Add("Si tinene 27 pesetas y le restas 3 ¿Cuantas le quedan? (24)");
        preguntas.Add("Si tinene 24 pesetas y le restas 3 ¿Cuantas le quedan? (21)");
        preguntas.Add("Si tinene 21 pesetas y le restas 3 ¿Cuantas le quedan? (18)");
        preguntas.Add("Si tinene 18 pesetas y le restas 3 ¿Cuantas le quedan? (15)");
        preguntas.Add("Repita estos 3 numeros al reves : 5-9-2");
        preguntas.Add("¿Recuerdas las palabras PESETA-CABALLO-MANZANA?");
        preguntas.Add("¿Qué es esto?, (mostrar un boligrafo)");
        preguntas.Add("¿Qué es esto? (mostrar un reloj)");
        preguntas.Add("Le voy a pedir que repita la siguiente frase: EN UN TRIGAL HABIA CINCO PERROS");
        preguntas.Add("¿Qué son el rojo y el verde?");
        preguntas.Add("¿Qué son un perro y un gato?");
        preguntas.Add("(1)Coja este papel con la mano derecha, (2)Doblelo por la mitad, (3)Póngalo en la mesa");      
        preguntas.Add("Lea esto y haga lo que dice ahí.");
        preguntas.Add("Escriba una frase, algo que tenga sentido");
        preguntas.Add("Reproduzca este dibujo");


        panelPreguntas.transform.GetChild(0).GetComponent<Text>().text = preguntas[contador];
        managerUsuario = GameObject.FindWithTag("MUsu");
    }

    public void botonQuitarAviso()
    {
        panelAviso.SetActive(false);
    }
    public void botonCorrecto()
    {
        puntos++;
        ultimosPuntos = 1;
        siguientePregunta();
    }
    public void botonIncorrecto()
    {
        ultimosPuntos = 0;
        siguientePregunta();
    }
    public void Boton0puntos()
    {
        ultimosPuntos = 0;
        siguientePregunta();
    }
    public void Boton1puntos()
    {
        puntos++;
        ultimosPuntos = 1;
        siguientePregunta();
    }
    public void Boton2puntos()
    {
        puntos += 2;
        ultimosPuntos = 2;
        siguientePregunta();
    }
    public void Boton3puntos()
    {
        puntos += 3;
        ultimosPuntos = 3;
        siguientePregunta();
    }

    public void botonPreguntaAtras()
    {
        if (contador > 0)
        {
            puntos -= ultimosPuntos;
            contador -= 2;
            siguientePregunta();
           
        }
    }
    void siguientePregunta()
    {
        bool especiales = false;
        contador++;
        if (contador < preguntas.Count)
        {
            panelPreguntas.transform.GetChild(0).GetComponent<Text>().text = preguntas[contador];
            if (contador == 24)
            {
                panelPreguntas.transform.GetChild(3).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(3).GetComponent<Text>().text = "Cierra los ojos";
                panelPreguntas.transform.GetChild(1).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(2).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(4).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(5).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(6).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(7).gameObject.SetActive(false);               
                especiales = true;
            }           

            if(contador==10 || contador == 17 || contador==23)
            {
                panelPreguntas.transform.GetChild(1).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(2).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(4).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(5).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(6).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(7).gameObject.SetActive(true);
                especiales = true;
            }          
            if (contador == 16)
            {
                panelPreguntas.transform.GetChild(1).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(2).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(4).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(5).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(6).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(7).gameObject.SetActive(true);
                especiales = true;
            }
            if (contador == 26)
            {
                panelPreguntas.transform.GetChild(9).gameObject.SetActive(true);
            }
            if(especiales==false)
            {
                panelPreguntas.transform.GetChild(1).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(2).gameObject.SetActive(true);
                panelPreguntas.transform.GetChild(4).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(5).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(6).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(7).gameObject.SetActive(false);
                panelPreguntas.transform.GetChild(3).gameObject.SetActive(false);
            }
            
        }
        else
        {
            finText();
        }
    }
    void finText()
    {
        panelAviso.SetActive(true);
        panelAviso.transform.GetChild(1).gameObject.SetActive(false);
        panelAviso.transform.GetChild(2).gameObject.SetActive(true);
        panelAviso.transform.GetChild(3).gameObject.SetActive(true);
        panelAviso.transform.GetChild(4).gameObject.SetActive(true);
        panelAviso.transform.GetChild(5).gameObject.SetActive(true);

        panelAviso.transform.GetChild(0).GetComponent<Text>().text = "Test finalizado";
        panelAviso.transform.GetChild(5).GetComponent<Text>().text = puntos.ToString();


        if (puntos > 35)
        {
            panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Error vuelve a realizar la prueba";
        }
        else if (puntos <= 35 && puntos >= 24)
        {
            panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Probablemente sin deterioro (nivel 4)";
            nivel = 4;
        }
        else if (puntos <= 23 && puntos >= 19)
        {
            panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Deterioro leve (nivel 3)";
            nivel = 3;
        }
        else if (puntos <= 18 && puntos >= 14)
        {
            panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Deterioro moderado (nivel 2)";
            nivel = 2;
        }
        else if (puntos < 14)
        {
            panelAviso.transform.GetChild(3).GetComponent<Text>().text = "Deterioro grave (nivel 1)";
            nivel = 1;
        }

        if (nivel > 0)
        {
            Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioSeleccionado();
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
    public void botonInicio()
    {
        SceneManager.LoadScene(0);
    }
}

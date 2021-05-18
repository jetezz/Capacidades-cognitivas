using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public GameObject textoPrincipal;
    public GameObject modo0;
    public GameObject modo1;
    public GameObject imagenAlternativa;
    public GameObject textoAlternativo;
    public GameObject botonAtras;

    


    public GameObject panelAviso;
    public GameObject panelPreguntas;   
    public List<pregunta> listaPregunta;
    public int contador = 0;    
    public int nivel = 0;
    private GameObject managerUsuario;
    public int ultimosPuntos = 0;
    GameObject sonidos;


    public void Start()
    {
        sonidos = GameObject.FindWithTag("Sonido");       
        listaPregunta = new List<pregunta>();
        
        listaPregunta.Add(new pregunta("¿Sabes en qué año estamos?", 0));
        listaPregunta.Add(new pregunta("¿Sabes en qué época del año?", 0));
        listaPregunta.Add(new pregunta("¿Sabes en qué mes estamos?", 0));
        listaPregunta.Add(new pregunta("¿Sabes qué día de la semana es hoy?", 0));
        listaPregunta.Add(new pregunta("¿Sabes en qué país estamos?", 0));
        listaPregunta.Add(new pregunta("¿Sabes en qué provincia estamos?", 0));
        listaPregunta.Add(new pregunta("¿Sabes en qué ciudad estamos?", 0));
        listaPregunta.Add(new pregunta("¿Sabes dónde estamos ahora?", 0));
        listaPregunta.Add(new pregunta("¿Sabes en qué dirección? (numero, calle, planta)", 0));
        listaPregunta.Add(new pregunta("Repita y memorice estas palabras: PESETA-CABALLO-MANZANA", 1));
        listaPregunta.Add(new pregunta("Si tienes 30 pesetas y le restas 3 ¿Cuántas le quedan? (27)", 0));
        listaPregunta.Add(new pregunta("Si ahora tienes 27 pesetas y le restas 3 ¿Cuántas le quedan? (24)", 0));
        listaPregunta.Add(new pregunta("Si ahora tienes 24 pesetas y le restas 3 ¿Cuántas le quedan? (21)", 0));
        listaPregunta.Add(new pregunta("Si ahora tienes 21 pesetas y le restas 3 ¿Cuántas le quedan? (18)", 0));
        listaPregunta.Add(new pregunta("Si ahora tienes 18 pesetas y le restas 3 ¿Cuántas le quedan? (15)", 0));
        listaPregunta.Add(new pregunta("Repita estos 3 números al revés : 5-9-2", 1));
        listaPregunta.Add(new pregunta("¿Recuerde estas palabras y repítelas (PESETA-CABALLO-MANZANA)?", 1));
        listaPregunta.Add(new pregunta("¿Qué es esto? (mostrar un boligrafo)", 0));
        listaPregunta.Add(new pregunta("¿Qué es esto? (mostrar un reloj)", 0));
        listaPregunta.Add(new pregunta("Le voy a pedir que repita la siguiente frase: EN UN TRIGAL HABÍA CINCO PERROS", 0));
        listaPregunta.Add(new pregunta("¿Qué son el rojo y el verde?", 0));
        listaPregunta.Add(new pregunta("¿Qué son un perro y un gato?", 0));
        listaPregunta.Add(new pregunta("(coge un papel y dile al usuario estas instrucciones) 1- Coja este papel con la mano derecha, 2- Dóblelo por la mitad, 3- Póngalo en la mesa", 1));
        listaPregunta.Add(new pregunta("Lea esto y haga lo que dice ahí", 0));
        listaPregunta.Add(new pregunta("Escriba una frase, algo que tenga sentido", 0));
        listaPregunta.Add(new pregunta("Reproduzca este dibujo", 0));


        listaPregunta[23].addTexto("Cierra los ojos");
        listaPregunta[25].addImagen();



        panelAviso.SetActive(true);
        
        managerUsuario = GameObject.FindWithTag("MUsu");
    }

    public void botonQuitarAviso()
    {
        sonidos.GetComponent<Sonidos>().repSonido(8);
        panelAviso.SetActive(false);
        siguientePregunta();
    }
    public void botonRespuesta(int pun)
    {
        listaPregunta[contador].puntos = pun;

        contador++;
        siguientePregunta();
        sonidos.GetComponent<Sonidos>().repSonido(8);

       
    }


    public void botonPreguntaAtras()
    {
        if (contador > 0)
        {
            contador--;           
            siguientePregunta();
            sonidos.GetComponent<Sonidos>().repSonido(1);
        }
    }
    void siguientePregunta()
    {
        if (contador == 0)
        {
            botonAtras.SetActive(false);
        }
        else
        {
            botonAtras.SetActive(true);
        }
        limpiar();

        if (contador < listaPregunta.Count)
        {
            textoPrincipal.GetComponent<Text>().text = listaPregunta[contador].preg;
            if (listaPregunta[contador].modo == 0)
            {
                modo0.SetActive(true);
            }
            else
            {
                modo1.SetActive(true);
            }

            if (listaPregunta[contador].imagen == true)
            {
                imagenAlternativa.SetActive(true);
            }

            if (listaPregunta[contador].textoAlternativo == true)
            {
                textoAlternativo.SetActive(true);
                textoAlternativo.GetComponent<Text>().text = listaPregunta[contador].pregTextoAlternativo;
            }
        }
        else
        {
            finText();
        }
    }
    void limpiar()
    {
        modo0.SetActive(false);
        modo1.SetActive(false);
        imagenAlternativa.SetActive(false);
        textoAlternativo.SetActive(false);
    }
    void finText()
    {
        int puntos=0 ;
        panelAviso.SetActive(true);
        panelAviso.transform.GetChild(1).gameObject.SetActive(false);
        panelAviso.transform.GetChild(2).gameObject.SetActive(true);
        panelAviso.transform.GetChild(3).gameObject.SetActive(true);
        panelAviso.transform.GetChild(4).gameObject.SetActive(true);
        panelAviso.transform.GetChild(5).gameObject.SetActive(true);

        for (int i = 0; i < listaPregunta.Count; i++)
        {
            puntos += listaPregunta[i].puntos;
        }

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
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }
    public void botonInicio()
    {
        sonidos.GetComponent<Sonidos>().repSonido(1);
        SceneManager.LoadScene(0);        
    }


   public class pregunta
    {
       public string preg;
       public int puntos = 0;
       public int modo;
       public bool imagen = false;       
       public bool textoAlternativo = false;
       public string pregTextoAlternativo;
        public pregunta(string pr, int mod)
        {
            preg = pr;
            modo = mod;
        }

        public void addImagen()
        {
            imagen = true;
        }
        public void addTexto(string pregun)
        {
            textoAlternativo = true;
            pregTextoAlternativo = pregun;
        }
    }
}


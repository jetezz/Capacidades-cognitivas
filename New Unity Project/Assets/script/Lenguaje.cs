using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lenguaje : MonoBehaviour
{
    private AudioSource fuenteDeAudio;
    private GameObject managerEjercicios;
    private int contador=0;
    private int puntos = 0;
    public GameObject textoPrincipal;
    public GameObject panelFin;
    public Sprite azul;
    public Sprite rojo;
    public Sprite verde;
    public Sprite negro;
    public Sprite falda;
    public Sprite calcetin;
    public Sprite chaqueta;
    public Sprite pantalon;
    public Sprite perro;
    public Sprite gato;
    public Sprite caballo;
    public Sprite oveja;
    public Sprite zapatilla;
    public Sprite bota;
    public Sprite chancla;
    public Sprite deportiva;
    public Sprite guitarra;
    public Sprite tambor;
    public Sprite flauta;
    public Sprite piano;
    public Sprite tomate;
    public Sprite lechuga;
    public Sprite zanahoria;
    public Sprite pepino;
    public Sprite circulo;
    public Sprite cuadrado;
    public Sprite triangulo;
    public Sprite rectangulo;



    ////
    ///nivel1
    List<Pregunta1> preguntas1 = new List<Pregunta1>();
    public GameObject panel1;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;
    

    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();

       
        managerEjercicios = GameObject.FindWithTag("MEje");

        if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 1)
        {
            nivel1();
            
        }
        else if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 2)
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
    public static List<T> DesordenarLista<T>(List<T> input)
    {
        List<T> arr = input;
        List<T> arrDes = new List<T>();

       
        while (arr.Count > 0)
        {
            int val = Random.Range(0, arr.Count - 1);
            arrDes.Add(arr[val]);
            arr.RemoveAt(val);
        }

        return arrDes;
    }


    void nivel1()
    {
        List<Pregunta1> aux = new List<Pregunta1>();
        aux.Add(new Pregunta1("Pulsa en el color azul", 1,0));
        aux.Add(new Pregunta1("Pulsa en el color rojo", 2,0));
        aux.Add(new Pregunta1("Pulsa en el color verde", 3,0));
        aux.Add(new Pregunta1("Pulsa en el color negro", 4,0));
        aux.Add(new Pregunta1("Pulsa en la falda", 1,1));
        aux.Add(new Pregunta1("Pulsa en el calcetín", 2, 1));
        aux.Add(new Pregunta1("Pulsa en la chaqueta", 3, 1));
        aux.Add(new Pregunta1("Pulsa en el pantalon", 4, 1));
        aux.Add(new Pregunta1("Pulsa en el perro", 1, 2));
        aux.Add(new Pregunta1("Pulsa en el gato", 2, 2));
        aux.Add(new Pregunta1("Pulsa en el caballo", 3, 2));
        aux.Add(new Pregunta1("Pulsa en el oveja", 4, 2));
        aux.Add(new Pregunta1("Pulsa en la zapatilla", 1, 3));
        aux.Add(new Pregunta1("Pulsa en el bota", 2, 3));
        aux.Add(new Pregunta1("Pulsa en el chancla", 3, 3));
        aux.Add(new Pregunta1("Pulsa en el deportiva", 4, 3));
        aux.Add(new Pregunta1("Pulsa en la guitarra", 1, 4));
        aux.Add(new Pregunta1("Pulsa en el tambor", 2, 4));
        aux.Add(new Pregunta1("Pulsa en el flauta", 3, 4));
        aux.Add(new Pregunta1("Pulsa en el piano", 4, 4));
        aux.Add(new Pregunta1("Pulsa en el tomate", 1, 5));
        aux.Add(new Pregunta1("Pulsa en el lechuga", 2, 5));
        aux.Add(new Pregunta1("Pulsa en el zanahoria", 3, 5));
        aux.Add(new Pregunta1("Pulsa en el pepino", 4, 5));
        aux.Add(new Pregunta1("Pulsa en el circulo", 1, 6));
        aux.Add(new Pregunta1("Pulsa en el cuadrado", 2, 6));
        aux.Add(new Pregunta1("Pulsa en el triangulo", 3, 6));
        aux.Add(new Pregunta1("Pulsa en el rectangulo", 4, 6));




        preguntas1 = DesordenarLista<Pregunta1>(aux);
        panel1.SetActive(true);

        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            textoPrincipal.GetComponent<Text>().text = preguntas1[contador].pregunta;
            generarGrupo();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de lenguaje nivel 1 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 28 ";
            if (puntos == 28)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 2";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.lenguaje(2);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 1";
            }
        }
    }

    void generarGrupo()
    {
        if (preguntas1[contador].grupoImagenes == 0)
        {
            boton1.GetComponent<Image>().sprite = azul;
            boton2.GetComponent<Image>().sprite = rojo;
            boton3.GetComponent<Image>().sprite = verde;
            boton4.GetComponent<Image>().sprite = negro;
        }else if(preguntas1[contador].grupoImagenes == 1)
        {
            boton1.GetComponent<Image>().sprite = falda;
            boton2.GetComponent<Image>().sprite = calcetin;
            boton3.GetComponent<Image>().sprite = chaqueta;
            boton4.GetComponent<Image>().sprite = pantalon;
        }
        else if (preguntas1[contador].grupoImagenes == 2)
        {
            boton1.GetComponent<Image>().sprite = perro;
            boton2.GetComponent<Image>().sprite = gato;
            boton3.GetComponent<Image>().sprite = caballo;
            boton4.GetComponent<Image>().sprite = oveja;
        }
        else if (preguntas1[contador].grupoImagenes == 3)
        {
            boton1.GetComponent<Image>().sprite = zapatilla;
            boton2.GetComponent<Image>().sprite = bota;
            boton3.GetComponent<Image>().sprite = chancla;
            boton4.GetComponent<Image>().sprite = deportiva;
        }
        else if (preguntas1[contador].grupoImagenes == 4)
        {
            boton1.GetComponent<Image>().sprite = guitarra;
            boton2.GetComponent<Image>().sprite = tambor;
            boton3.GetComponent<Image>().sprite = flauta;
            boton4.GetComponent<Image>().sprite = piano;
        }
        else if (preguntas1[contador].grupoImagenes == 5)
        {
            boton1.GetComponent<Image>().sprite = tomate;
            boton2.GetComponent<Image>().sprite = lechuga;
            boton3.GetComponent<Image>().sprite = zanahoria;
            boton4.GetComponent<Image>().sprite = pepino;
        }
        else if (preguntas1[contador].grupoImagenes == 6)
        {
            boton1.GetComponent<Image>().sprite = circulo;
            boton2.GetComponent<Image>().sprite = cuadrado;
            boton3.GetComponent<Image>().sprite = triangulo;
            boton4.GetComponent<Image>().sprite = rectangulo;
        }
    }
    public void botonSolucionN1(int i)
    {
        if (preguntas1[contador].solucion == i)
        {
            puntos++;
        }
        else
        {

        }
        contador++;
        siguientePreguntaN1();
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



    public void irInicio()
    {
        SceneManager.LoadScene(0);
    }
    
  
}


public class Pregunta1
{
    public Pregunta1(string p,int s,int g)
    {
        imagenes = new List<Sprite>();
        solucion = s;
        pregunta = p;
        grupoImagenes = g;
    }
    public List<Sprite> imagenes;
    public int solucion;
    public string pregunta;
    public int grupoImagenes;    
}
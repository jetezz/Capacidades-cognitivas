using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Orientacion : MonoBehaviour
{
    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;
    private float tiempo = 0;

    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

    public Sprite or1;
    public Sprite or2;
    public Sprite or3;
    public Sprite or4;
    public Sprite or5;


    public GameObject pre1N2;
    public GameObject pre2N2;
    public GameObject pre3N2;
    public GameObject pre4N2;
    public GameObject pre5N2;
    public GameObject pre6N2;

    //nivel1
    public GameObject panel1;
    Dictionary<int, string> posiciones;
    List<Orientacion1> preguntas1;

    //nivel2
    public GameObject panel2;
    List<Orientacion2> preguntas2;



    public static List<T> DesordenarLista<T>(List<T> input)
    {
        List<T> arr = input;
        List<T> arrDes = new List<T>();
        arr.Add(input[input.Count - 1]);

        while (arr.Count > 0)
        {
            int val = Random.Range(0, arr.Count - 1);
            arrDes.Add(arr[val]);
            arr.RemoveAt(val);
        }
        arrDes.RemoveAt(arrDes.Count - 1);

        return arrDes;
    }
    void Start()
    {
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
    void final(string nivel, int pMax, int siguienteNnivel)
    {
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.orientacion(siguienteNnivel);
            GameObject managerUsuario = GameObject.FindWithTag("MUsu");
            managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
        }
        else
        {

            siguienteNnivel--;
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;


        }
    }


    void nivel1()
    {
        posiciones = new Dictionary<int, string>();
        posiciones.Add(0, "Dentro");
        posiciones.Add(1, "Debajo");
        posiciones.Add(2, "Detras");
        posiciones.Add(3, "Encima");
        posiciones.Add(4, "Delante");


        preguntas1 = new List<Orientacion1>();
        preguntas1.Add(new Orientacion1(or1, 3, "El perro está_______ de la cama"));
        preguntas1.Add(new Orientacion1(or2, 1, "La pelota está _______ de la silla"));
        preguntas1.Add(new Orientacion1(or3, 2, "La niña está _____ del ordenador"));
        preguntas1.Add(new Orientacion1(or3, 4, "El ordenador está _______ de la niña"));
        preguntas1.Add(new Orientacion1(or4, 2, "La bicicleta está _____ de la niña"));
        preguntas1.Add(new Orientacion1(or4, 4, "La niña está _____ de la bicicleta"));
        preguntas1.Add(new Orientacion1(or5, 0, "Los periquitos están ______ de la jaula"));

        preguntas1 = DesordenarLista<Orientacion1>(preguntas1);
        panel1.SetActive(true);
        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            panel1.transform.GetChild(0).GetComponent<Image>().sprite = preguntas1[contador].imagen;
            textoPrincipal.GetComponent<Text>().text = preguntas1[contador].pregunta;
            generarBotonesN1();

        }
        else
        {
            final("Ejercicio orientacion nivel 1 completado", 7, 2);
        }
    }
    void generarBotonesN1()
    {
        List<int> aux = new List<int>();
        aux.Add(preguntas1[contador].solucion);

        int rand;
        rand = Random.Range(0, posiciones.Count);
        while (rand == aux[0])
        {
            rand = Random.Range(0, posiciones.Count);
        }

        aux.Add(rand);
        aux = DesordenarLista<int>(aux);
        for(int i = 0; i < 2; i++)
        {
            panel1.transform.GetChild(i + 1).GetChild(0).GetComponent<Text>().text = posiciones[aux[i]];
            panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().id = aux[i];
        }

    }

    public void botonPulsadoN1(int i)
    {
        if (preguntas1[contador].solucion == panel1.transform.GetChild(i).GetComponent<IdSeleccion>().id)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        tiempo = 1;
        contador++;
        siguientePreguntaN1();
    }

    void nivel2()
    {
        preguntas2 = new List<Orientacion2>();
        preguntas2.Add(new Orientacion2(1, "selecciona la pelota que está debajo de la mesa", pre1N2));
        preguntas2.Add(new Orientacion2(0, "selecciona la pelota que está arriba de la mesa", pre1N2));
        preguntas2.Add(new Orientacion2(0, "selecciona la pelota que está encima de la  de la silla", pre2N2));
        preguntas2.Add(new Orientacion2(1, "selecciona la pelota que está al lado de la silla", pre2N2));
        preguntas2.Add(new Orientacion2(0, "selecciona la pelota que está al lado de la cama", pre3N2));
        preguntas2.Add(new Orientacion2(1, "selecciona la pelota que está encima de la cama", pre3N2));
        preguntas2.Add(new Orientacion2(0, "selecciona el peluche que está debajo de la silla", pre4N2));
        preguntas2.Add(new Orientacion2(1, "selecciona el peluche que está encima de la silla", pre4N2));
        preguntas2.Add(new Orientacion2(1, "selecciona el peluche que está encima de la mesa", pre5N2));
        preguntas2.Add(new Orientacion2(0, "selecciona el peluche que está debajo de la mesa", pre5N2));
        preguntas2.Add(new Orientacion2(0, "selecciona el peluche que está encima de la cama", pre6N2));
        preguntas2.Add(new Orientacion2(1, "selecciona el peluche que está al lado de la cama", pre6N2));

        preguntas2 = DesordenarLista<Orientacion2>(preguntas2);
        panel2.SetActive(true);
        siguientePreguntaN2();
    }
    void siguientePreguntaN2()
    {
        pre1N2.SetActive(false);
        pre2N2.SetActive(false);
        pre3N2.SetActive(false);
        pre4N2.SetActive(false);
        pre5N2.SetActive(false);
        pre6N2.SetActive(false);

        if (contador < preguntas2.Count)
        {
            preguntas2[contador].escena.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = preguntas2[contador].pregunta;
        }
        else
        {
            final("Ejercicio orientacion nivel 2 completado", 12, 3);
        }
    }

    public void botonesN2(int solucion)
    {
        if (solucion == preguntas2[contador].solucion)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        tiempo = 1;
        contador++;
        siguientePreguntaN2();
    }
    void nivel3()
    {

    }

    void nivel4()
    {

    }
    void Update()
    {
        tiempo -= Time.deltaTime;

        if (tiempo > 0)
        {

            imagenCorreccion.SetActive(true);

        }
        else
        {
            imagenCorreccion.SetActive(false);
        }
    }

    public void irInicio()
    {
        SceneManager.LoadScene(0);
    }
}


class Orientacion1
{
    public Orientacion1(Sprite img,int sol, string pre)
    {
        imagen = img;
        solucion = sol;
        pregunta = pre;
    }
    public Sprite imagen;
    public int solucion;
    public string pregunta;
}

class Orientacion2
{
    public Orientacion2(int sol, string pre,GameObject esc)
    {
        solucion = sol;
        pregunta = pre;
        escena = esc;
    }
    public int solucion;
    public string pregunta;
    public GameObject escena;
}
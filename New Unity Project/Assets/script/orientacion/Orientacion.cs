using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Orientacion : MonoBehaviour
{
    GameObject sonidos;
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

    public Sprite n1;
    public Sprite n2;
    public Sprite n3;
    public Sprite n4;
    public Sprite n5;
    public Sprite n6;
    public Sprite n7;
    public Sprite n8;
    public Sprite n9;
    public Sprite n10;
    public Sprite n11;
    public Sprite n12;
    public Sprite n13;
    public Sprite n14;


    public Sprite circulo;
    public Sprite cuadrado;
    public Sprite rombo;
    public Sprite rectangulo;
    public Sprite triangulo;



    //nivel1
    public GameObject panel1;   
    List<Orientacion1> preguntas1;

    //nivel2
    public GameObject panel2;
    List<Orientacion2> preguntas2;

    //nivel3
    public GameObject panel3;
    List<Orientacion3> preguntas3;

    //nivel4
    public GameObject panel4;
    List<Orientacion4> preguntas4;



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
    void Start()
    {
        managerEjercicios = GameObject.FindWithTag("MEje");
        sonidos = GameObject.FindWithTag("Sonido");


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
        textoPrincipal.GetComponent<Text>().text = "Finalizado los ejercicios de Orientacion nivel " + (siguienteNnivel - 1).ToString();

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
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }


    void nivel1()
    {
        


        preguntas1 = new List<Orientacion1>();
        preguntas1.Add(new Orientacion1(or1, true, "El perro está dentro de la cama"));
        preguntas1.Add(new Orientacion1(or2, false, "La pelota está encima de la silla"));
        preguntas1.Add(new Orientacion1(or3, true, "La niña está detrás del ordenador"));
        preguntas1.Add(new Orientacion1(or3, false, "El ordenador está detras de la niña"));
        preguntas1.Add(new Orientacion1(or4, false, "La bicicleta está delante de la niña"));
        preguntas1.Add(new Orientacion1(or4, true, "La niña está delante de la bicicleta"));
        preguntas1.Add(new Orientacion1(or5, true, "Los periquitos están dentro de la jaula"));

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
           

        }
        else
        {
            final("Ejercicio orientacion nivel 1 completado", 7, 2);
        }
    }
 

    public void botonPulsadoN1(bool i)
    {
        
        if (i == preguntas1[contador].solucion)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);

        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);

        }
        tiempo = 1;
        contador++;
        siguientePreguntaN1();
        
    }

    void nivel2()
    {
        preguntas2 = new List<Orientacion2>();
        preguntas2.Add(new Orientacion2(1, "selecciona la pelota que está debajo de la mesa", pre1N2));
        preguntas2.Add(new Orientacion2(0, "selecciona la pelota que está encima de la mesa", pre1N2));
        preguntas2.Add(new Orientacion2(0, "selecciona la pelota que está encima  de la silla", pre2N2));
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
            sonidos.GetComponent<Sonidos>().repSonido(2);
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
        }
        tiempo = 1;
        contador++;
        siguientePreguntaN2();
    }
    void nivel3()
    {
        preguntas3 = new List<Orientacion3>();
        List<Sprite> fase1 = new List<Sprite>();
        fase1.Add(n1);
        fase1.Add(n2);
        fase1.Add(n3);
        fase1.Add(n4);
        fase1.Add(n5);
        fase1.Add(n6);

        List<Sprite> fase2 = new List<Sprite>();

        fase2.Add(n3);
        fase2.Add(n4);
        fase2.Add(n5);
        fase2.Add(n6);
        fase2.Add(n7);
        fase2.Add(n8);

        List<Sprite> fase3 = new List<Sprite>();

        fase3.Add(n9);
        fase3.Add(n10);
        fase3.Add(n11);
        fase3.Add(n12);
        fase3.Add(n13);
        fase3.Add(n14);

        preguntas3.Add(new Orientacion3(fase1, "pulsa el maceta que está encima de la mesa",0));
        preguntas3.Add(new Orientacion3(fase1, "pulsa el maceta que está debajo de la mesa", 1));
        preguntas3.Add(new Orientacion3(fase1, "pulsa el maceta que está a la izquierda de la mesa", 2));
        preguntas3.Add(new Orientacion3(fase1, "pulsa el maceta que está a la derecha de la mesa", 3));
        preguntas3.Add(new Orientacion3(fase1, "pulsa la lámpara que está delante de la mesa", 4));
        preguntas3.Add(new Orientacion3(fase1, "pulsa la lámpara que está detrás de la mesa", 5));

        preguntas3.Add(new Orientacion3(fase2, "pulsa el maceta que está entra la lámpara y la mesa", 4));
        preguntas3.Add(new Orientacion3(fase2, "pulsa la lámpara que está a la derecha de la mesa", 5));



        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está delante de la mesa", 0));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está encima de la mesa", 1));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está a la derecha de la mesa", 2));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está detrás de la mesa", 3));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está a la izquierda de la mesa", 4));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está debajo de la mesa", 5));




        panel3.SetActive(true);
        siguientePreguntaN3();



    }
    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            textoPrincipal.GetComponent<Text>().text = preguntas3[contador].pregunta;
            generarBotonesN3();
        }
        else
        {
            final("Ejercicio orientacion nivel 3 completado", 14, 4);
        }
    }
    void generarBotonesN3()
    {
        List<Botones> aux = new List<Botones>();
        aux.Add(new Botones(preguntas3[contador].imagenes[preguntas3[contador].id],true));

        for(int i = 0; i < 6; i++)
        {
            if (i != preguntas3[contador].id)
            {
                aux.Add(new Botones(preguntas3[contador].imagenes[i], false));
            }
        }

        aux = DesordenarLista<Botones>(aux);
        for (int i = 0; i < 6; i++)
        {
            panel3.transform.GetChild(i).GetComponent<Image>().sprite = aux[i].img;
            panel3.transform.GetChild(i).GetComponent<IdSeleccion>().correcto = aux[i].correc;
        }
    }
    public void botonesN3(int i)
    {
        if (panel3.transform.GetChild(i).GetComponent<IdSeleccion>().correcto)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
        }
        tiempo = 1;
        contador++;
        siguientePreguntaN3();
    }

    void nivel4()
    {
        preguntas4 = new List<Orientacion4>();
        preguntas4.Add(new Orientacion4(2, 2, "coloca el cuadrado a la derecha del círculo", 1));
        preguntas4.Add(new Orientacion4(1, 3, "coloca el rombo debajo del círculo", 2));
        preguntas4.Add(new Orientacion4(1, 1, "coloca el triángulo arriba del círculo", 3));
        preguntas4.Add(new Orientacion4(0, 2, "coloca el rectangulo a la izquierda del círculo", 4));
        preguntas4.Add(new Orientacion4(3, 2, "coloca el rombo a la derecha del cuadrado", 2));
        preguntas4.Add(new Orientacion4(4, 2, "coloca el triángulo a la derecha del rombo", 3));
        preguntas4.Add(new Orientacion4(4, 3, "coloca el cuadrado debajo del triangulo", 1));
        preguntas4.Add(new Orientacion4(3, 3, "coloca el rectangulo a la izquierda del cuadrado", 4));

        panel4.SetActive(true);
        siguientePreguntaN4();
    }
    void siguientePreguntaN4()
    {
        if (contador < preguntas4.Count)
        {
            textoPrincipal.GetComponent<Text>().text = preguntas4[contador].pregunta;
        }
        else
        {
            final("Ejercicio orientacion nivel4 completado", 8, 5);
        }
    }

    public void respuestaN4(int x, int y, int id)
    {
        if(x==preguntas4[contador].x && y==preguntas4[contador].y && id == preguntas4[contador].id)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
        }
        tiempo = 1;
        contador++;
        siguientePreguntaN4();
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
    public void siguienteEjercicio()
    {
        managerEjercicios.GetComponent<ManagerEjercicios>().iniciarEjercicio();
    }
}


class Orientacion1
{
    public Orientacion1(Sprite img,bool sol, string pre)
    {
        imagen = img;
        solucion = sol;
        pregunta = pre;
    }
    public Sprite imagen;
    public bool solucion;
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

class Orientacion3
{
    public Orientacion3(List<Sprite> img, string pre,int i)
    {
        imagenes = new List<Sprite>();
        imagenes = img;
        pregunta = pre;
        id = i;
    }


    public List<Sprite> imagenes;
    public string pregunta;
    public int id;
}

class Botones
{
    public Botones(Sprite im,bool cor)
    {
        img=im;
        correc = cor;
    }
    public Sprite img;
    public bool correc;
}

class Orientacion4
{
    public Orientacion4(int x2, int y2, string preg, int i)
    {
        x = x2;
        y = y2;
        pregunta = preg;
      
        id = i;

    }

    public int x, y;
    public string pregunta;    
    public int id;
}
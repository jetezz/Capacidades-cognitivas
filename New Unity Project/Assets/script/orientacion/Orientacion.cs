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
    public Sprite or6;
    public Sprite or7;
    public Sprite or8;
    public Sprite or9;
    public Sprite or10;


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
    Dictionary<int, Sprite> imagenesN1;

    //nivel2
    public GameObject panel2;
    List<Orientacion2> preguntas2;

    //nivel3
    public GameObject panel3;
    List<Orientacion3> preguntas3;

    //nivel4
    public GameObject panel4;
    List<Orientacion4> preguntas4;
    int numRespuestas = 0;



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
    void final(string nivel, int pMax, int pMin, int siguienteNnivel,bool ultimo)
    {
        textoPrincipal.GetComponent<Text>().text = "Finalizado los ejercicios de Orientación nivel " + (siguienteNnivel - 1).ToString();
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos máximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.orientacion(siguienteNnivel);
            GameObject managerUsuario = GameObject.FindWithTag("MUsu");
            managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
        }
        else
        {
            if (puntos < pMin)
            {
                if (!ultimo)
                {
                    siguienteNnivel--;
                }
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Bajas al nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.orientacion(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.orientacion(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }



        }
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }


    void nivel1()
    {
        imagenesN1 = new Dictionary<int, Sprite>();
        imagenesN1.Add(0, or1);
        imagenesN1.Add(1, or2);
        imagenesN1.Add(2, or3);
        imagenesN1.Add(3, or4);
        imagenesN1.Add(4, or5);
        imagenesN1.Add(5, or6);
        imagenesN1.Add(6, or7);
        imagenesN1.Add(7, or8);
        imagenesN1.Add(8, or9);
        imagenesN1.Add(9, or10);


        preguntas1 = new List<Orientacion1>();
        preguntas1.Add(new Orientacion1(0,  "Pulsa la foto del perro dentro de la cama",0));        
        preguntas1.Add(new Orientacion1(1,  "Pulsa la foto de la pelota debajo de la mesa roja",1));
        preguntas1.Add(new Orientacion1(2,  "Pulsa la foto de a niña detrás del ordenador",2));        
        preguntas1.Add(new Orientacion1(3,  "Pulsa la foto del a niña delante de la bicicleta",3));
        preguntas1.Add(new Orientacion1(4,  "Pulsa la foto de los periquitos dentro de la jaula",4));      
        preguntas1.Add(new Orientacion1(5,  "Pulsa la foto del profesor delante de la pizarra",5));
        preguntas1.Add(new Orientacion1(6,  "Pulsa la foto del ciclista encima de la bici",6));
        preguntas1.Add(new Orientacion1(7,  "Pulsa la foto de la pelota debajo de la mesa",7));
        preguntas1.Add(new Orientacion1(8,  "Pulsa la foto del libro encima de la mesa",8));
        preguntas1.Add(new Orientacion1(9,  "Pulsa la foto del gato delante de la silla",9));



        preguntas1 = DesordenarLista<Orientacion1>(preguntas1);
        panel1.SetActive(true);
        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            generarImagenesN1();
            sonidos.GetComponent<Sonidos>().repAudio(6, preguntas1[contador].audio);
            textoPrincipal.GetComponent<Text>().text = preguntas1[contador].pregunta;
           

        }
        else
        {
            final("Ejercicio orientación nivel 1 completado", 10,0, 2,false);
        }
    }
 
    void generarImagenesN1()
    {
        List<Botones> aux = new List<Botones>();
        aux.Add(new Botones(imagenesN1[preguntas1[contador].imagen],true));

        int rand = Random.Range(0, imagenesN1.Count);
        while(rand== preguntas1[contador].imagen)
        {
            rand = Random.Range(0, imagenesN1.Count);
        }
        aux.Add(new Botones(imagenesN1[rand], false));

        aux = DesordenarLista<Botones>(aux);
        for(int i = 0; i < 2; i++)
        {
            panel1.transform.GetChild(i).GetComponent<Image>().sprite = aux[i].img;
            panel1.transform.GetChild(i).GetComponent<IdSeleccion>().correcto = aux[i].correc;
        }
    }
    public void botonPulsadoN1(int i)
    {
        
        if (panel1.transform.GetChild(i).GetComponent<IdSeleccion>().correcto)
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
        preguntas2.Add(new Orientacion2(1, "Selecciona la pelota que está debajo de la mesa", pre1N2,10));
        preguntas2.Add(new Orientacion2(0, "Selecciona la pelota que está encima de la mesa", pre1N2,11));
        preguntas2.Add(new Orientacion2(0, "Selecciona la pelota que está encima  de la silla", pre2N2,12));
        preguntas2.Add(new Orientacion2(1, "Selecciona la pelota que está al lado de la silla", pre2N2,13));
        preguntas2.Add(new Orientacion2(0, "Selecciona la pelota que está al lado de la cama", pre3N2,14));
        preguntas2.Add(new Orientacion2(1, "Selecciona la pelota que está encima de la cama", pre3N2,15));
        preguntas2.Add(new Orientacion2(0, "Selecciona el peluche que está debajo de la silla", pre4N2,16));
        preguntas2.Add(new Orientacion2(1, "Selecciona el peluche que está encima de la silla", pre4N2,17));
        preguntas2.Add(new Orientacion2(1, "Selecciona el peluche que está encima de la mesa", pre5N2,18));
        preguntas2.Add(new Orientacion2(0, "Selecciona el peluche que está debajo de la mesa", pre5N2,19));
        preguntas2.Add(new Orientacion2(0, "Selecciona el peluche que está encima de la cama", pre6N2,20));
        preguntas2.Add(new Orientacion2(1, "Selecciona el peluche que está al lado de la cama", pre6N2,21));

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
            sonidos.GetComponent<Sonidos>().repAudio(6, preguntas2[contador].audio);
            textoPrincipal.GetComponent<Text>().text = preguntas2[contador].pregunta;

        }
        else
        {
            final("Ejercicio orientación nivel 2 completado", 12,6, 3,false);
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

        preguntas3.Add(new Orientacion3(fase1, "Pulsa la maceta que está encima de la mesa",0,22));
        preguntas3.Add(new Orientacion3(fase1, "Pulsa la maceta que está debajo de la mesa", 1,23));
        preguntas3.Add(new Orientacion3(fase1, "Pulsa la maceta que está a la izquierda de la mesa", 2,34));
        preguntas3.Add(new Orientacion3(fase1, "Pulsa la maceta que está a la derecha de la mesa", 3,35));
        preguntas3.Add(new Orientacion3(fase1, "Pulsa la lámpara que está delante de la mesa", 4,36));
        preguntas3.Add(new Orientacion3(fase1, "Pulsa la lámpara que está detrás de la mesa", 5,37));
                                                
        preguntas3.Add(new Orientacion3(fase2, "Pulsa la maceta que está entre la lámpara y la mesa", 4,38));
        preguntas3.Add(new Orientacion3(fase2, "Pulsa la lámpara que está a la derecha de la mesa", 5,39));



        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está delante de la mesa", 0,30));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está encima de la mesa", 1,31));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está a la derecha de la mesa", 2,32));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está detrás de la mesa", 3,33));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está a la izquierda de la mesa", 4,34));
        preguntas3.Add(new Orientacion3(fase3, "Pulsa el gato que está debajo de la mesa", 5,35));




        panel3.SetActive(true);
        siguientePreguntaN3();



    }
    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            sonidos.GetComponent<Sonidos>().repAudio(6, preguntas3[contador].audio);
            textoPrincipal.GetComponent<Text>().text = preguntas3[contador].pregunta;
            generarBotonesN3();
        }
        else
        {
            final("Ejercicio orientación nivel 3 completado", 14,7, 4,false);
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
        preguntas4.Add(new Orientacion4(2, 2, "Coloca el cuadrado a la derecha del círculo amarillo", 1,36));
        preguntas4.Add(new Orientacion4(4, 5, "Coloca el rombo debajo del círculo rojo", 2,37));
        preguntas4.Add(new Orientacion4(4, 0, "Coloca el triángulo arriba del círculo verde", 3,38));
        preguntas4.Add(new Orientacion4(0, 4, "Coloca el rectángulo a la izquierda del círculo azul", 4,39));
                                               
        preguntas4.Add(new Orientacion4(5, 4, "Coloca el rombo a la derecha círculo rojo", 2,40));
        preguntas4.Add(new Orientacion4(5, 1, "Coloca el triángulo a la derecha del círculo verde", 3,41));
        preguntas4.Add(new Orientacion4(1, 3, "Coloca el cuadrado debajo del círculo amarillo", 1,42));
        preguntas4.Add(new Orientacion4(1, 5, "Coloca el rectángulo a la debajo del círculo azul", 4,43));
                                               
        preguntas4.Add(new Orientacion4(0, 2, "Coloca el cuadrado a la izquierda del círculo amarillo", 1,44));
        preguntas4.Add(new Orientacion4(4, 3, "Coloca el rombo arriba del círculo rojo", 2,45));
        preguntas4.Add(new Orientacion4(4, 2, "Coloca el triángulo abajo del círculo verde", 3,46));
        preguntas4.Add(new Orientacion4(2, 4, "Coloca el rectángulo a la derecha del círculo azul", 4,47));



        panel4.transform.GetChild(2).GetComponent<Drag>().iniciarposicion();
        panel4.transform.GetChild(3).GetComponent<Drag>().iniciarposicion();
        panel4.transform.GetChild(4).GetComponent<Drag>().iniciarposicion();
        panel4.transform.GetChild(5).GetComponent<Drag>().iniciarposicion();

        panel4.SetActive(true);
        siguientePreguntaN4();
    }
    void siguientePreguntaN4()
    {
        if (contador < preguntas4.Count)
        {
            sonidos.GetComponent<Sonidos>().repAudio(6, preguntas4[contador].audio);
            textoPrincipal.GetComponent<Text>().text = preguntas4[contador].pregunta;
        }
        else
        {
            final("Ejercicio orientación nivel 4 completado", 12,6, 4,true);
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
        numRespuestas++;
        if (numRespuestas == 4)
        {
            numRespuestas = 0;
            panel4.transform.GetChild(2).GetComponent<Drag>().resetPosition();
            panel4.transform.GetChild(3).GetComponent<Drag>().resetPosition();
            panel4.transform.GetChild(4).GetComponent<Drag>().resetPosition();
            panel4.transform.GetChild(5).GetComponent<Drag>().resetPosition();
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
        sonidos.GetComponent<Sonidos>().repSonido(1);
        SceneManager.LoadScene(0);
    }
    public void siguienteEjercicio()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        managerEjercicios.GetComponent<ManagerEjercicios>().iniciarEjercicio();
    }
}


class Orientacion1
{
    public Orientacion1(int img, string pre,int au)
    {
        imagen = img;        
        pregunta = pre;
        audio = au;
    }
    public int imagen;    
    public string pregunta;
    public int audio;
}

class Orientacion2
{
    public Orientacion2(int sol, string pre,GameObject esc,int au)
    {
        solucion = sol;
        pregunta = pre;
        escena = esc;
        audio = au;
    }
    public int solucion;
    public string pregunta;
    public GameObject escena;
    public int audio;
}

class Orientacion3
{
    public Orientacion3(List<Sprite> img, string pre,int i,int au)
    {
        imagenes = new List<Sprite>();
        imagenes = img;
        pregunta = pre;
        id = i;
        audio = au;
    }


    public List<Sprite> imagenes;
    public string pregunta;
    public int id;
    public int audio;
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
    public Orientacion4(int x2, int y2, string preg, int i, int au)
    {
        x = x2;
        y = y2;
        pregunta = preg;
      
        id = i;
        audio = au;

    }

    public int x, y;
    public string pregunta;    
    public int id;
    public int audio;
}
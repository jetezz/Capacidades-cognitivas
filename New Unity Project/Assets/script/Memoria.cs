using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Memoria : MonoBehaviour
{
    public GameObject panelFin;
    public GameObject canvas;
    private GameObject managerEjercicios;
    int respuesta = 0;
    int respuesta2 = 0;
    int respuesta3 = 0;
    int respuesta4 = 0;
    private AudioSource fuenteDeAudio;
    public GameObject imagenRespuesta;
    public GameObject imagenRespuesta2;
    public GameObject imagenRespuesta3;
    public GameObject imagenRespuesta4;


    public int contadorFases=0;
    public int puntos = 0;      

    public Sprite bano;
    public Sprite granja;
    public Sprite cocina;
    public Sprite habitacion;
    public Sprite salon;
    public Sprite cruz;
    public Sprite tick;
    public Sprite salon2;
    public Sprite cuarto;
    public Sprite zoo;
    public List<fases> fasesTotales;
    int nivel;
    public float tiempo=0;
    



    /////// nivel 1
    public GameObject panelNivel1;
    public GameObject botonesFase1;
    public GameObject botonesFase2;
    public GameObject botonesFase3;
    public GameObject botonesFase4;

    public AudioClip aPregunta1;
    public AudioClip aPregunta2;

    /////// nivel2
    public GameObject panelNivel2;
    public GameObject botonesNivel2;

    ////Nivel3
    public GameObject panelNivel3;
    public GameObject botonesNivel3;

    ///Nivel4
    public GameObject panelNivel4;
    public GameObject preguntas4;
    public GameObject slots;
    public GameObject drags;
    public GameObject botonSiguienteN4;
    public GameObject botonCorregir;
    public GameObject panelBloqueo;
    private List<Soluciones> respustasNivel4;
    private List<bool> posicionesPreguntas;
    private int movimientos = 0;
    private int numPreguntas = 0;


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
        fuenteDeAudio = GetComponent<AudioSource>();
        fasesTotales = new List<fases>();

        managerEjercicios = GameObject.FindWithTag("MEje");
        
        if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 1)
        {
            nivel1();
            nivel = 1;
        }else if(managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 2)
        {
            nivel2();
            nivel = 2;
        }
        else if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 3)
        {
            nivel3();
            nivel = 3;
        }
        else if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 4)
        {
            nivel4();
            nivel = 4;
        }
    }
    /// NIVEL 1
    void nivel1()
    {
        fases fase1=new fases();
        fases fase2=new fases();
        fases fase3=new fases();
        fases fase4 = new fases();

        fase1.imagen = bano;        
        fase1.preguntas.Add("¿Dónde está la bañera?");
        fase1.audios.Add(aPregunta1);
        fase1.preguntas.Add("¿Dónde está el lavabo?");
        fase1.audios.Add(aPregunta2);
        fase1.preguntas.Add("¿Dónde está el espejo?");
        fase1.preguntas.Add("¿Dónde está la lavadora?");
        fase1.preguntas.Add("¿Dónde está el calentador?");
        fase1.preguntas.Add("¿Dónde está el váter?");
        

        fase2.imagen = granja;
        fase2.preguntas.Add("¿Dónde está la barca?");
        fase2.preguntas.Add("¿Dónde están los patos?");
        fase2.preguntas.Add("¿Dónde está la vaca?");
        fase2.preguntas.Add("¿Dónde está el árbol con fruta?");
        fase2.preguntas.Add("¿Dónde está la cabaña?");
        fase2.preguntas.Add("¿Dónde está el árbol sin fruta?");


        fase3.imagen = cocina;
        fase3.preguntas.Add("¿Dónde está el horno?");
        fase3.preguntas.Add("¿Dónde está el frigorífico?");
        fase3.preguntas.Add("¿Dónde está el fregadero?");
        fase3.preguntas.Add("¿Dónde está el microondas?");

        fase4.imagen = habitacion;
        fase4.preguntas.Add("¿Dónde está el espejo?");
        fase4.preguntas.Add("¿Dónde está la maceta?");
        fase4.preguntas.Add("¿Dónde está la cama?");
        fase4.preguntas.Add("¿Dónde está la ventana?");
        fase4.preguntas.Add("¿Dónde está la lámpara?");

        fasesTotales.Add(fase1);
        fasesTotales.Add(fase2);
        fasesTotales.Add(fase3);
        fasesTotales.Add(fase4);
        

        panelNivel1.SetActive(true);        
        panelNivel1.transform.GetChild(1).GetComponent<Image>().sprite = fasesTotales[contadorFases].imagen;
        botonesFase1.SetActive(true);
        siguientePreguntaNivel1();
        tiempo = 0;

    }
    public void botonBanera()
    {        
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 1)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();        
    }
    public void botonLavabo()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 2)
        {
            puntos++;
            respuesta = 1;
            
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonEspejo()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 3)
        {
            puntos++;
            respuesta = 1;            
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonLavadora()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 4)
        {
            puntos++;
            respuesta = 1;            
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonCalentador()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 5)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonBater()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 6)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }

    public void botonBarca()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 1)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonPatos()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 2)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonVaca()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 3)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonArbolFruta()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 4)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonCabana()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 5)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonArbolSinFruta()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 6)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }

    public void botonHorno()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 1)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonFrigorifico()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 2)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonlavabo()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 3)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonmicroondas()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 4)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }

    public void botonEspejoHabitacion()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 1)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonPlanta()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 2)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonCama()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 3)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonVentana()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 4)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }
    public void botonLampara()
    {
        fasesTotales[contadorFases].contador++;
        if (fasesTotales[contadorFases].contador == 5)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        siguientePreguntaNivel1();
    }



    public void siguientePreguntaNivel1()
    {
        
        if (fasesTotales[contadorFases].contador < fasesTotales[contadorFases].preguntas.Count)
        {
            string aux = fasesTotales[contadorFases].preguntas[fasesTotales[contadorFases].contador];
            panelNivel1.transform.GetChild(0).GetComponent<Text>().text = aux;
            if (fasesTotales[contadorFases].audios.Count > fasesTotales[contadorFases].contador)
            {
                fuenteDeAudio.clip = fasesTotales[contadorFases].audios[fasesTotales[contadorFases].contador];
                fuenteDeAudio.Play();
            }

        }
        else
        {
            contadorFases++;

           
            if (contadorFases == fasesTotales.Count)
            {
                panelFin.SetActive(true);
                panelFin.transform.GetChild(3).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(4).GetComponent<Text>().text = "Los puntos maximos de esta prueba son 21 ";

                if (puntos == 21)
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
            else
            {
                botonesFase1.SetActive(false);
                botonesFase2.SetActive(false);
                botonesFase3.SetActive(false);
                botonesFase4.SetActive(false);

                if (contadorFases == 1)
                {
                    botonesFase2.SetActive(true);
                }
                else if (contadorFases == 2)
                {
                    botonesFase3.SetActive(true);

                }
                else if (contadorFases == 3)
                {
                    botonesFase4.SetActive(true);

                }
                panelNivel1.transform.GetChild(0).GetComponent<Text>().text = fasesTotales[contadorFases].preguntas[fasesTotales[contadorFases].contador];
                panelNivel1.transform.GetChild(1).GetComponent<Image>().sprite = fasesTotales[contadorFases].imagen;
            }
           
         

        }
        
    }

    ///////////////////////////////////
    

    //////NIVEL2
    void nivel2()
    {
        fases fase1 = new fases();
        fases fase2 = new fases();
        fases fase3 = new fases();

        fase1.imagen = granja;
        fase1.preguntas.Add("¿Cuántos árboles hay?");
        fase1.soluciones.Add(new Soluciones(5, 1));
        fase1.preguntas.Add("¿De qué color es la casa?");
        fase1.soluciones.Add(new Soluciones(0, 2));
        fase1.preguntas.Add("¿Cuántas manzanas hay en el árbol?");
        fase1.soluciones.Add(new Soluciones(6, 2));
        fase1.preguntas.Add("¿De qué color es la barca?");
        fase1.soluciones.Add(new Soluciones(1, 2));
        fase1.preguntas.Add("¿Cómo está el dia?");
        fase1.soluciones.Add(new Soluciones(8, 1));
        fase1.preguntas.Add("¿Qué especies de animales hay?");
        fase1.soluciones.Add(new Soluciones(9, 1));

        fase2.imagen = habitacion;
        fase2.preguntas.Add("¿De qué color son las sábanas?");
        fase2.soluciones.Add(new Soluciones(0, 1));
        fase2.preguntas.Add("¿Dónde está el espejo?");
        fase2.soluciones.Add(new Soluciones(18, 1));
        fase2.preguntas.Add("¿De qué color es la alfombra?");
        fase2.soluciones.Add(new Soluciones(3, 1));
        fase2.preguntas.Add("¿De qué color es el suelo?");
        fase2.soluciones.Add(new Soluciones(0, 2));
        fase2.preguntas.Add("¿Cuántos cuadros hay?");
        fase2.soluciones.Add(new Soluciones(5, 1));
        fase2.preguntas.Add("¿Cómo son los cojines?");
        fase2.soluciones.Add(new Soluciones(12, 1));


        fase3.imagen = salon2;
        fase3.preguntas.Add("¿Dónde está el gato?");
        fase3.soluciones.Add(new Soluciones(15, 1));
        fase3.preguntas.Add("¿De qué color es el sofá?");
        fase3.soluciones.Add(new Soluciones(3, 1));        
        fase3.preguntas.Add("¿De qué color son las cortinas?");
        fase3.soluciones.Add(new Soluciones(16, 2));
        fase3.preguntas.Add("¿Cuántas macetas hay en la ventana?");
        fase3.soluciones.Add(new Soluciones(5, 1));
        fase3.preguntas.Add("¿Dónde está la mesa?");
        fase3.soluciones.Add(new Soluciones(17, 2));
        fase3.preguntas.Add("¿De qué color es la lámpara?");
        fase3.soluciones.Add(new Soluciones(20, 1));
        fase3.preguntas.Add("¿Cuántos cuadros hay?");
        fase3.soluciones.Add(new Soluciones(5, 1));

        fasesTotales.Add(fase1);
        fasesTotales.Add(fase2);
        fasesTotales.Add(fase3);
       

        panelNivel2.SetActive(true);
        panelNivel2.transform.GetChild(1).GetComponent<Image>().sprite = granja;
        tiempo = 0;
    }

    public void boton1Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion==1)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
    public void boton2Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 2)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
    public void boton3Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";       
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 3)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
    public void boton4Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 4)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
     void comprobarFinal()
    {
        if (fasesTotales[contadorFases].contador == fasesTotales[contadorFases].preguntas.Count)
        {
            contadorFases++;
            if (contadorFases == fasesTotales.Count)
            {
                panelFin.SetActive(true);
                panelFin.transform.GetChild(3).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(4).GetComponent<Text>().text = "Los puntos maximos de esta prueba son 19 ";

                if (puntos == 19)
                {
                    panelFin.transform.GetChild(5).GetComponent<Text>().text = "Mejora de nivel en memoria a nivel 3";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(3);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(5).GetComponent<Text>().text = "Se mantiene el nivel 2 en memoria";
                }
            }
            else
            {
                panelNivel2.transform.GetChild(1).GetComponent<Image>().sprite = fasesTotales[contadorFases].imagen;
            }
        }      
    }

    public void botonEmpezar()
    {
        siguientePreguntaNivel2();
    }
    public void siguientePreguntaNivel2()
    {
       
        botonesNivel2.SetActive(true);
        generarBotones();

        string aux = fasesTotales[contadorFases].preguntas[fasesTotales[contadorFases].contador];
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = aux;
               
    }

    void generarBotones()
    {

        GameObject boton1;
        GameObject boton2;
        GameObject boton3;
        GameObject boton4;

        if (nivel == 2)
        {
            boton1 = botonesNivel2.transform.GetChild(0).gameObject;
            boton2 = botonesNivel2.transform.GetChild(1).gameObject;
            boton3 = botonesNivel2.transform.GetChild(2).gameObject;
            boton4 = botonesNivel2.transform.GetChild(3).gameObject;
        }
        else
        {
            boton1 = botonesNivel3.transform.GetChild(0).gameObject;
            boton2 = botonesNivel3.transform.GetChild(1).gameObject;
            boton3 = botonesNivel3.transform.GetChild(2).gameObject;
            boton4 = botonesNivel3.transform.GetChild(3).gameObject;
        }


        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 0)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Azul";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Rojo";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Marrón";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Blanco";

        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 1)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Verde";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Marrón";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Amarillo";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Violeta";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 2)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Blanco";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Naranja";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Negro";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Rojo";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 3)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Amarillo";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Negro";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Azul";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Verde";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 4)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "1";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "3";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "2";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "4";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 5)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "2";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "4";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "1";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "5";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 6)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "3";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "5";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "1";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "6";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 7)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "4";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "6";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "3";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "1";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 8)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Soleado";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Lluvioso";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Con nieve";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Con viento";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 9)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Cisnes y vaca";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Perros y cisnes";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Vaca y perro";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Vaca";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 10)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Izquierda";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Abajo";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Derecha";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Arriba";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 11)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Derecha";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Arriba";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Centro";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Izquierda";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 12)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "De rallas";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "De círculos";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "De lunares";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "De cuadrados";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 13)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "En la puerta";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "En la pared";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "En la mesa";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "En el suelo";

        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 14)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Debajo de la mesa";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Debajo del sofá";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Al lado de la puerta";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "No hay alfombra";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 15)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "En el sofá";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "En el suelo";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Al lado de la puerta";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "En la puerta";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 16)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Negro";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Rosa";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Violeta";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Verde";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 17)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Al lado del sofá";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Delante del sofá";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Delanten del armario";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Al lado de la puerta";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 18)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Encima del mueble";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Encima de la cama";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Delanten del armario";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Al lado de la puerta";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 19)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Al lado de la ventana";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Al lado de la caman";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Enfrente del sofá";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Debajo de la televisión";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 20)
        {
            boton1.transform.GetChild(0).GetComponent<Text>().text = "Negro";
            boton2.transform.GetChild(0).GetComponent<Text>().text = "Verde";
            boton3.transform.GetChild(0).GetComponent<Text>().text = "Violeta";
            boton4.transform.GetChild(0).GetComponent<Text>().text = "Verde";
        }
    }


        /// Nivel3

        void nivel3()
    {
        fases fase1 = new fases();
        fases fase2 = new fases();
        fases fase3 = new fases();

        fase1.imagen = granja;
        fase1.preguntas.Add("¿Cuántos árboles hay?");
        fase1.soluciones.Add(new Soluciones(4, 3));
        fase1.preguntas.Add("¿De qué color es la casa?");
        fase1.soluciones.Add(new Soluciones(0, 2));
        fase1.preguntas.Add("¿Cuántas manzanas hay en el árbol?");
        fase1.soluciones.Add(new Soluciones(5, 4));
        fase1.preguntas.Add("¿De qué color es la barca?");
        fase1.soluciones.Add(new Soluciones(1, 2));
        fase1.preguntas.Add("¿Cómo está el día?");
        fase1.soluciones.Add(new Soluciones(8, 1));
        fase1.preguntas.Add("¿Qué especies de animales hay?");
        fase1.soluciones.Add(new Soluciones(9, 1));

        fase2.imagen = habitacion;
        fase2.preguntas.Add("¿De qué color son las sábanas?");
        fase2.soluciones.Add(new Soluciones(3, 3));
        fase2.preguntas.Add("¿Dónde está el espejo?");
        fase2.soluciones.Add(new Soluciones(18, 1));
        fase2.preguntas.Add("¿De qué color es la alfombra?");
        fase2.soluciones.Add(new Soluciones(1, 3));
        fase2.preguntas.Add("¿De qué color es el suelo?");
        fase2.soluciones.Add(new Soluciones(2, 4));
        fase2.preguntas.Add("¿Cuántos cuadros hay?");
        fase2.soluciones.Add(new Soluciones(5, 1));
        fase2.preguntas.Add("¿Cómo son los cojines?");
        fase2.soluciones.Add(new Soluciones(12, 1));

        fase3.imagen = salon;
        fase3.preguntas.Add("¿Dónde está la tele?");
        fase3.soluciones.Add(new Soluciones(19, 3));
        fase3.preguntas.Add("¿De qué color es el sofá?");
        fase3.soluciones.Add(new Soluciones(2, 4));
        fase3.preguntas.Add("¿Dónde está la percha?");
        fase3.soluciones.Add(new Soluciones(13, 1));
        fase3.preguntas.Add("¿De qué color es el teléfono?");
        fase3.soluciones.Add(new Soluciones(3, 2));
        fase3.preguntas.Add("¿Dónde está la alfombra?");
        fase3.soluciones.Add(new Soluciones(14, 1));
        fase3.preguntas.Add("¿De qué color es la lámpara?");
        fase3.soluciones.Add(new Soluciones(0, 4));
        fase3.preguntas.Add("¿Cuántos cojines hay?");
        fase3.soluciones.Add(new Soluciones(5, 1));

        fasesTotales.Add(fase1);
        fasesTotales.Add(fase2);
        fasesTotales.Add(fase3);

        panelNivel3.SetActive(true);
        panelNivel3.transform.GetChild(1).GetComponent<Image>().sprite = granja;
        tiempo = 0;
    }



    public void boton1Nivel3()
    {
               
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 1)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal3();
    }
   
    public void boton2Nivel3()
    {
        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 2)
        {
            puntos++;
            respuesta = 1;
        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal3();
    }
    public void boton3Nivel3()
    {
       
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 3)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal3();
    }
    public void boton4Nivel3()
    {
       
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 4)
        {
            puntos++;
            respuesta = 1;

        }
        else
        {
            respuesta = 2;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal3();
    }

    void comprobarFinal3()
    {
        if (fasesTotales[contadorFases].contador == fasesTotales[contadorFases].preguntas.Count)
        {
            contadorFases++;
            if (contadorFases == fasesTotales.Count)
            {
                panelFin.SetActive(true);
                panelFin.transform.GetChild(3).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(4).GetComponent<Text>().text = "Los puntos maximos de esta prueba son 19 ";

                if (puntos == 19)
                {
                    panelFin.transform.GetChild(5).GetComponent<Text>().text = "Mejora de nivel en memoria a nivel 4";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(4);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(5).GetComponent<Text>().text = "Se mantiene el nivel 3 en memoria";
                }
            }
            else
            {
                panelNivel3.transform.GetChild(1).GetComponent<Image>().sprite = fasesTotales[contadorFases].imagen;
                botonesNivel3.SetActive(false);
                panelNivel3.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";
            }
        }
        else
        {
            siguientePreguntaNivel3();
        }
    }

    public void botonEmpezar3()
    {
        siguientePreguntaNivel3();
    }

    public void siguientePreguntaNivel3()
    {

        botonesNivel3.SetActive(true);
        generarBotones();

        string aux = fasesTotales[contadorFases].preguntas[fasesTotales[contadorFases].contador];
        panelNivel3.transform.GetChild(0).GetComponent<Text>().text = aux;

    }









    /// Nivel4


    void nivel4()
    {
        fases fase1 = new fases();
        fases fase2 = new fases();
        fases fase3 = new fases();

        fase1.imagen = cuarto;
        fase1.preguntas.Add("¿De qué color es el ventilador?");
        fase1.soluciones.Add(new Soluciones("Verde"));
        fase1.preguntas.Add("¿De qué color es el vestido?");
        fase1.soluciones.Add(new Soluciones("Rojo"));
        fase1.preguntas.Add("¿De qué color es la lámpara?");
        fase1.soluciones.Add(new Soluciones("Amarilla"));
        fase1.preguntas.Add("¿De qué color son las sábanas?");
        fase1.soluciones.Add(new Soluciones("Amarilla y blanca"));
        fase1.preguntas.Add("¿De qué color es la alfombra?");
        fase1.soluciones.Add(new Soluciones("Blanca y azul"));
        fase1.preguntas.Add("¿De qué color es la almohada?");
        fase1.soluciones.Add(new Soluciones("Blanca"));

        fase2.imagen = salon;
        fase2.preguntas.Add("¿De qué color es el sofá?");
        fase2.soluciones.Add(new Soluciones("Rojo"));
        fase2.preguntas.Add("¿De qué color es la puerta?");
        fase2.soluciones.Add(new Soluciones("Verde"));
        fase2.preguntas.Add("¿De qué color es la cortina?");
        fase2.soluciones.Add(new Soluciones("Blanca"));
        fase2.preguntas.Add("¿De qué color es la alfombra?");
        fase2.soluciones.Add(new Soluciones("Amarilla"));
        fase2.preguntas.Add("¿De qué color es el reloj?");
        fase2.soluciones.Add(new Soluciones("Rojo"));
        fase2.preguntas.Add("¿De qué color es la lámpara?");
        fase2.soluciones.Add(new Soluciones("Blanca"));
        fase2.preguntas.Add("¿De qué color es la libreta?");
        fase2.soluciones.Add(new Soluciones("Rosa"));
        fase2.preguntas.Add("¿De qué color es el teléfono?");
        fase2.soluciones.Add(new Soluciones("Negro"));
        fase2.preguntas.Add("¿De qué color es la camiseta?");
        fase2.soluciones.Add(new Soluciones("Marrón"));
        fase2.preguntas.Add("¿De qué color es el triciclo?");
        fase2.soluciones.Add(new Soluciones("Azul y amarillo"));
        fase2.preguntas.Add("¿De qué color son los cojines?");
        fase2.soluciones.Add(new Soluciones("amarillos"));



        fase3.imagen = zoo;
        fase3.preguntas.Add("¿Cuántas palomas hay?");
        fase3.soluciones.Add(new Soluciones("2"));
        fase3.preguntas.Add("¿Cuántas jirafas hay?");
        fase3.soluciones.Add(new Soluciones("1"));
        fase3.preguntas.Add("¿Cuántas mujeres hay?");
        fase3.soluciones.Add(new Soluciones("4"));
        fase3.preguntas.Add("¿Cuántas mariposas hay?");
        fase3.soluciones.Add(new Soluciones("3"));
        fase3.preguntas.Add("¿Cuántas niñas hay?");
        fase3.soluciones.Add(new Soluciones("1"));
        fase3.preguntas.Add("¿Cuántas nubes hay?");
        fase3.soluciones.Add(new Soluciones("4"));

        fasesTotales.Add(fase1);
        fasesTotales.Add(fase2);
        fasesTotales.Add(fase3);

        panelNivel4.SetActive(true);
        panelNivel4.transform.GetChild(1).GetComponent<Image>().sprite = cuarto;
        tiempo = 0;
        respustasNivel4 = new List<Soluciones>();
        posicionesPreguntas = new List<bool>();

        for (int i = 0; i < 4; i++)
        {
            posicionesPreguntas.Add(false);
            drags.transform.GetChild(i).GetComponent<Drag>().iniciarposicion();
        }
    }


    public void botonEmpezar4()
    {
        siguientePreguntaNivel4();
    }
  


    public void siguientePreguntaNivel4()
    {
        drags.transform.GetChild(0).GetComponent<Drag>().resetPosition();
        drags.transform.GetChild(1).GetComponent<Drag>().resetPosition();
        drags.transform.GetChild(2).GetComponent<Drag>().resetPosition();
        drags.transform.GetChild(3).GetComponent<Drag>().resetPosition();

        drags.transform.GetChild(0).gameObject.SetActive(false);
        drags.transform.GetChild(1).gameObject.SetActive(false);
        drags.transform.GetChild(2).gameObject.SetActive(false);
        drags.transform.GetChild(3).gameObject.SetActive(false);

        slots.transform.GetChild(0).gameObject.SetActive(false);
        slots.transform.GetChild(1).gameObject.SetActive(false);
        slots.transform.GetChild(2).gameObject.SetActive(false);
        slots.transform.GetChild(3).gameObject.SetActive(false);

        preguntas4.transform.GetChild(0).gameObject.SetActive(false);
        preguntas4.transform.GetChild(1).gameObject.SetActive(false);
        preguntas4.transform.GetChild(2).gameObject.SetActive(false);
        preguntas4.transform.GetChild(3).gameObject.SetActive(false);

        botonSiguienteN4.SetActive(false);
        numPreguntas = 0;
        movimientos = 0;
        respustasNivel4.Clear();

        for (int i = 0; i < 4; i++)
        {
            posicionesPreguntas[i] = false;
        }
       

        preguntas4.SetActive(true);

        if (fasesTotales[contadorFases].contador != fasesTotales[contadorFases].preguntas.Count)
        {
            for (int i = 0; i < 4; i++) //colocar las preguntas
            {
                if (fasesTotales[contadorFases].contador < fasesTotales[contadorFases].preguntas.Count)
                {
                    preguntas4.transform.GetChild(i).gameObject.SetActive(true);
                    slots.transform.GetChild(i).gameObject.SetActive(true);
                    drags.transform.GetChild(i).gameObject.SetActive(true);
                    preguntas4.transform.GetChild(i).GetComponent<Text>().text = fasesTotales[contadorFases].preguntas[fasesTotales[contadorFases].contador];
                    respustasNivel4.Add(fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador]);
                    fasesTotales[contadorFases].contador++;
                    numPreguntas++;
                }
            }

            for (int j = 0; j < respustasNivel4.Count; j++)  //colocar las respuestas
            {
                bool colocado = false;
                while (!colocado)
                {
                    int pos = Random.Range(0, respustasNivel4.Count);
                    if (posicionesPreguntas[pos] == false)
                    {
                        posicionesPreguntas[pos] = true;

                        drags.transform.GetChild(pos).GetChild(0).GetComponent<Text>().text = respustasNivel4[j].solucion2;
                        drags.transform.GetChild(pos).GetComponent<Drag>().id = j;
                        colocado = true;
                    }
                }
            }
            for (int i = 0; i < 4; i++)
            {
                posicionesPreguntas[i] = false;
            }
        }
        else //ya estamos al final de la fase
        {
            contadorFases++;
            if (contadorFases == fasesTotales.Count)
            {
                panelFin.SetActive(true);
                panelFin.transform.GetChild(3).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(4).GetComponent<Text>().text = "Los puntos maximos de esta prueba son 23 ";

                if (puntos == 23)
                {
                    panelFin.transform.GetChild(5).GetComponent<Text>().text = "Superado el nivel maximo";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(5);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(5).GetComponent<Text>().text = "Se mantiene el nivel 4 en memoria";
                }
            }
            else
            {
                preguntas4.SetActive(false);
                panelNivel4.transform.GetChild(1).GetComponent<Image>().sprite = fasesTotales[contadorFases].imagen;
            }
            
        }
    }

    public void sumarPunto(int id, bool dato)
    {
        posicionesPreguntas[id] = dato;
        movimientos++;
        if (movimientos >= numPreguntas)
        {
            botonCorregir.SetActive(true);
        }
        
    }

    public void botonCorregirN4()
    {
        respuesta = 0;
        respuesta2 = 0;
        respuesta3 = 0;
        respuesta4 = 0;
        for (int i =0; i< numPreguntas;i++)
        {
            if (posicionesPreguntas[i] == true)
            {
                puntos++;
                if (i == 0)
                {
                    respuesta = 1;
                }else if (i == 1)
                {
                    respuesta2 = 1;
                }else if (i==2)
                {
                    respuesta3 = 1;
                }else if (i == 3)
                {
                    respuesta4 = 1;
                }
            }
            else
            {
                if (i == 0)
                {
                    respuesta = 2;
                }
                else if (i == 1)
                {
                    respuesta2 = 2;
                }
                else if (i == 2)
                {
                    respuesta3 = 2;
                }
                else if (i == 3)
                {
                    respuesta4 = 2;
                }
            }
            tiempo = 10;
        }
        botonCorregir.SetActive(false);
        botonSiguienteN4.SetActive(true);
        panelBloqueo.SetActive(true);
        
    }
    public void botonSiguientePreguntaN4()
    {
        siguientePreguntaNivel4();
        panelBloqueo.SetActive(false);
        botonSiguienteN4.SetActive(false);
        tiempo = 0;
    }

    public void Update()
    {
        if (nivel == 4)
        {
            updateNivel4();
        }
        else
        {
            updateNivel1();
        }
        
        
    }

    void updateNivel1()
    {
        tiempo -= Time.deltaTime;
        if (tiempo > 0)
        {
            if (respuesta==1)
            {
                imagenRespuesta.SetActive(true);
                imagenRespuesta.GetComponent<Image>().sprite = tick;
            }
            else
            {
                imagenRespuesta.gameObject.SetActive(true);
                imagenRespuesta.GetComponent<Image>().sprite = cruz;
            }

        }
        else
        {
            imagenRespuesta.SetActive(false);
        }
        
    }
    void updateNivel4()
    {
        tiempo -= Time.deltaTime;
        if (tiempo > 0)
        {


            if (respuesta == 1)
            {
                imagenRespuesta4.SetActive(true);
                imagenRespuesta4.GetComponent<Image>().sprite = tick;
            }
            else if (respuesta2 == 2)
            {
                imagenRespuesta4.gameObject.SetActive(true);
                imagenRespuesta4.GetComponent<Image>().sprite = cruz;
            }           
          
            
            if (respuesta2==1)
            {
                imagenRespuesta3.SetActive(true);
                imagenRespuesta3.GetComponent<Image>().sprite = tick;
            }
            else if(respuesta2==2)
            {
                imagenRespuesta3.gameObject.SetActive(true);
                imagenRespuesta3.GetComponent<Image>().sprite = cruz;
            }
            
            
            
            if (respuesta3==1)
            {
                imagenRespuesta2.SetActive(true);
                imagenRespuesta2.GetComponent<Image>().sprite = tick;
            }
            else if(respuesta3==2)
            {
                imagenRespuesta2.gameObject.SetActive(true);
                imagenRespuesta2.GetComponent<Image>().sprite = cruz;
            }
            
            
            if (respuesta4==1)
            {
                imagenRespuesta.SetActive(true);
                imagenRespuesta.GetComponent<Image>().sprite = tick;
            }
            else if(respuesta4==2)
            {
                imagenRespuesta.gameObject.SetActive(true);
                imagenRespuesta.GetComponent<Image>().sprite = cruz;
            }
            

        }
        else
        {
            imagenRespuesta.SetActive(false);
            imagenRespuesta2.SetActive(false);
            imagenRespuesta3.SetActive(false);
            imagenRespuesta4.SetActive(false);

        }

    }

    public void botonInicio()
    {
        SceneManager.LoadScene(0);
    }
  
}



public class fases
{
    public fases()
    {
        preguntas = new List<string>();
        soluciones = new List<Soluciones>();
        contador = 0;
        audios = new List<AudioClip>();
    }
    public List<string> preguntas;
    public Sprite imagen;
    public int contador;
    public List<Soluciones> soluciones;
    public List<AudioClip> audios;
}

public class Soluciones
{
    public Soluciones(int pre,int sol)
    {
        pregunta = pre;
        solucion = sol;
    }
    public Soluciones(string res)
    {
        solucion2 = res;
    }

   public int pregunta;
   public int solucion;
    public string solucion2;
    
}
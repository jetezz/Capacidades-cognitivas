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
    bool respuesta = true;
    private AudioSource fuenteDeAudio;


    public int contadorFases=0;
    public int puntos = 0;      

    public Sprite bano;
    public Sprite granja;
    public Sprite cocina;
    public Sprite habitacion;
    public Sprite salon;
    public Sprite cruz;
    public Sprite tick;
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
        fase1.preguntas.Add("¿Dónde está el bater?");
        

        fase2.imagen = granja;
        fase2.preguntas.Add("¿Dónde está la barca?");
        fase2.preguntas.Add("¿Dónde está los patos?");
        fase2.preguntas.Add("¿Dónde está la vaca?");
        fase2.preguntas.Add("¿Dónde está el arbol con fruta?");
        fase2.preguntas.Add("¿Dónde está la cabaña?");
        fase2.preguntas.Add("¿Dónde está el arbol sin fruta?");


        fase3.imagen = cocina;
        fase3.preguntas.Add("¿Dónde está el horno?");
        fase3.preguntas.Add("¿Dónde está el frigorifico?");
        fase3.preguntas.Add("¿Dónde está el lavabo?");
        fase3.preguntas.Add("¿Dónde está el microondas?");

        fase4.imagen = habitacion;
        fase4.preguntas.Add("¿Dónde está el espejo?");
        fase4.preguntas.Add("¿Dónde está la planta?");
        fase4.preguntas.Add("¿Dónde está la cama?");
        fase4.preguntas.Add("¿Dónde está la ventana?");
        fase4.preguntas.Add("¿Dónde está la lampara?");

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
            respuesta = true;

        }
        else
        {
            respuesta = false;
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
            respuesta = true;
            
        }
        else
        {
            respuesta = false;
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
            respuesta = true;            
        }
        else
        {
            respuesta = false;
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
            respuesta = true;            
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            respuesta = true;
        }
        else
        {
            respuesta = false;
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
            fuenteDeAudio.clip = fasesTotales[contadorFases].audios[fasesTotales[contadorFases].contador];
            fuenteDeAudio.Play();

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
        fase1.preguntas.Add("¿Cuántos arboles hay?");
        fase1.soluciones.Add(new Soluciones(5, 1));
        fase1.preguntas.Add("De qué color es la casa?");
        fase1.soluciones.Add(new Soluciones(0, 2));
        fase1.preguntas.Add("Cuántas manzanas hay en el arbol?");
        fase1.soluciones.Add(new Soluciones(6, 2));
        fase1.preguntas.Add("De qué color es la barca?");
        fase1.soluciones.Add(new Soluciones(1, 2));
        fase1.preguntas.Add("Cómo está el dia?");
        fase1.soluciones.Add(new Soluciones(8, 2));
        fase1.preguntas.Add("Qué animales hay?");
        fase1.soluciones.Add(new Soluciones(9, 1));

        fase2.imagen = habitacion;
        fase2.preguntas.Add("¿De qué color son las sabanas?");
        fase2.soluciones.Add(new Soluciones(0, 1));
        fase2.preguntas.Add("¿Dónde esta el espejo?");
        fase2.soluciones.Add(new Soluciones(10, 1));
        fase2.preguntas.Add("De qué color es la alfombra?");
        fase2.soluciones.Add(new Soluciones(3, 1));
        fase2.preguntas.Add("¿De qué color es el suelo?");
        fase2.soluciones.Add(new Soluciones(0, 2));
        fase2.preguntas.Add("¿Cuántos cuadros hay?");
        fase2.soluciones.Add(new Soluciones(5, 1));
        fase2.preguntas.Add("¿Cómo son los cojines?");
        fase2.soluciones.Add(new Soluciones(12, 1));

        fase3.imagen = salon;
        fase3.preguntas.Add("¿Dónde esta la tele?");
        fase3.soluciones.Add(new Soluciones(11, 1));
        fase3.preguntas.Add("¿De qué color es el sofa?");
        fase3.soluciones.Add(new Soluciones(0, 2));        
        fase3.preguntas.Add("¿Dónde esta la percha?");
        fase3.soluciones.Add(new Soluciones(13, 1));
        fase3.preguntas.Add("¿De qué color es el telefono?");
        fase3.soluciones.Add(new Soluciones(3, 2));
        fase3.preguntas.Add("¿Dónde esta la alfombra?");
        fase3.soluciones.Add(new Soluciones(14, 1));
        fase3.preguntas.Add("¿De qué color es la lampara?");
        fase3.soluciones.Add(new Soluciones(3, 1));
        fase3.preguntas.Add("¿Cuántos cojines hay?");
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
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al boton empezar";        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion==1)
        {
            puntos++;
            respuesta = true;

        }
        else
        {
            respuesta = false;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
    public void boton2Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al boton empezar";        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 2)
        {
            puntos++;
            respuesta = true;

        }
        else
        {
            respuesta = false;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
    public void boton3Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al boton empezar";       
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 3)
        {
            puntos++;
            respuesta = true;

        }
        else
        {
            respuesta = false;
        }
        tiempo = 3;
        fasesTotales[contadorFases].contador++;
        comprobarFinal();
    }
    public void boton4Nivel2()
    {
        botonesNivel2.SetActive(false);
        panelNivel2.transform.GetChild(0).GetComponent<Text>().text = "Memoriza esta imagen y dale al boton empezar";        
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].solucion == 4)
        {
            puntos++;
            respuesta = true;

        }
        else
        {
            respuesta = false;
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
        if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 0)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Azul";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "rojo";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 1)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Verde";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Marron";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 2)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Blanco";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Naranja";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 3)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Amarillo";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Negro";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 4)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "1";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "3";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 5)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "2";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "4";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 6)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "3";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "5";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 7)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "4";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "6";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 8)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Soleado";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Nublado";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 9)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Cisne y vaca";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Perros y visne";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 10)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Izquierda";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Abajo";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 11)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Derecha";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Arriba";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 12)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Rallas";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Circulos";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 13)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "En la puerta";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "En la pared";
        }
        else if (fasesTotales[contadorFases].soluciones[fasesTotales[contadorFases].contador].pregunta == 14)
        {
            botonesNivel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = "Debajo de la mesa";
            botonesNivel2.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = "Debajo del sofá";
        }

    }
    void nivel3()
    {

    }
    void nivel4()
    {

    }

    public void Update()
    {       
        if (nivel == 1 || nivel==2)
        {
            updateNivel1();
        }
    }

    void updateNivel1()
    {
        tiempo -= Time.deltaTime;
        if (tiempo > 0)
        {
            if (respuesta)
            {
                canvas.transform.GetChild(6).gameObject.SetActive(true);
                canvas.transform.GetChild(6).GetComponent<Image>().sprite = tick;
            }
            else
            {
                canvas.transform.GetChild(6).gameObject.SetActive(true);
                canvas.transform.GetChild(6).GetComponent<Image>().sprite = cruz;
            }

        }
        else
        {
            canvas.transform.GetChild(6).gameObject.SetActive(false);
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

   public int pregunta;
   public int solucion;
    
}
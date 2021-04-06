using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Memoria : MonoBehaviour
{
    GameObject sonidos;
    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;
    private float tiempo = 0;
    int nivel;

    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

  
    public GameObject canvas;
  
    int respuesta = 0;
    int respuesta2 = 0;
    int respuesta3 = 0;
    int respuesta4 = 0;
   
    public GameObject imagenRespuesta;
    public GameObject imagenRespuesta2;
    public GameObject imagenRespuesta3;
    public GameObject imagenRespuesta4;


    public int contadorFases=0;
       

    public Sprite bano;
    public Sprite granja;
    public Sprite cocina;
    public Sprite habitacion;
    public Sprite salon;
    public Sprite cocina2;
    public Sprite salon2;
    public Sprite salon3;
    public Sprite cuarto;
    public Sprite zoo;

    List<fases> fasesTotales;
    
    





    /////// nivel 1
    int preguntasMaximas = 0;
    List<MemoriaN1> preguntas1;
    public GameObject panel1;
    public GameObject botonesFase1;
    public GameObject botonesFase2;
    public GameObject botonesFase3;
    public GameObject botonesFase4;
    public GameObject botonesFase5;
    public GameObject botonesFase6;


   

    /////// nivel2
    public GameObject panelNivel2;
    List<ListMemoriaN2> preguntas2;
    public GameObject botones;
    

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
       
        fasesTotales = new List<fases>();
        sonidos = GameObject.FindWithTag("Sonido");

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
            nivel2();
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
        preguntas1 = new List<MemoriaN1>();

        List<PreguntasN1> aux = new List<PreguntasN1>();
        List<MemoriaN1> pregRandom = new List<MemoriaN1>();


        aux.Add(new PreguntasN1("¿Dónde está la bañera?",0));
        aux.Add(new PreguntasN1("¿Dónde está el lavabo?",1));
        aux.Add(new PreguntasN1("¿¿Dónde está el espejo??",2));
        aux.Add(new PreguntasN1("¿Dónde está la lavadora?",3));
        aux.Add(new PreguntasN1("¿Dónde está el calentador?",4));
        aux.Add(new PreguntasN1("¿Dónde está el váter?",5));
        pregRandom.Add(new MemoriaN1(aux,bano,botonesFase1));



        List<PreguntasN1> aux2 = new List<PreguntasN1>();
        aux2.Add(new PreguntasN1("¿Dónde está la barca?", 0));
        aux2.Add(new PreguntasN1("¿Dónde están los patos?", 1));
        aux2.Add(new PreguntasN1("¿Dónde está la vaca?", 2));
        aux2.Add(new PreguntasN1("¿Dónde está el árbol con fruta?", 3));
        aux2.Add(new PreguntasN1("¿Dónde está la cabaña?", 4));
        aux2.Add(new PreguntasN1("¿Dónde está el árbol sin fruta?", 5));
        pregRandom.Add(new MemoriaN1(aux2, granja, botonesFase2));


        List<PreguntasN1> aux3 = new List<PreguntasN1>();
        aux3.Add(new PreguntasN1("¿Dónde está el horno?", 0));
        aux3.Add(new PreguntasN1("¿Dónde está el frigorífico?", 1));
        aux3.Add(new PreguntasN1("¿Dónde está el fregadero?", 2));
        aux3.Add(new PreguntasN1("¿Dónde está el microondas?", 3));
        pregRandom.Add(new MemoriaN1(aux3, cocina, botonesFase3));

        List<PreguntasN1> aux4 = new List<PreguntasN1>();
        aux4.Add(new PreguntasN1("¿Dónde está el espejo?", 0));
        aux4.Add(new PreguntasN1("¿Dónde está la maceta?", 1));
        aux4.Add(new PreguntasN1("¿Dónde está la cama?", 2));
        aux4.Add(new PreguntasN1("¿Dónde está la ventana?", 3));
        aux4.Add(new PreguntasN1("¿Dónde está la lámpara?", 4));

        pregRandom.Add(new MemoriaN1(aux4, habitacion, botonesFase4));

        List<PreguntasN1> aux5 = new List<PreguntasN1>();
        aux5.Add(new PreguntasN1("¿Dónde está el frigorífico?", 0));
        aux5.Add(new PreguntasN1("¿Dónde está la mesa?", 1));
        aux5.Add(new PreguntasN1("¿Dónde está la ventana?", 2));
        aux5.Add(new PreguntasN1("¿Dónde está la fregadero?", 3));       

        pregRandom.Add(new MemoriaN1(aux5, cocina2, botonesFase5));

        List<PreguntasN1> aux6 = new List<PreguntasN1>();
        aux6.Add(new PreguntasN1("¿Dónde está el sillón?", 0));
        aux6.Add(new PreguntasN1("¿Dónde está la televisión?", 1));
        aux6.Add(new PreguntasN1("¿Dónde está la lámpara?", 2));
       

        pregRandom.Add(new MemoriaN1(aux6, salon3, botonesFase6));

        pregRandom = DesordenarLista<MemoriaN1>(pregRandom);

        for (int i = 0; i < 2; i++)
        {
            preguntas1.Add(pregRandom[i]);
        }
       
        
  

        
        panel1.SetActive(true);

        iniciarFaseN1();
        

    }
   



     void siguientePreguntaN1()
    {
       
        
            if (preguntas1[contador].preguntas.Count > 0)
            {
                int rand = Random.Range(0, preguntas1[contador].preguntas.Count);
                textoPrincipal.GetComponent<Text>().text = preguntas1[contador].preguntas[rand].pregunta;
                preguntas1[contador].solucion = preguntas1[contador].preguntas[rand].id;
            }
            else
            {
                contador++;                  
                iniciarFaseN1();
                
            }
        
     
    }
    public void iniciarFaseN1()
    {
        if (contador < preguntas1.Count)
        {
            botonesFase1.SetActive(false);
            botonesFase2.SetActive(false);
            botonesFase3.SetActive(false);
            botonesFase4.SetActive(false);
            panel1.transform.GetChild(0).GetComponent<Image>().sprite = preguntas1[contador].imagen;
            preguntas1[contador].escena.SetActive(true);

            siguientePreguntaN1();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de memoria nivel 1 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + preguntasMaximas.ToString();
            if (puntos == preguntasMaximas)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 2";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(2);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 1";
            }
            sonidos.GetComponent<Sonidos>().repSonido(4);
        }


    }
    public void botonesNivel1(int id)
    {
        if (id == preguntas1[contador].solucion)
        {
            for(int i = 0; i < preguntas1[contador].preguntas.Count; i++)
            {
                if (id == preguntas1[contador].preguntas[i].id)
                {
                    preguntas1[contador].preguntas.Remove(preguntas1[contador].preguntas[i]);
                    break;
                }
            }
            preguntasMaximas++;
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);
        }
        else
        {
            puntos--;
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);

        }
        tiempo = 1;        
        siguientePreguntaN1();
    }

    ///////////////////////////////////
    

    //////NIVEL2
    void nivel2()
    {
        preguntas2 = new List<ListMemoriaN2>();
        List<ListMemoriaN2> pregRandom = new List<ListMemoriaN2>();
        List<MemoriaN2> fase1 = new List<MemoriaN2>();
        List<MemoriaN2> fase2 = new List<MemoriaN2>();
        List<MemoriaN2> fase3 = new List<MemoriaN2>();
        List<MemoriaN2> fase4 = new List<MemoriaN2>();
        List<MemoriaN2> fase5 = new List<MemoriaN2>();


        List<string> colores = new List<string>();
        colores.Add("Rojo");
        colores.Add("Azul");
        colores.Add("Marron");
        colores.Add("Blanco");
        colores.Add("Verde");
        colores.Add("Amarillo");
        colores.Add("Violeta");
        colores.Add("Negro");
        colores.Add("Rosa");
        colores.Add("Morada");
        colores.Add("Naranja");




        List<string> numeros = new List<string>();
        numeros.Add("1");
        numeros.Add("2");
        numeros.Add("3");
        numeros.Add("4");
        numeros.Add("5");
        numeros.Add("6");
        numeros.Add("7");
        numeros.Add("8");
        numeros.Add("9");

        List<string> clima = new List<string>();
        clima.Add("Soleado");
        clima.Add("Lluvioso");
        clima.Add("Con viento");
        clima.Add("Con nieve");

        List<string> animales = new List<string>();
        animales.Add("Cisnes y vaca");
        animales.Add("Perros y cisnes");
        animales.Add("Vaca y perro");
        animales.Add("Vaca");

        List<string> posicion = new List<string>();
        posicion.Add("Izquierda");
        posicion.Add("Derecha");
        posicion.Add("Arriba");
        posicion.Add("Abajo");

        List<string> posicion2 = new List<string>();
        posicion2.Add("En el sofá");
        posicion2.Add("En el suelo");
        posicion2.Add("Al lado de la puerta");
        posicion2.Add("En la puerta");
        posicion2.Add("En la pared");
        posicion2.Add("En la mesa");
        posicion2.Add("Debajo de la mesa");
        posicion2.Add("Debajo del sofá");
        posicion2.Add("Encima del mueble");
        posicion2.Add("Encima de la cama");
        posicion2.Add("Delanten del armario");
        posicion2.Add("Al lado de la ventana");
        posicion2.Add("Al lado de la caman");
        posicion2.Add("Enfrente del sofá");
        posicion2.Add("Debajo de la televisión");

        List<string> estampados = new List<string>();
        estampados.Add("De rallas");
        estampados.Add("De círculos");
        estampados.Add("De lunares");
        estampados.Add("De cuadrados");

        fase1.Add(new MemoriaN2("¿Cuántos árboles hay?", numeros ,1));
        fase1.Add(new MemoriaN2("¿De qué color es la casa?", colores,0));
        fase1.Add(new MemoriaN2("¿Cuántas manzanas hay en el árbol?", numeros,4));
        fase1.Add(new MemoriaN2("¿De qué color es la barca?", colores,2));
        fase1.Add(new MemoriaN2("¿Cómo está el dia?", clima,0));
        fase1.Add(new MemoriaN2("¿Qué especies de animales hay ? ", animales, 0));

        pregRandom.Add(new ListMemoriaN2(fase1, granja));

        fase2.Add(new MemoriaN2("¿De qué color son las sábanas?", colores, 1));
        fase2.Add(new MemoriaN2("¿Dónde está el espejo?", posicion, 0));
        fase2.Add(new MemoriaN2("¿De qué color es la alfombra?", colores, 5));
        fase2.Add(new MemoriaN2("¿De qué color es el suelo ? ", colores, 0));
        fase2.Add(new MemoriaN2("¿Cuántos cuadros hay?", numeros, 1));
        fase2.Add(new MemoriaN2("¿Cómo son los cojines? ", estampados, 0));

        pregRandom.Add(new ListMemoriaN2(fase2, habitacion));


        fase3.Add(new MemoriaN2("¿Dónde está el gato?", posicion2, 0));
        fase3.Add(new MemoriaN2("¿De qué color es el sofá?", colores, 5));
        fase3.Add(new MemoriaN2("¿De qué color son las cortinas?", colores, 8));
        fase3.Add(new MemoriaN2("¿Cuántas macetas hay en la ventana? ", numeros, 1));
        fase3.Add(new MemoriaN2("¿Dónde está la mesa?", posicion2, 13));
        fase3.Add(new MemoriaN2("¿De qué color es la lámpara? ", colores, 9));
        fase3.Add(new MemoriaN2("¿Cuántos cuadros hay? ", numeros, 1));

        pregRandom.Add(new ListMemoriaN2(fase3, salon2));

        fase4.Add(new MemoriaN2("¿Cuantos cojines hay?", numeros, 1));
        fase4.Add(new MemoriaN2("¿Dónde está la ventana?", posicion, 0));
        fase4.Add(new MemoriaN2("¿De qué color es la televisión?", colores, 1));
        fase4.Add(new MemoriaN2("¿De qué color es la alfombra? ", colores, 4));
        fase4.Add(new MemoriaN2("¿de qué color es la pared?", colores, 4));        

        pregRandom.Add(new ListMemoriaN2(fase4, salon3));

        fase5.Add(new MemoriaN2("¿Cuántas sillas hay?", numeros, 1));
        fase5.Add(new MemoriaN2("¿De qué color son las sillas?", colores, 1));
        fase5.Add(new MemoriaN2("¿Dónde está el frigorifico?", posicion, 0));
        fase5.Add(new MemoriaN2("¿De qué color es el mantel? ", colores, 10));
        fase5.Add(new MemoriaN2("¿De qué color es el frigorifico?", colores, 4));

        pregRandom.Add(new ListMemoriaN2(fase5, cocina2));


        pregRandom = DesordenarLista<ListMemoriaN2>(pregRandom);
        pregRandom = DesordenarLista<ListMemoriaN2>(pregRandom);
        for (int i = 0; i < 2; i++)
        {
            preguntas2.Add(pregRandom[i]);
        }
       
        cargarImagen();
        
        panelNivel2.SetActive(true);


      
    }

    void cargarImagen()
    {
        if (contador < preguntas2.Count)
        {
            panelNivel2.transform.GetChild(0).GetComponent<Image>().sprite = preguntas2[contador].imagen;
            textoPrincipal.GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";
        }
        
    }
    public void botonEmpezar()
    {

        siguientePreguntaN2();
    }
     void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
           
            
            textoPrincipal.GetComponent<Text>().text = preguntas2[contador].preguntas[preguntas2[contador].contador].pregunta;
            if (nivel == 2)
            {
                generarBotones(2);
            }
            else
            {
                generarBotones(4);
            }
            
            
           
          
        }
        else
        {
            if (nivel == 2)
            {
                panelFin.SetActive(true);
                textoPrincipal.GetComponent<Text>().text = "Ejercicio de memoria nivel 2 completado";
                panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + preguntasMaximas.ToString();
                if (puntos == preguntasMaximas)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 3";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(3);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 2";
                }
            }
            else
            {
                panelFin.SetActive(true);
                textoPrincipal.GetComponent<Text>().text = "Ejercicio de memoria nivel 3 completado";
                panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + preguntasMaximas.ToString();
                if (puntos == preguntasMaximas)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 4";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.memoria(4);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 3";
                }
            }
            sonidos.GetComponent<Sonidos>().repSonido(4);
        }
        
       
               
    }
    void generarBotones(int i)
    {
        List<Grupo> aux = new List<Grupo>();
        aux.Add(new Grupo(preguntas2[contador].preguntas[preguntas2[contador].contador].otras[preguntas2[contador].preguntas[preguntas2[contador].contador].solucion],true));
        botones.SetActive(true);
        for(int j = 1; j < i; j++)
        {
            int rand = Random.Range(0, preguntas2[contador].preguntas[preguntas2[contador].contador].otras.Count);
            bool repetida = false;
            for (int x = 0; x < aux.Count; x++)
            {
                if (aux[x].respuesta == preguntas2[contador].preguntas[preguntas2[contador].contador].otras[rand])
                {
                    repetida = true;
                }
            }
              
            if (repetida)
            {
                j--;
            }
            else
            {
                aux.Add(new Grupo(preguntas2[contador].preguntas[preguntas2[contador].contador].otras[rand], false));
            }

        }
        aux = DesordenarLista<Grupo>(aux);

        for(int j = 0; j < i; j++)
        {
            botones.transform.GetChild(j).gameObject.SetActive(true);
            botones.transform.GetChild(j).GetChild(0).GetComponent<Text>().text = aux[j].respuesta;
            botones.transform.GetChild(j).GetComponent<IdSeleccion>().correcto = aux[j].correcto;
        }
    }

    public void pulsarBotonN2(int id)
    {
        preguntasMaximas++;
        botones.SetActive(false);
        if (botones.transform.GetChild(id).GetComponent<IdSeleccion>().correcto)
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
        preguntas2[contador].contador++;
        if(preguntas2[contador].contador>= preguntas2[contador].preguntas.Count)
        {
            contador++;
        }
        botones.SetActive(false);
        cargarImagen();
        
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
        panelNivel4.transform.GetChild(0).GetComponent<Image>().sprite = cuarto;
        tiempo = 0;
        respustasNivel4 = new List<Soluciones>();
        posicionesPreguntas = new List<bool>();
        textoPrincipal.GetComponent<Text>().text = "Memoriza esta imagen y dale al botón empezar";
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
                panelNivel4.transform.GetChild(0).GetComponent<Image>().sprite = fasesTotales[contadorFases].imagen;
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
          
           imagenCorreccion.SetActive(true);
            
        }
        else
        {
            imagenCorreccion.SetActive(false);
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
        sonidos.GetComponent<Sonidos>().repSonido(1);
    }
    public void siguienteEjercicio()
    {
        managerEjercicios.GetComponent<ManagerEjercicios>().iniciarEjercicio();
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

class MemoriaN1
{

    public MemoriaN1(List<PreguntasN1>pre,Sprite im, GameObject esc)
    {
        preguntas = new List<PreguntasN1>();
        preguntas = pre;
        imagen = im;
        escena = esc;
    }
    public List<PreguntasN1> preguntas;
    public Sprite imagen;
    public GameObject escena;
    public int solucion;

}

 class PreguntasN1
{
    public PreguntasN1(string preg,int i)
    {
        pregunta = preg;
        id = i;
    }
    public string pregunta;
    public int id;
}

class MemoriaN2
{
    public MemoriaN2(string pre, List<string>otr, int sol)
    {
        otras = new List<string>();
        pregunta = pre;
        otras = otr;        
        solucion = sol;
    }

    public string pregunta;
    public List<string> otras;   
    public int solucion;
    

}
class ListMemoriaN2
{
    public ListMemoriaN2(List<MemoriaN2> lista,Sprite img)
    {
        preguntas = new List<MemoriaN2>();
        preguntas = lista;
        imagen = img;
    }
    public List<MemoriaN2> preguntas;
    public Sprite imagen;
    public int contador = 0;
}

class Grupo
{
    public Grupo(string res,bool corr)
    {
        respuesta = res;
        correcto = corr;
    }
    public string respuesta;
    public bool correcto;
}
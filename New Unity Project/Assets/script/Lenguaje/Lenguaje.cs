using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lenguaje : MonoBehaviour
{
    GameObject sonidos;
    private AudioSource fuenteDeAudio;
    private GameObject managerEjercicios;
    private int contador = 0;
    private int puntos = 0;
    private int nivel;
    private float tiempo = 0;
    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;
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
    public Sprite rosa;
    public Sprite amapola;
    public Sprite abrigo;
    public Sprite secador;
    public Sprite conejo;
    public Sprite ballena;
    public Sprite sandalia;
    public Sprite violin;
    public Sprite campana;
    public Sprite cebolla;
    public Sprite fresa;
    public Sprite rombo;
    public Sprite cuadro;



    ////
    ///nivel1
    List<Preguntas1> preguntas1 = new List<Preguntas1>();
    List<Preguntas1> preguntas1aux = new List<Preguntas1>();

    public GameObject panel1;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject boton4;

    ////
    ///Nivel2
    List<Pregunta2> preguntas2 = new List<Pregunta2>();
    public GameObject panel2;
    public GameObject boton1N2;
    public GameObject boton2N2;
    public GameObject boton3N2;
    public GameObject boton4N2;
    public GameObject boton5N2;
    public GameObject boton6N2;

    ///
    ///Nivel3
    List<Pregunta3> preguntas3 = new List<Pregunta3>();
    public GameObject panel3;
    Dictionary<int, string> idYPregun = new Dictionary<int, string>();

    //
    //nivel 4
    List<FaseP4> fases4 = new List<FaseP4>();
    List<FaseP4> fases4aux = new List<FaseP4>();

    public GameObject panel4;
    public GameObject palabra;
    public GameObject hand;
    public GameObject botonCorregir;
    public GameObject botonSiguiente;
    public GameObject categoria1;
    public GameObject categoria2;
    public GameObject categoria3;
    public GameObject block;

    public object F4E { get; private set; }

    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();        

        managerEjercicios = GameObject.FindWithTag("MEje");
        sonidos = GameObject.FindWithTag("Sonido");



        if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 1)
        {
            nivel1();
            nivel = 1;
            
        }
        else if (managerEjercicios.GetComponent<ManagerEjercicios>().nivel == 2)
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
    void final(string nivel, int pMax, int pMin, int siguienteNnivel,bool ultimo)
    {
        textoPrincipal.GetComponent<Text>().text = "Finalizado los ejercicios de Lenguaje nivel " + (siguienteNnivel - 1).ToString();
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos m�ximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.lenguaje(siguienteNnivel);
            GameObject managerUsuario = GameObject.FindWithTag("MUsu");
            managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            int au;
            au = Random.Range(4, 8);
            sonidos.GetComponent<Sonidos>().repAudio(3, au);
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
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.lenguaje(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                int au;
                au = Random.Range(8, 10);
                sonidos.GetComponent<Sonidos>().repAudio(3, au);
            }
            else
            {
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.lenguaje(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                int au;
                au = Random.Range(8, 10);
                sonidos.GetComponent<Sonidos>().repAudio(3, au);
            }



        }
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }

    void nivel1()
    {
        preguntas1aux = new List<Preguntas1>();
        List<Pregunta1> aux = new List<Pregunta1>();
        aux.Add(new Pregunta1("Pulsa el color azul", 1, 0,0));
        aux.Add(new Pregunta1("Pulsa el color rojo", 2, 0,1));
        aux.Add(new Pregunta1("Pulsa el color verde", 3, 0,2));
        aux.Add(new Pregunta1("Pulsa el color negro", 4, 0,3));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa la falda", 1, 1,4));
        aux.Add(new Pregunta1("Pulsa el calcet�n", 2, 1,5));
        aux.Add(new Pregunta1("Pulsa la chaqueta", 3, 1,6));
        aux.Add(new Pregunta1("Pulsa el pantal�n", 4, 1,7));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa el perro", 1, 2,8));
        aux.Add(new Pregunta1("Pulsa el gato", 2, 2,9));
        aux.Add(new Pregunta1("Pulsa el caballo", 3, 2,10));
        aux.Add(new Pregunta1("Pulsa la oveja", 4, 2,11));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa las zapatillas de estar por casa", 1, 3,12));
        aux.Add(new Pregunta1("Pulsa las botas", 2, 3,13));
        aux.Add(new Pregunta1("Pulsa las chanclas", 3, 3,14));
        aux.Add(new Pregunta1("Pulsa las deportivas", 4, 3,15));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa la guitarra", 1, 4,16));
        aux.Add(new Pregunta1("Pulsa el tambor", 2, 4,17));
        aux.Add(new Pregunta1("Pulsa la flauta", 3, 4,18));
        aux.Add(new Pregunta1("Pulsa el piano", 4, 4,19));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa el tomate", 1, 5,20));
        aux.Add(new Pregunta1("Pulsa la lechuga", 2, 5,21));
        aux.Add(new Pregunta1("Pulsa la zanahoria", 3, 5,22));
        aux.Add(new Pregunta1("Pulsa el pepino", 4, 5,23));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa el c�rculo", 1, 6,24));
        aux.Add(new Pregunta1("Pulsa el cuadrado", 2, 6,25));
        aux.Add(new Pregunta1("Pulsa el tri�ngulo", 3, 6,26));
        aux.Add(new Pregunta1("Pulsa el rect�ngulo", 4, 6,27));
        preguntas1aux.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        preguntas1aux = DesordenarLista<Preguntas1>(preguntas1aux);
       for(int i = 0; i < 5; i++)
        {
            preguntas1.Add(preguntas1aux[i]);
        }


        panel1.SetActive(true);

        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (preguntas1[contador].contador < preguntas1[contador].preguntas.Count)
        {
            if (contador < preguntas1.Count)
            {
                sonidos.GetComponent<Sonidos>().repAudio(1, preguntas1[contador].preguntas[preguntas1[contador].contador].audio);
                textoPrincipal.GetComponent<Text>().text = preguntas1[contador].preguntas[preguntas1[contador].contador].pregunta;
                generarGrupo();
            }
        }
        else
        {
            contador++;
            panel1.transform.GetChild(0).gameObject.SetActive(true);
            panel1.transform.GetChild(1).gameObject.SetActive(true);
            panel1.transform.GetChild(2).gameObject.SetActive(true);
            panel1.transform.GetChild(3).gameObject.SetActive(true);
            if (contador < preguntas1.Count)
            {
                siguientePreguntaN1();
            }
            else
            {
                final("Ejercicio de Lenguaje nivel 1 completado", 20, 0, 2,false);
            }
        }
    }

    void generarGrupo()
    {
        if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 0)
        {
            boton1.GetComponent<Image>().sprite = azul;
            boton2.GetComponent<Image>().sprite = rojo;
            boton3.GetComponent<Image>().sprite = verde;
            boton4.GetComponent<Image>().sprite = negro;
        }
        else if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 1)
        {
            boton1.GetComponent<Image>().sprite = falda;
            boton2.GetComponent<Image>().sprite = calcetin;
            boton3.GetComponent<Image>().sprite = chaqueta;
            boton4.GetComponent<Image>().sprite = pantalon;
        }
        else if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 2)
        {
            boton1.GetComponent<Image>().sprite = perro;
            boton2.GetComponent<Image>().sprite = gato;
            boton3.GetComponent<Image>().sprite = caballo;
            boton4.GetComponent<Image>().sprite = oveja;
        }
        else if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 3)
        {
            boton1.GetComponent<Image>().sprite = zapatilla;
            boton2.GetComponent<Image>().sprite = bota;
            boton3.GetComponent<Image>().sprite = chancla;
            boton4.GetComponent<Image>().sprite = deportiva;
        }
        else if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 4)
        {
            boton1.GetComponent<Image>().sprite = guitarra;
            boton2.GetComponent<Image>().sprite = tambor;
            boton3.GetComponent<Image>().sprite = flauta;
            boton4.GetComponent<Image>().sprite = piano;
        }
        else if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 5)
        {
            boton1.GetComponent<Image>().sprite = tomate;
            boton2.GetComponent<Image>().sprite = lechuga;
            boton3.GetComponent<Image>().sprite = zanahoria;
            boton4.GetComponent<Image>().sprite = pepino;
        }
        else if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 6)
        {
            boton1.GetComponent<Image>().sprite = circulo;
            boton2.GetComponent<Image>().sprite = cuadrado;
            boton3.GetComponent<Image>().sprite = triangulo;
            boton4.GetComponent<Image>().sprite = rectangulo;
        }
    }
    public void botonSolucionN1(int i)
    {
        if (preguntas1[contador].preguntas[preguntas1[contador].contador].solucion == i)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            panel1.transform.GetChild(i - 1).gameObject.SetActive(false);
            sonidos.GetComponent<Sonidos>().repSonido(2);

        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);

        }
        preguntas1[contador].contador++;
        siguientePreguntaN1();
        tiempo = 1;
    }





    void nivel2()
    {
        List<Pregunta2> aux = new List<Pregunta2>();
        aux.Add(new Pregunta2(amapola, conjuntosN2(1)));
        aux.Add(new Pregunta2(secador, conjuntosN2(2)));
        aux.Add(new Pregunta2(ballena, conjuntosN2(3)));
        aux.Add(new Pregunta2(calcetin, conjuntosN2(4)));
        aux.Add(new Pregunta2(perro, conjuntosN2(5)));
        aux.Add(new Pregunta2(fresa, conjuntosN2(6)));
        aux.Add(new Pregunta2(cuadro, conjuntosN2(7)));

        aux.Add(new Pregunta2(chaqueta, conjuntosN2(4)));
        //aux.Add(new Pregunta2(zapatilla, conjuntosN2(2)));
        aux.Add(new Pregunta2(tambor, conjuntosN2(7)));
        //aux.Add(new Pregunta2(deportiva, conjuntosN2(2)));
        aux.Add(new Pregunta2(lechuga, conjuntosN2(3)));
        aux.Add(new Pregunta2(flauta, conjuntosN2(6)));


        preguntas2 = DesordenarLista<Pregunta2>(aux);
        sonidos.GetComponent<Sonidos>().repAudio(1, 28);
        textoPrincipal.GetComponent<Text>().text = "�Qu� imagen no corresponde con el grupo?";
        panel2.SetActive(true);
        siguientePreguntaN2();



    }
    void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
            int numRand = Random.Range(0, 6);
            for (int i = 0; i < 6; i++)
            {
                if (i == numRand)
                {
                    panel2.transform.GetChild(i).GetComponent<Image>().sprite = preguntas2[contador].imagen;
                    preguntas2[contador].solucion = numRand;
                }
                else
                {
                    panel2.transform.GetChild(i).GetComponent<Image>().sprite = preguntas2[contador].listaImagenes[preguntas2[contador].contadorImagen];
                    preguntas2[contador].contadorImagen++;
                }
            }
        }
        else
        {
                final("Ejercicio de Lenguaje nivel 2 completado", 11, 4, 3,false);

        }
    }
    public void botonNivel2(int i)
    {
        if (i == preguntas2[contador].solucion)
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
        contador++;
        tiempo = 1;
        siguientePreguntaN2();
    }

    List<Sprite> conjuntosN2(int conjunto)
    {
        List<Sprite> outList = new List<Sprite>();
        if (conjunto == 1)
        {
            outList.Add(azul);
            outList.Add(rojo);
            outList.Add(verde);
            outList.Add(negro);
            outList.Add(rosa);
        }
        else if (conjunto == 2)
        {
            outList.Add(falda);
            outList.Add(calcetin);
            outList.Add(chaqueta);
            outList.Add(pantalon);
            outList.Add(abrigo);
        }
        else if (conjunto == 3)
        {
            outList.Add(perro);
            outList.Add(gato);
            outList.Add(caballo);
            outList.Add(oveja);
            outList.Add(conejo);
        }
        else if (conjunto == 4)
        {
            outList.Add(zapatilla);
            outList.Add(bota);
            outList.Add(chancla);
            outList.Add(deportiva);
            outList.Add(sandalia);
        }
        else if (conjunto == 5)
        {
            outList.Add(guitarra);
            outList.Add(tambor);
            outList.Add(flauta);
            outList.Add(piano);
            outList.Add(violin);
        }
        else if (conjunto == 6)
        {
            outList.Add(tomate);
            outList.Add(lechuga);
            outList.Add(zanahoria);
            outList.Add(pepino);
            outList.Add(cebolla);
        }
        else if (conjunto == 7)
        {
            outList.Add(circulo);
            outList.Add(cuadrado);
            outList.Add(triangulo);
            outList.Add(rectangulo);
            outList.Add(rombo);
        }


        return outList;
    }


    void nivel3()
    {
        List<Pregunta3> aux = new List<Pregunta3>();
        aux.Add(new Pregunta3("Madrid - Sevilla - Barcelona - Burgos - Soria", 0,29));
        aux.Add(new Pregunta3("Espa�a - China - Portugal - Brasil - Francia", 1,30));
        aux.Add(new Pregunta3("Enero -  Marzo - Febrero - Abril", 2,31));
        aux.Add(new Pregunta3("Cuchillo - Tenedor - Cuchara - Platos - Cazo", 3,32));
        aux.Add(new Pregunta3("Mesa - Silla - Escritorio - Sill�n - Cama", 4,33));
        aux.Add(new Pregunta3("Dormitorio - Sal�n - Cocina - Despacho - Ba�o", 5,34));
        aux.Add(new Pregunta3("Paula - Ana - Josefa - Manuela - Rosa - Estefan�a", 6,35));
        aux.Add(new Pregunta3("Paco - Jos� - Mario - Manuel - Pedro", 7,36));
        aux.Add(new Pregunta3("T�o - Prima - Abuela - Hijo - Sobrino - Nieto", 8,37));
        preguntas3 = DesordenarLista<Pregunta3>(aux);

        idYPregun.Add(0, "Ciudades");
        idYPregun.Add(1, "Paises");
        idYPregun.Add(2, "Meses");
        idYPregun.Add(3, "Utensilios de cocina");
        idYPregun.Add(4, "Muebles");
        idYPregun.Add(5, "Habitaciones");
        idYPregun.Add(6, "Nombres femeninos");
        idYPregun.Add(7, "Nombres masculinos");
        idYPregun.Add(8, "Parientes");


        panel3.SetActive(true);
        sonidos.GetComponent<Sonidos>().repAudio(1, 38);
        textoPrincipal.GetComponent<Text>().text = "�A qu� grupo corresponden estas palabras?";
        siguientePreguntaN3();

    }

    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            panel3.transform.GetChild(0).GetComponent<Text>().text = preguntas3[contador].pregunta;
            generarBotonesN3();
            //sonidos.GetComponent<Sonidos>().repAudio(1, preguntas3[contador].audio);

        }
        else
        {
            final("Ejercicio de Lenguaje nivel 3 completado", 9, 4, 4,false);

        }
    }

    void generarBotonesN3()
    {
        List<int> aux = new List<int>();
        aux.Add(preguntas3[contador].respuesta);
        bool salir = false;
        while (aux.Count < 4)
        {
            salir = false;
            int ran = Random.Range(0, 8);
            for (int i = 0; i < aux.Count; i++)
            {
                if (aux[i] == ran)
                {
                    salir = true;
                    break;
                }
            }
            if (!salir)
                aux.Add(ran);
        }

        List<int> botones = new List<int>();
        botones = DesordenarLista<int>(aux);

        for (int i = 0; i < 4; i++)
        {
            if (botones[i] == preguntas3[contador].respuesta)
            {
                preguntas3[contador].solucion = i;
            }
        }
        panel3.transform.GetChild(1).GetChild(0).GetComponent<Text>().text = idYPregun[botones[0]];
        panel3.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = idYPregun[botones[1]];
        panel3.transform.GetChild(3).GetChild(0).GetComponent<Text>().text = idYPregun[botones[2]];
        panel3.transform.GetChild(4).GetChild(0).GetComponent<Text>().text = idYPregun[botones[3]];


    }

    public void botonN3(int i)
    {
        if (i == preguntas3[contador].solucion)
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
        contador++;
        tiempo = 1;
        siguientePreguntaN3();
    }


    void nivel4()
    {
        List<Pregunta4> fase1 = new List<Pregunta4>();
        List<Pregunta4> fasesaux = new List<Pregunta4>();
        List<Pregunta4> fase2 = new List<Pregunta4>();

        fasesaux.Add(new Pregunta4("Cebolla", 0));
        fasesaux.Add(new Pregunta4("Pepino", 0));
        fasesaux.Add(new Pregunta4("Zanahoria", 0));
        fasesaux.Add(new Pregunta4("Espinacas", 0));
        fasesaux.Add(new Pregunta4("Guisantes", 0));
        fasesaux.Add(new Pregunta4("Tomate", 0));
        fasesaux.Add(new Pregunta4("Pimientos", 0));
        fasesaux.Add(new Pregunta4("Br�coli", 0));
        fasesaux.Add(new Pregunta4("Boniato", 0));
        fasesaux.Add(new Pregunta4("Remolacha", 0));
        fasesaux.Add(new Pregunta4("Coliflor", 0));





        fasesaux = DesordenarLista<Pregunta4>(fasesaux);
        fase1.Add(fasesaux[0]);
        fase1.Add(fasesaux[1]);
        fase1.Add(fasesaux[2]);
        fase1.Add(fasesaux[3]);
        fase1.Add(fasesaux[4]);
        fasesaux.Clear();



        fasesaux.Add(new Pregunta4("Fresa", 1));
        fasesaux.Add(new Pregunta4("Pi�a", 1));     
        fasesaux.Add(new Pregunta4("Manzana", 1));
        fasesaux.Add(new Pregunta4("Mel�n", 1));
        fasesaux.Add(new Pregunta4("Pl�tano", 1));
        fasesaux.Add(new Pregunta4("Sand�a", 1));
        fasesaux.Add(new Pregunta4("Pera", 1));
        fasesaux.Add(new Pregunta4("Kiwi", 1));
        fasesaux.Add(new Pregunta4("Uvas", 1));
        fasesaux.Add(new Pregunta4("Melocot�n", 1));





        fasesaux = DesordenarLista<Pregunta4>(fasesaux);
        fase1.Add(fasesaux[0]);
        fase1.Add(fasesaux[1]);
        fase1.Add(fasesaux[2]);
        fase1.Add(fasesaux[3]);
        fase1.Add(fasesaux[4]);
        fasesaux.Clear();

        

        fasesaux.Add(new Pregunta4("Zumo", 2));
        fasesaux.Add(new Pregunta4("Agua", 2));
        fasesaux.Add(new Pregunta4("Refrescos", 2));
        fasesaux.Add(new Pregunta4("Gaseosa", 2));
        fasesaux.Add(new Pregunta4("Vino", 2));
        fasesaux.Add(new Pregunta4("Champ�n", 2));
        fasesaux.Add(new Pregunta4("Cerveza", 2));
        fasesaux.Add(new Pregunta4("Horchata", 2));
        fasesaux.Add(new Pregunta4("Leche", 2));




        fasesaux = DesordenarLista<Pregunta4>(fasesaux);
        fase1.Add(fasesaux[0]);
        fase1.Add(fasesaux[1]);
        fase1.Add(fasesaux[2]);
        fase1.Add(fasesaux[3]);
        fase1.Add(fasesaux[4]);
        fasesaux.Clear();


        fases4aux.Add(new FaseP4(DesordenarLista<Pregunta4>(fase1),0,19));


        fasesaux.Add(new Pregunta4("Pez", 3));
        fasesaux.Add(new Pregunta4("Tibur�n", 3));
        fasesaux.Add(new Pregunta4("Ballena", 3));
        fasesaux.Add(new Pregunta4("Foca", 3));
        fasesaux.Add(new Pregunta4("Estrella de mar", 3));
        fasesaux.Add(new Pregunta4("Sardina", 3));
        fasesaux.Add(new Pregunta4("Orca", 3));
        fasesaux.Add(new Pregunta4("Almejas", 3));
        fasesaux.Add(new Pregunta4("Calamar", 3));
        fasesaux.Add(new Pregunta4("Cangrejo", 3));
        fasesaux.Add(new Pregunta4("Delf�n", 3));
        fasesaux.Add(new Pregunta4("Medusa", 3));






        fasesaux = DesordenarLista<Pregunta4>(fasesaux);
        fase2.Add(fasesaux[0]);
        fase2.Add(fasesaux[1]);
        fase2.Add(fasesaux[2]);
        fase2.Add(fasesaux[3]);
        fase2.Add(fasesaux[4]);
        fasesaux.Clear();

        fasesaux.Add(new Pregunta4("Perro", 4));
        fasesaux.Add(new Pregunta4("Gato", 4));
        fasesaux.Add(new Pregunta4("Vaca", 4));
        fasesaux.Add(new Pregunta4("Caballo", 4));
        fasesaux.Add(new Pregunta4("Oso", 4));
        fasesaux.Add(new Pregunta4("Rat�n", 4));
        fasesaux.Add(new Pregunta4("Burro", 4));
        fasesaux.Add(new Pregunta4("Cebra", 4));
        fasesaux.Add(new Pregunta4("Tigre", 4));
        fasesaux.Add(new Pregunta4("Le�n", 4));
        fasesaux.Add(new Pregunta4("Girafa", 4));





        fasesaux = DesordenarLista<Pregunta4>(fasesaux);
        fase2.Add(fasesaux[0]);
        fase2.Add(fasesaux[1]);
        fase2.Add(fasesaux[2]);
        fase2.Add(fasesaux[3]);
        fase2.Add(fasesaux[4]);
        fasesaux.Clear();


        fasesaux.Add(new Pregunta4("Loro", 5));
        fasesaux.Add(new Pregunta4("Gaviota", 5));
        fasesaux.Add(new Pregunta4("�guila", 5));
        fasesaux.Add(new Pregunta4("Buitre", 5));
        fasesaux.Add(new Pregunta4("Paloma", 5));
        fasesaux.Add(new Pregunta4("Canario", 5));
        fasesaux.Add(new Pregunta4("Cisne", 5));
        fasesaux.Add(new Pregunta4("Patos", 5));
        fasesaux.Add(new Pregunta4("Avestruz", 5));
        fasesaux.Add(new Pregunta4("B�ho", 5));
        fasesaux.Add(new Pregunta4("Ping�inos", 5));
        fasesaux.Add(new Pregunta4("Cuervos", 5));



        fasesaux = DesordenarLista<Pregunta4>(fasesaux);
        fase2.Add(fasesaux[0]);
        fase2.Add(fasesaux[1]);
        fase2.Add(fasesaux[2]);
        fase2.Add(fasesaux[3]);
        fase2.Add(fasesaux[4]);
        fasesaux.Clear();


        fases4aux.Add(new FaseP4(DesordenarLista<Pregunta4>(fase2),1,21));
        fases4aux = DesordenarLista<FaseP4>(fases4aux);
        fases4.Add(fases4aux[0]);


        sonidos.GetComponent<Sonidos>().repAudio(1, 39);
        textoPrincipal.GetComponent<Text>().text = "Coloca las palabras en el grupo correcto";
        panel4.SetActive(true);
        siguientepreguntaN4();

    }

    void siguientepreguntaN4()
    {
        if (contador < fases4.Count)
        {
            if (fases4[contador].contadorFase < fases4[contador].preguntas.Count)
            {
                if (fases4[contador].id == 0)
                {
                    panel4.transform.GetChild(0).GetComponent<Text>().text = "Verduras";
                    panel4.transform.GetChild(1).GetComponent<Text>().text = "Frutas";
                    panel4.transform.GetChild(2).GetComponent<Text>().text = "Bebidas";
                }
                else
                {
                    panel4.transform.GetChild(0).GetComponent<Text>().text = "Animales acu�ticos";
                    panel4.transform.GetChild(1).GetComponent<Text>().text = "Animales terrestres";
                    panel4.transform.GetChild(2).GetComponent<Text>().text = "Aves";
                }

                for (int i = 0; i < 5; i++)
                {
                    if (fases4[contador].contadorFase < fases4[contador].preguntas.Count)
                    {
                        GameObject g;
                        g = Instantiate(palabra, hand.transform);
                        g.SetActive(true);
                        g.transform.GetChild(0).GetComponent<Text>().text = fases4[contador].preguntas[fases4[contador].contadorFase].nombre;
                        g.GetComponent<Drag2>().id = fases4[contador].preguntas[fases4[contador].contadorFase].categoria;
                        fases4[contador].contadorFase++;

                    }

                }
            }
            else
            {
                botonCorregir.SetActive(true);
            }
        }
        else
        {
            final("Ejercicio de Lenguaje nivel 4 completado", 15, 6, 4,true);

        }
    }

    public void comprobarNumRespuesta()
    {

        if (hand.transform.childCount == 1)
        {
            siguientepreguntaN4();
        }
    }
    public void corregirN4()
    {
        block.SetActive(true);
        botonCorregir.SetActive(false);
        botonSiguiente.SetActive(true);
        if (fases4[contador].id == 0)
        {
            for (int i = 0; i < categoria1.transform.childCount; i++)
            {
                if (categoria1.transform.GetChild(i).GetComponent<Drag2>().id == 0)
                {
                    puntos++;
                    categoria1.transform.GetChild(i).GetComponent<Image>().color = Color.green;
                }
                else
                {
                    categoria1.transform.GetChild(i).GetComponent<Image>().color = Color.red;
                }
            }

            for (int i = 0; i < categoria2.transform.childCount; i++)
            {
                if (categoria2.transform.GetChild(i).GetComponent<Drag2>().id == 1)
                {
                    puntos++;
                    categoria2.transform.GetChild(i).GetComponent<Image>().color = Color.green;
                }
                else
                {
                    categoria2.transform.GetChild(i).GetComponent<Image>().color = Color.red;
                }
            }

            for (int i = 0; i < categoria3.transform.childCount; i++)
            {
                if (categoria3.transform.GetChild(i).GetComponent<Drag2>().id == 2)
                {
                    puntos++;
                    categoria3.transform.GetChild(i).GetComponent<Image>().color = Color.green;
                }
                else
                {
                    categoria3.transform.GetChild(i).GetComponent<Image>().color = Color.red;
                }
            }
        }
        else
        {
            for (int i = 0; i < categoria1.transform.childCount; i++)
            {
                if (categoria1.transform.GetChild(i).GetComponent<Drag2>().id == 3)
                {
                    puntos++;
                    categoria1.transform.GetChild(i).GetComponent<Image>().color = Color.green;
                }
                else
                {
                    categoria1.transform.GetChild(i).GetComponent<Image>().color = Color.red;
                }
            }

            for (int i = 0; i < categoria2.transform.childCount; i++)
            {
                if (categoria2.transform.GetChild(i).GetComponent<Drag2>().id == 4)
                {
                    puntos++;
                    categoria2.transform.GetChild(i).GetComponent<Image>().color = Color.green;
                }
                else
                {
                    categoria2.transform.GetChild(i).GetComponent<Image>().color = Color.red;
                }
            }

            for (int i = 0; i < categoria3.transform.childCount; i++)
            {
                if (categoria3.transform.GetChild(i).GetComponent<Drag2>().id == 5)
                {
                    puntos++;
                    categoria3.transform.GetChild(i).GetComponent<Image>().color = Color.green;
                }
                else
                {
                    categoria3.transform.GetChild(i).GetComponent<Image>().color = Color.red;
                }
            }
        }



    }
    public void continuarN4()
    {
        while (categoria1.transform.childCount > 0)
        {
            DestroyImmediate(categoria1.transform.GetChild(0).gameObject);
        }
        while (categoria2.transform.childCount > 0)
        {
            DestroyImmediate(categoria2.transform.GetChild(0).gameObject);
        }
        while (categoria3.transform.childCount > 0)
        {
            DestroyImmediate(categoria3.transform.GetChild(0).gameObject);
        }

        botonSiguiente.SetActive(false);
        block.SetActive(false);
        contador++;
        siguientepreguntaN4();



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






    //////////////////////////////////////////////////////
    ///

    private void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempo > 0)
        {
            if (nivel == 1 || nivel == 2 || nivel == 3)
            {
                imagenCorreccion.SetActive(true);
            }
        }
        else
        {
            imagenCorreccion.SetActive(false);
        }

    }



}


public class Preguntas1
{
    public Preguntas1(List<Pregunta1> pr)
    {
        preguntas = new List<Pregunta1>();
        preguntas = pr;
        contador = 0;
    }
    public List<Pregunta1> preguntas;
    public int contador;
}


public class Pregunta1
{
    public Pregunta1(string p, int s, int g, int a)
    {
        imagenes = new List<Sprite>();
        solucion = s;
        pregunta = p;
        grupoImagenes = g;
        audio = a;
    }
    public List<Sprite> imagenes;
    public int solucion;
    public string pregunta;
    public int grupoImagenes;
    public int audio;
}

public class Pregunta2
{
    public Pregunta2(Sprite img, List<Sprite> lImg)
    {
        listaImagenes = new List<Sprite>();
        listaImagenes = lImg;
        imagen = img;
        contadorImagen = 0;
    }
    public List<Sprite> listaImagenes;
    public Sprite imagen;
    public int solucion;
    public int contadorImagen;
}

public class Pregunta3
{
    public Pregunta3(string pre, int re,int au)
    {
        pregunta = pre;
        respuesta = re;
        audio = au;
    }
    public string pregunta;
    public int respuesta;
    public int solucion;
    public int audio;
}

public class Pregunta4
{
    public Pregunta4(string nom, int cat)
    {
        nombre = nom;
        categoria = cat;
    }
    public int categoria;
    public string nombre;
}

public class FaseP4
{
    public FaseP4(List<Pregunta4> pr,int i,int punt)
    {
        preguntas = new List<Pregunta4>();
        preguntas = pr;
        id = i;
    }
    public List<Pregunta4> preguntas;
    public int contadorFase = 0;
    public int id;
    public int puntos;
}
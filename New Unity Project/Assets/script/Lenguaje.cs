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
    private int nivel;
    private float tiempo=0;
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
    public GameObject panel4;



    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();
      

        managerEjercicios = GameObject.FindWithTag("MEje");

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


    void nivel1()
    {
        List<Pregunta1> aux = new List<Pregunta1>();
        aux.Add(new Pregunta1("Pulsa en el color azul", 1,0));
        aux.Add(new Pregunta1("Pulsa en el color rojo", 2,0));
        aux.Add(new Pregunta1("Pulsa en el color verde", 3,0));
        aux.Add(new Pregunta1("Pulsa en el color negro", 4,0));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa en la falda", 1,1));
        aux.Add(new Pregunta1("Pulsa en el calcetín", 2, 1));
        aux.Add(new Pregunta1("Pulsa en la chaqueta", 3, 1));
        aux.Add(new Pregunta1("Pulsa en el pantalon", 4, 1));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa en el perro", 1, 2));
        aux.Add(new Pregunta1("Pulsa en el gato", 2, 2));
        aux.Add(new Pregunta1("Pulsa en el caballo", 3, 2));
        aux.Add(new Pregunta1("Pulsa en el oveja", 4, 2));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa en la zapatilla", 1, 3));
        aux.Add(new Pregunta1("Pulsa en el bota", 2, 3));
        aux.Add(new Pregunta1("Pulsa en el chancla", 3, 3));
        aux.Add(new Pregunta1("Pulsa en el deportiva", 4, 3));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa en la guitarra", 1, 4));
        aux.Add(new Pregunta1("Pulsa en el tambor", 2, 4));
        aux.Add(new Pregunta1("Pulsa en el flauta", 3, 4));
        aux.Add(new Pregunta1("Pulsa en el piano", 4, 4));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa en el tomate", 1, 5));
        aux.Add(new Pregunta1("Pulsa en el lechuga", 2, 5));
        aux.Add(new Pregunta1("Pulsa en el zanahoria", 3, 5));
        aux.Add(new Pregunta1("Pulsa en el pepino", 4, 5));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();

        aux.Add(new Pregunta1("Pulsa en el circulo", 1, 6));
        aux.Add(new Pregunta1("Pulsa en el cuadrado", 2, 6));
        aux.Add(new Pregunta1("Pulsa en el triangulo", 3, 6));
        aux.Add(new Pregunta1("Pulsa en el rectangulo", 4, 6));
        preguntas1.Add(new Preguntas1(DesordenarLista<Pregunta1>(aux)));
        aux.Clear();




       
        panel1.SetActive(true);

        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (preguntas1[contador].contador < preguntas1[contador].preguntas.Count)
        {
            if (contador < preguntas1.Count)
            {

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
    }

    void generarGrupo()
    {
        if (preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 0)
        {
            boton1.GetComponent<Image>().sprite = azul;
            boton2.GetComponent<Image>().sprite = rojo;
            boton3.GetComponent<Image>().sprite = verde;
            boton4.GetComponent<Image>().sprite = negro;
        }else if(preguntas1[contador].preguntas[preguntas1[contador].contador].grupoImagenes == 1)
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
            panel1.transform.GetChild(i-1).gameObject.SetActive(false);

        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;

        }
        preguntas1[contador].contador++;
        siguientePreguntaN1();
        tiempo = 1;
    }
 




    void nivel2()
    {
        List<Pregunta2> aux = new List<Pregunta2>();
        aux.Add(new Pregunta2(amapola,conjuntosN2(1)));
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
        textoPrincipal.GetComponent<Text>().text = "Qué imagen no corresponde con el grupo";
        panel2.SetActive(true);
        siguientePreguntaN2();



    }
    void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
            int numRand = Random.Range(0, 6);
            for (int i = 0; i < 6;i++)
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
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de lenguaje nivel 2 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 11 ";
            if (puntos == 11)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 3";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.lenguaje(3);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 2";
            }
        }
    }
    public void botonNivel2(int i)
    {
        if (i == preguntas2[contador].solucion)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;

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
        }else if (conjunto==2)
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
        aux.Add(new Pregunta3("Madrid Sevilla Barcelona Burgos Soria",0));
        aux.Add(new Pregunta3("España China Portugal Brasil Francia",1));
        aux.Add(new Pregunta3("Enero  Marzo Febrero Abril",2));
        aux.Add(new Pregunta3("Cuchillo Tenedor Cuchara Platos Cazo",3));
        aux.Add(new Pregunta3("Mesa Silla Escritorio Sillon Cama",4));
        aux.Add(new Pregunta3("Dormitorio Salon Cocina Despacho Cuarto Baño",5));
        aux.Add(new Pregunta3("Paula Ana Josefa Manuela Rosa Estefania",6));
        aux.Add(new Pregunta3("Paco José Mario Manuel Pedro",7));
        aux.Add(new Pregunta3("Tio Prima Abuela Hijo Sobrino Nieto",8));
        preguntas3 = DesordenarLista<Pregunta3>(aux);

        idYPregun.Add(0, "Ciudades");
        idYPregun.Add(1, "Paises");
        idYPregun.Add(2, "Meses");
        idYPregun.Add(3, "Utensilios de cocina");
        idYPregun.Add(4, "Muebles");
        idYPregun.Add(5, "Habitacion");
        idYPregun.Add(6, "Nombre Mujer");
        idYPregun.Add(7, "Nombre Hombre");
        idYPregun.Add(8, "Parientes");


        panel3.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "A que grupo corresponde estas palabras";
        siguientePreguntaN3();
        
    }

    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            panel3.transform.GetChild(0).GetComponent<Text>().text = preguntas3[contador].pregunta;
            generarBotonesN3();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de lenguaje nivel 3 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 9 ";
            if (puntos == 9)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 4";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.lenguaje(3);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 3";
            }
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
            for (int i = 0; i < aux.Count;i++) 
            {
                if (aux[i] == ran)
                {
                    salir = true;
                    break;
                }
            }
            if(!salir)
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
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;

        }
        contador++;
        tiempo = 1;
        siguientePreguntaN3();
    }


    void nivel4()
    {

    }



    public void irInicio()
    {
        SceneManager.LoadScene(0);
    }






    //////////////////////////////////////////////////////
    ///

    private void Update()
    {
        tiempo -= Time.deltaTime;
        if (tiempo > 0)
        {
            if (nivel == 1 || nivel==2 || nivel==3)
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

public class Pregunta2
{
    public Pregunta2(Sprite img,List<Sprite> lImg)
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
    public Pregunta3(string pre, int re)
    {
        pregunta = pre;
        respuesta = re;       
    }
    public string pregunta;     
    public int respuesta;
    public int solucion;
}
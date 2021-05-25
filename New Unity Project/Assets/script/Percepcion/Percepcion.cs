using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Percepcion : MonoBehaviour
{
    GameObject sonidos;
    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;
    private int nivel;
    private float tiempo = 0;
    private int numRespuestas = 0;
    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

    //grupo0
    public Sprite circulo;
    public Sprite cuadrado;
    public Sprite rombo;
    public Sprite rectangulo;
    public Sprite triangulo;
    //grupo1
    public Sprite caballo;
    public Sprite gato;
    public Sprite perro;
    public Sprite conejo;
    public Sprite oveja;

    //grupo0N2 0
    public Sprite perro1;
    public Sprite perro2;
    public Sprite perro3;
    public Sprite perro4;
    public Sprite perro5;
    public Sprite perro6;
    public Sprite perro7;
    public Sprite perro8;
    public Sprite perro9;
    public Sprite perro10;
    public Sprite perro11;


    //grupo1N2 1
    public Sprite nino1;
    public Sprite nino2;
    public Sprite nino3;
    public Sprite nino4;
    public Sprite nino5;
    public Sprite nino6;
    public Sprite nino7;
    public Sprite nino8;
    public Sprite nino9;
    public Sprite nino10;
    public Sprite nino11;
    public Sprite nino12;

    //grupo1N3 2
    public Sprite arbol1;
    public Sprite arbol2;
    public Sprite arbol3;
    public Sprite arbol4;
    public Sprite arbol5;
    public Sprite arbol6;


    //grupo2N3 3
    public Sprite astr1;
    public Sprite astr2;
    public Sprite astr3;
    public Sprite astr4;
    public Sprite astr5;
 



    //grupo3N3 4
    public Sprite copo1;
    public Sprite copo2;
    public Sprite copo3;
    public Sprite copo4;
    public Sprite copo5;
    public Sprite copo6;
    public Sprite copo7;
    public Sprite copo8;

    //grupo4N3 5
    public Sprite figura1;
    public Sprite figura2;
    public Sprite figura3;
    public Sprite figura4;
    public Sprite figura5;
    public Sprite figura6;
    public Sprite figura7;
   


    //grupo5N3 6
    public Sprite llave1;
    public Sprite llave2;
    public Sprite llave3;
    public Sprite llave4;
    public Sprite llave5;
    public Sprite llave6;
    public Sprite llave7;

    //grupo1N4


    public Sprite spor1;
    public Sprite spor2;
    public Sprite spor3;
    public Sprite spor4;
    public Sprite spor5;
    public Sprite spor6;
    public Sprite spor7;
    public Sprite spor8;



    //nivel1
    List<Pregunta1P> preguntas1;
    public GameObject panel1;
    int numrespuestas = 0;



    //nivel2
    List<Pregunta2P> preguntas2 = new List<Pregunta2P>();
    public GameObject panel2;
    Dictionary<int, Sprite> grupo1N2=new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo2N2= new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo1N3 = new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo2N3 = new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo3N3 = new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo4N3 = new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo5N3 = new Dictionary<int, Sprite>();




    //nivel4
    public GameObject panel4;
    public GameObject ImagenSleccionada;
    List<Pregunta42p> preguntas4;
    public int respu1;
    public int respu2;







    void Start()
    {
        

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
        textoPrincipal.GetComponent<Text>().text = "Finalizado los ejercicios de Percepción nivel " + (siguienteNnivel - 1).ToString();
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos máximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(siguienteNnivel);
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
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }



        }
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }
    void nivel1()
    {
        preguntas1 = new List<Pregunta1P>();
        List<Pregunta1P> aux = new List<Pregunta1P>();

        aux.Add(new Pregunta1P(oveja,0));
        aux.Add(new Pregunta1P(perro, 0));
        aux.Add(new Pregunta1P(caballo, 0));
        aux.Add(new Pregunta1P(conejo, 0));
        aux.Add(new Pregunta1P(gato, 0));

        aux = DesordenarLista<Pregunta1P>(aux);
        preguntas1.Add(aux[0]);
        preguntas1.Add(aux[1]);
        preguntas1.Add(aux[2]);
        aux.Clear();

        aux.Add(new Pregunta1P(circulo, 1));
        aux.Add(new Pregunta1P(cuadrado, 1));
        aux.Add(new Pregunta1P(rombo, 1));
        aux.Add(new Pregunta1P(rectangulo, 1));
        aux.Add(new Pregunta1P(triangulo, 1));

        aux = DesordenarLista<Pregunta1P>(aux);
        preguntas1.Add(aux[0]);
        preguntas1.Add(aux[1]);
        preguntas1.Add(aux[2]);

        preguntas1 = DesordenarLista<Pregunta1P>(preguntas1);




        panel1.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imágenes que son iguales al ejemplo";
        siguientePreguntaN1();
    }

    void siguientePreguntaN1()
    {
        List<Sprite> aux = new List<Sprite>();
        if (contador < preguntas1.Count)
        {
            panel1.transform.GetChild(0).GetComponent<Image>().sprite = preguntas1[contador].imagen;
            aux = gruposN1(preguntas1[contador].grupo);
            generarBotonesN1(aux);
        }
        else
        {
            final("Ejercicio Percepción nivel 1 completado", 24, 0, 2,false);

        }
    }
    List<Sprite> gruposN1(int grupo)
    {
        List<Sprite> aux = new List<Sprite>();
        if (grupo == 0)
        {
            aux.Add(circulo);
            aux.Add(cuadrado);
            aux.Add(rombo);
            aux.Add(rectangulo);
            aux.Add(triangulo);  
        }
        else if (grupo==1)
        {
            aux.Add(caballo);
            aux.Add(gato);
            aux.Add(perro);
            aux.Add(conejo);
            aux.Add(oveja);
        }

        return aux;
    }
    void generarBotonesN1(List<Sprite> img)
    {
        List<InfoBoton> aux = new List<InfoBoton>();
        aux.Add(new InfoBoton(preguntas1[contador].imagen,true));
        aux.Add(new InfoBoton(preguntas1[contador].imagen,true));
        aux.Add(new InfoBoton(preguntas1[contador].imagen,true));
        aux.Add(new InfoBoton(preguntas1[contador].imagen,true));

        for (int i = 0; i < 4; i++)
        {
            int ran = Random.Range(0, img.Count);
            aux.Add(new InfoBoton(img[ran],false));
        }

        List<InfoBoton> botones = new List<InfoBoton>();
        botones = DesordenarLista<InfoBoton>(aux);
        for(int i = 0; i < 8; i++)
        {
            panel1.transform.GetChild(i + 1).gameObject.SetActive(true);
            panel1.transform.GetChild(i+1).GetComponent<Image>().sprite = botones[i].imagen;
            if (botones[i].correcto)
            {                
                panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = true;
            }
            else
            {
                panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = false;
            }
            panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().id = i;

        }
    }
    public void eventoPulsado(bool respuesta, int id)
    {
        GameObject panel;
        panel = panel2;

        if (nivel == 1)
        {
            panel = panel1;
        }else if (nivel==2 || nivel==3)
        {
            panel = panel2;
        }

        if (respuesta)
        {
            panel.transform.GetChild(id + 1).gameObject.SetActive(false);
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
        numRespuestas++;

        int numRespuestasNivel = 0;
        if (nivel == 1)
        {
            numRespuestasNivel = 4;
        }else if (nivel==2)
        {
            numRespuestasNivel = 2;

        }
        else if (nivel == 3)
        {
            numRespuestasNivel = 1;

        }
        if (numRespuestas == numRespuestasNivel)
        {
            numRespuestas = 0;
            contador++;
            if (nivel == 1)
            {
                siguientePreguntaN1();
            }
            else if(nivel==2 || nivel==3)
            {
                siguientePreguntaN2();
            }

        }
    }

    void nivel2()
    {
        grupo1N2.Add(0, perro1);
        grupo1N2.Add(1, perro2);
        grupo1N2.Add(2, perro3);
        grupo1N2.Add(3, perro4);
        grupo1N2.Add(4, perro5);
        grupo1N2.Add(5, perro6);
        grupo1N2.Add(6, perro7);
        grupo1N2.Add(7, perro8);
        grupo1N2.Add(8, perro9);
        grupo1N2.Add(9, perro10);
        grupo1N2.Add(10, perro11);

        grupo2N2.Add(0, nino1);
        grupo2N2.Add(1, nino2);
        grupo2N2.Add(2, nino3);
        grupo2N2.Add(3, nino4);
        grupo2N2.Add(4, nino5);
        grupo2N2.Add(5, nino6);
        grupo2N2.Add(6, nino7);
        grupo2N2.Add(7, nino8);
        grupo2N2.Add(8, nino9);
        grupo2N2.Add(9, nino10);
        grupo2N2.Add(10, nino11);
        grupo2N2.Add(11, nino12);
       

        List<Pregunta2P> aux = new List<Pregunta2P>();
        int rand = 0;
      
        rand = Random.Range(0, 2);
        if (rand == 0)
        {
            preguntas2.Add(new Pregunta2P(0, 0));
            preguntas2.Add(new Pregunta2P(1, 0));
            preguntas2.Add(new Pregunta2P(2, 0));
            preguntas2.Add(new Pregunta2P(3, 0));
            preguntas2.Add(new Pregunta2P(4, 0));
            preguntas2.Add(new Pregunta2P(5, 0));
            preguntas2.Add(new Pregunta2P(6, 0));
            preguntas2.Add(new Pregunta2P(7, 0));
            preguntas2.Add(new Pregunta2P(8, 0));
            preguntas2.Add(new Pregunta2P(9, 0));
            preguntas2.Add(new Pregunta2P(10, 0));
        }
        else
        {
            preguntas2.Add(new Pregunta2P(0, 1));
            preguntas2.Add(new Pregunta2P(1, 1));
            preguntas2.Add(new Pregunta2P(2, 1));
            preguntas2.Add(new Pregunta2P(3, 1));
            preguntas2.Add(new Pregunta2P(4, 1));
            preguntas2.Add(new Pregunta2P(5, 1));
            preguntas2.Add(new Pregunta2P(6, 1));
            preguntas2.Add(new Pregunta2P(7, 1));
            preguntas2.Add(new Pregunta2P(8, 1));
            preguntas2.Add(new Pregunta2P(9, 1));
            preguntas2.Add(new Pregunta2P(10, 1));
        }

        preguntas2 = DesordenarLista<Pregunta2P>(preguntas2);
        
        




        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imágenes que son iguales al ejemplo";

        siguientePreguntaN2();

    }

    void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
           
            panel2.transform.GetChild(0).GetComponent<Image>().sprite = cogerImagenGrupoN2();    
            generarBotonesN2();
            
        }
        else
        {
            if (preguntas2[contador - 1].grupo < 2)
            {
                final("Ejercicio Percepción nivel 2 completado", 22, 10, 3,false);

            }
            else
            {
                final("Ejercicio Percepción nivel 3 completado", 15, 6, 4,false);

            }
            sonidos.GetComponent<Sonidos>().repSonido(4);
        }

    }
  

    void generarBotonesN2()
    {
        List<InfoBoton> aux = new List<InfoBoton>();
        List<InfoBoton> botonesRand = new List<InfoBoton>();

        if (preguntas2[contador].grupo < 2){
            aux.Add(new InfoBoton(cogerImagenGrupoN2(), true));
            aux.Add(new InfoBoton(cogerImagenGrupoN2(), true));
        }
        else
        {
            aux.Add(new InfoBoton(cogerImagenGrupoN2(), true));
        }

        

        Dictionary<int, Sprite> aux2 = new Dictionary<int, Sprite>();

        if (preguntas2[contador].grupo == 0)
        {
            aux2 = grupo1N2;
        }
        else if(preguntas2[contador].grupo == 1)
        {
            aux2 = grupo2N2;
        }
        else if (preguntas2[contador].grupo == 2)
        {
            aux2 = grupo1N3;
        }
        else if (preguntas2[contador].grupo == 3)
        {
            aux2 = grupo2N3;
        }
        else if (preguntas2[contador].grupo == 4)
        {
            aux2 = grupo3N3;
        }
        else if (preguntas2[contador].grupo == 5)
        {
            aux2 = grupo4N3;
        }
        else if (preguntas2[contador].grupo == 6)
        {
            aux2 = grupo5N3;
        }

        int maximo = 0;
        if(preguntas2[contador].grupo < 2)
        {
            maximo = 6;
        }
        else
        {
            maximo = 7;
        }

        for (int i = 0; i < maximo; i++)
        {
            int rand = Random.Range(0, aux2.Count);
            if (rand != preguntas2[contador].id)
            {
                aux.Add(new InfoBoton(aux2[rand],false));
            }
            else
            {
                i--;
            }
           
           
          
        }
        botonesRand = DesordenarLista<InfoBoton>(aux);


        for (int i = 0; i < 8; i++)
        {
            panel2.transform.GetChild(i + 1).gameObject.SetActive(true);
            panel2.transform.GetChild(i + 1).GetComponent<Image>().sprite = botonesRand[i].imagen;
            if (botonesRand[i].correcto)
            {
                panel2.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = true;
            }
            else
            {
                panel2.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = false;
            }
            panel2.transform.GetChild(i + 1).GetComponent<IdSeleccion>().id = i;

        }

    }

    Sprite cogerImagenGrupoN2()
    {
        Sprite aux;
       

        if (preguntas2[contador].grupo == 0)
        {
            aux = grupo1N2[preguntas2[contador].id];
        }
        else if (preguntas2[contador].grupo == 1)
        {
            aux = grupo2N2[preguntas2[contador].id];
        }
        else if (preguntas2[contador].grupo == 2)
        {
            aux = grupo1N3[preguntas2[contador].id];
        }
        else if (preguntas2[contador].grupo == 3)
        {
            aux = grupo2N3[preguntas2[contador].id];
        }
        else if (preguntas2[contador].grupo == 4)
        {
            aux = grupo3N3[preguntas2[contador].id];
        }
        else if (preguntas2[contador].grupo == 5)
        {
            aux = grupo4N3[preguntas2[contador].id];
        }
        else 
        {
            aux = grupo5N3[preguntas2[contador].id];
        }


        return aux;
    }



    void nivel3()
    {
        grupo1N3.Add(0, arbol1);
        grupo1N3.Add(1, arbol2);
        grupo1N3.Add(2, arbol3);
        grupo1N3.Add(3, arbol4);
        grupo1N3.Add(4, arbol5);
        grupo1N3.Add(5, arbol6);


        grupo2N3.Add(0, astr1);
        grupo2N3.Add(1, astr2);
        grupo2N3.Add(2, astr3);
        grupo2N3.Add(3, astr4);
        grupo2N3.Add(4, astr5);

        grupo3N3.Add(0, copo1);
        grupo3N3.Add(1, copo2);
        grupo3N3.Add(2, copo3);
        grupo3N3.Add(3, copo4);
        grupo3N3.Add(4, copo5);
        grupo3N3.Add(5, copo6);
        grupo3N3.Add(6, copo7);
        grupo3N3.Add(7, copo8);

        grupo4N3.Add(0, figura1);
        grupo4N3.Add(1, figura2);
        grupo4N3.Add(2, figura3);
        grupo4N3.Add(3, figura4);
        grupo4N3.Add(4, figura5);
        grupo4N3.Add(5, figura6);
        grupo4N3.Add(6, figura7);

        grupo5N3.Add(0, llave1);
        grupo5N3.Add(1, llave2);
        grupo5N3.Add(2, llave3);
        grupo5N3.Add(3, llave4);
        grupo5N3.Add(4, llave5);
        grupo5N3.Add(5, llave6);
        grupo5N3.Add(6, llave7);


        List<GrupoPreguntas<Pregunta2P>> aux;
        aux = new List<GrupoPreguntas<Pregunta2P>>();

        preguntas2.Add(new Pregunta2P(0, 2));
        preguntas2.Add(new Pregunta2P(1, 2));
        preguntas2.Add(new Pregunta2P(2, 2));
        preguntas2.Add(new Pregunta2P(3, 2));
        preguntas2.Add(new Pregunta2P(4, 2));
        aux.Add(new GrupoPreguntas<Pregunta2P>(DesordenarLista<Pregunta2P>(preguntas2)));
       

        preguntas2.Clear();
        preguntas2.Add(new Pregunta2P(0, 3));
        preguntas2.Add(new Pregunta2P(1, 3));
        preguntas2.Add(new Pregunta2P(2, 3));
        preguntas2.Add(new Pregunta2P(3, 3));
        preguntas2.Add(new Pregunta2P(4, 3));
        aux.Add(new GrupoPreguntas<Pregunta2P>(DesordenarLista<Pregunta2P>(preguntas2)));





        preguntas2.Clear();
        preguntas2.Add(new Pregunta2P(0, 4));
        preguntas2.Add(new Pregunta2P(1, 4));
        preguntas2.Add(new Pregunta2P(2, 4));
        preguntas2.Add(new Pregunta2P(3, 4));
        preguntas2.Add(new Pregunta2P(4, 4));
        
        aux.Add(new GrupoPreguntas<Pregunta2P>(DesordenarLista<Pregunta2P>(preguntas2)));

        preguntas2.Clear();
        preguntas2.Add(new Pregunta2P(0, 5));
        preguntas2.Add(new Pregunta2P(1, 5));
        preguntas2.Add(new Pregunta2P(2, 5));
        preguntas2.Add(new Pregunta2P(3, 5));
        preguntas2.Add(new Pregunta2P(4, 5));
        aux.Add(new GrupoPreguntas<Pregunta2P>(DesordenarLista<Pregunta2P>(preguntas2)));

        preguntas2.Clear();
        preguntas2.Add(new Pregunta2P(0, 6));
        preguntas2.Add(new Pregunta2P(1, 6));
        preguntas2.Add(new Pregunta2P(2, 6));
        preguntas2.Add(new Pregunta2P(3, 6));
        preguntas2.Add(new Pregunta2P(4, 6));
        aux.Add(new GrupoPreguntas<Pregunta2P>(DesordenarLista<Pregunta2P>(preguntas2)));


        preguntas2.Clear();
        aux = DesordenarLista<GrupoPreguntas<Pregunta2P>>(aux);
        preguntas2.AddRange(aux[0].lista);
        preguntas2.AddRange(aux[1].lista);
        preguntas2.AddRange(aux[2].lista);

        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imágenes que son iguales al ejemplo";

        siguientePreguntaN2();

    }



    void nivel4()
    {

        List<Pregunta42p> aux = new List<Pregunta42p>();
        preguntas4 = new List<Pregunta42p>();
        aux.Add(new Pregunta42p(spor1, spor2, 10, 1));
        aux.Add(new Pregunta42p(spor1, spor3, 13, 13));
        aux.Add(new Pregunta42p(spor1, spor4, 7, 11));
        aux.Add(new Pregunta42p(spor1, spor5, 15, 7));
        aux.Add(new Pregunta42p(spor1, spor6, 3, 11));
        aux.Add(new Pregunta42p(spor1, spor7, 9, 4));
        aux.Add(new Pregunta42p(spor1, spor8, 1, 10));
        aux.Add(new Pregunta42p(spor2, spor3, 3, 8));
        aux.Add(new Pregunta42p(spor2, spor4, 4, 4));
        aux.Add(new Pregunta42p(spor2, spor5, 8, 9));
        aux.Add(new Pregunta42p(spor2, spor6, 9, 6));
        aux.Add(new Pregunta42p(spor2, spor7, 10, 10));
        aux.Add(new Pregunta42p(spor2, spor8, 11, 7));
        aux.Add(new Pregunta42p(spor3, spor4, 11, 12));
        aux.Add(new Pregunta42p(spor3, spor5, 7, 8));
        aux.Add(new Pregunta42p(spor3, spor6, 10, 12));
        aux.Add(new Pregunta42p(spor3, spor7, 5, 11));
        aux.Add(new Pregunta42p(spor3, spor8, 4, 5));
        

        aux = DesordenarLista<Pregunta42p>(aux);
        preguntas4.Add(aux[0]);
        preguntas4.Add(aux[1]);
        preguntas4.Add(aux[2]);
        preguntas4.Add(aux[3]);


        panel4.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona el dibujo que es igual en ambos lados (color y forma)";
        siguientepreguntaN4();

    }
    void siguientepreguntaN4()
    {
        if (contador < preguntas4.Count)
        {
            panel4.transform.GetChild(0).GetComponent<Image>().sprite = preguntas4[contador].imagen1;
            panel4.transform.GetChild(1).GetComponent<Image>().sprite = preguntas4[contador].imagen2;
            respu1 = preguntas4[contador].solucion1;
            respu2 = preguntas4[contador].solucion2;

        }
        else
        {
            final("Ejercicio Percepción nivel 4 completado", 4, 2, 4,true);

        }
    }
    public void eventoSeleccionNivel4(int id, bool izquierda)
    {
        
        if (izquierda == true)
        {
          

            if (preguntas4[contador].solucion1 == id)
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
        }
        else
        {
          

            if (preguntas4[contador].solucion2 == id)
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
        }

        
        tiempo = 1;       
        
        contador++;
        siguientepreguntaN4();
        

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


 class Pregunta1P
{
    public Pregunta1P(Sprite img,int gru)
    {

       imagen = img;
       grupo = gru;
    }
    public Sprite imagen;
    public int solucion;   
    public int grupo;
}

 class InfoBoton
{
    public InfoBoton(Sprite img, bool cor)
    {
        imagen = img;
        correcto = cor;
    }
    public Sprite imagen;
    public bool correcto ;
}

 class Pregunta2P{
    public Pregunta2P(int i,int gru)
    {
        id = i;
        grupo = gru;
    }
    public int id;
    public int grupo;
}

 class Pregunta42p
{
    public Pregunta42p(Sprite im1,Sprite im2, int id1, int id2)
    {
        imagen1 = im1;
        imagen2 = im2;
        solucion1 = id1;
        solucion2 = id2;
    }
    public Sprite imagen1;
    public Sprite imagen2;
    public int solucion1;
    public int solucion2;
}

public class GrupoPreguntas <T>
{
    public GrupoPreguntas(List <T> lis)
    {
        lista = new List<T>();
        lista = lis;
    }

    public List<T> lista;
}
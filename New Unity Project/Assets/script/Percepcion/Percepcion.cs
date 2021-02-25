using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Percepcion : MonoBehaviour
{
    private GameObject managerEjercicios;
    private int contador = 0;
    private int puntos = 0;
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
    public Sprite spor9;
    public Sprite spor10;
    public Sprite spor11;
    public Sprite spor12;
    public Sprite spor13;
    public Sprite spor14;
    public Sprite spor15;
    public Sprite spor16;
    public Sprite spor17;
    public Sprite spor18;
    public Sprite spor19;
    public Sprite spor20;
    public Sprite spor21;
    public Sprite spor22;
    public Sprite spor23;
    public Sprite spor24;
    public Sprite spor25;
    public Sprite spor26;
    public Sprite spor27;
    public Sprite spor28;
    public Sprite spor29;
    public Sprite spor30;
    public Sprite spor31;
    public Sprite spor32;
    public Sprite spor33;
    public Sprite spor34;
    public Sprite spor35;
    public Sprite spor36;
    public Sprite spor37;
    public Sprite spor38;
    public Sprite spor39;
    public Sprite spor40;
    public Sprite nada;





    //nivel1
    List<Pregunta1P> preguntas1 = new List<Pregunta1P>();
    public GameObject panel1;



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
    Dictionary<int, Sprite> grupo1N4 = new Dictionary<int, Sprite>();
    int idUltimo = 0;
    Dictionary<int, bool> soluciones = new Dictionary<int, bool>();



    void Start()
    {
        

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
        preguntas1.Add(new Pregunta1P(oveja,0));
        preguntas1.Add(new Pregunta1P(perro, 0));
        preguntas1.Add(new Pregunta1P(caballo, 0));
        preguntas1.Add(new Pregunta1P(conejo, 0));
        preguntas1.Add(new Pregunta1P(gato, 0));

        preguntas1.Add(new Pregunta1P(circulo, 1));
        preguntas1.Add(new Pregunta1P(cuadrado, 1));
        preguntas1.Add(new Pregunta1P(rombo, 1));
        preguntas1.Add(new Pregunta1P(rectangulo, 1));
        preguntas1.Add(new Pregunta1P(triangulo, 1));





        panel1.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imagenes que son iguales";
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
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de percepcion nivel 1 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 40 ";
            if (puntos == 40)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 2";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(2);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 1";
            }
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
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;

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
        




        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imagenes que son iguales";

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
                panelFin.SetActive(true);
                textoPrincipal.GetComponent<Text>().text = "Ejercicio de percepcion nivel 2 completado";
                panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 44 ";
                if (puntos == 44)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 3";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(3);
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
                textoPrincipal.GetComponent<Text>().text = "Ejercicio de percepcion nivel 3 completado";
                panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
                panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 33 ";
                if (puntos == 33)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 4";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(4);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 3";
                }
            }
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

        List<Pregunta2P> aux = new List<Pregunta2P>();
        preguntas2.Add(new Pregunta2P(0, 2));
        preguntas2.Add(new Pregunta2P(1, 2));
        preguntas2.Add(new Pregunta2P(2, 2));
        preguntas2.Add(new Pregunta2P(3, 2));
        preguntas2.Add(new Pregunta2P(4, 2));
        preguntas2.Add(new Pregunta2P(5, 2));    


        preguntas2.Add(new Pregunta2P(0, 3));
        preguntas2.Add(new Pregunta2P(1, 3));
        preguntas2.Add(new Pregunta2P(2, 3));
        preguntas2.Add(new Pregunta2P(3, 3));
        preguntas2.Add(new Pregunta2P(4, 3));
       
      

        preguntas2.Add(new Pregunta2P(0, 4));
        preguntas2.Add(new Pregunta2P(1, 4));
        preguntas2.Add(new Pregunta2P(2, 4));
        preguntas2.Add(new Pregunta2P(3, 4));
        preguntas2.Add(new Pregunta2P(4, 4));
        preguntas2.Add(new Pregunta2P(5, 4));
        preguntas2.Add(new Pregunta2P(6, 4));
        preguntas2.Add(new Pregunta2P(7, 4));


        preguntas2.Add(new Pregunta2P(0, 5));
        preguntas2.Add(new Pregunta2P(1, 5));
        preguntas2.Add(new Pregunta2P(2, 5));
        preguntas2.Add(new Pregunta2P(3, 5));
        preguntas2.Add(new Pregunta2P(4, 5));
        preguntas2.Add(new Pregunta2P(5, 5));
        preguntas2.Add(new Pregunta2P(6, 5));


        preguntas2.Add(new Pregunta2P(0, 6));
        preguntas2.Add(new Pregunta2P(1, 6));
        preguntas2.Add(new Pregunta2P(2, 6));
        preguntas2.Add(new Pregunta2P(3, 6));
        preguntas2.Add(new Pregunta2P(4, 6));
        preguntas2.Add(new Pregunta2P(5, 6));
        preguntas2.Add(new Pregunta2P(6, 6));




        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imagenes que son iguales";

        siguientePreguntaN2();

    }



    void nivel4()
    {
        grupo1N4.Add(1, spor1);
        grupo1N4.Add(2, spor2);
        grupo1N4.Add(3, spor3);
        grupo1N4.Add(4, spor4);
        grupo1N4.Add(5, spor5);
        grupo1N4.Add(6, spor6);
        grupo1N4.Add(7, spor7);
        grupo1N4.Add(8, spor8);
        grupo1N4.Add(9, spor9);
        grupo1N4.Add(10, spor10);
        grupo1N4.Add(11, spor11);
        grupo1N4.Add(12, spor12);
        grupo1N4.Add(13, spor13);
        grupo1N4.Add(14, spor14);
        grupo1N4.Add(15, spor15);
        grupo1N4.Add(16, spor16);
        grupo1N4.Add(17, spor17);
        grupo1N4.Add(18, spor18);
        grupo1N4.Add(19, spor19);
        grupo1N4.Add(20, spor20);
        grupo1N4.Add(21, spor21);
        grupo1N4.Add(22, spor22);
        grupo1N4.Add(23, spor23);
        grupo1N4.Add(24, spor24);
        grupo1N4.Add(25, spor25);
        grupo1N4.Add(26, spor26);
        grupo1N4.Add(27, spor27);
        grupo1N4.Add(28, spor28);
        grupo1N4.Add(29, spor29);
        grupo1N4.Add(30, spor30);
        grupo1N4.Add(31, spor31);
        grupo1N4.Add(32, spor32);
        grupo1N4.Add(33, spor33);
        grupo1N4.Add(34, spor34);
        grupo1N4.Add(35, spor35);
        grupo1N4.Add(36, spor36);
        grupo1N4.Add(37, spor37);
        grupo1N4.Add(38, spor38);
        grupo1N4.Add(39, spor39);
        grupo1N4.Add(40, spor40);

        soluciones.Add(1, false);
        soluciones.Add(2, false);
        soluciones.Add(3, false);
        soluciones.Add(4, false);
        soluciones.Add(5, false);
        soluciones.Add(6, false);
        soluciones.Add(7, false);
        soluciones.Add(8, false);
        soluciones.Add(9, false);
        soluciones.Add(10, false);
        soluciones.Add(11, false);
        soluciones.Add(12, false);
        soluciones.Add(13, false);
        soluciones.Add(14, false);
        soluciones.Add(15, false);
        soluciones.Add(16, false);
        soluciones.Add(17, false);
        soluciones.Add(18, false);
        soluciones.Add(19, false);
        soluciones.Add(21, false);
        soluciones.Add(22, false);
        soluciones.Add(23, false);
        soluciones.Add(24, false);
        soluciones.Add(25, false);
        soluciones.Add(26, false);
        soluciones.Add(27, false);
        soluciones.Add(28, false);
        soluciones.Add(29, false);
        soluciones.Add(31, false);
        soluciones.Add(32, false);
        soluciones.Add(33, false);
        soluciones.Add(34, false);
        soluciones.Add(35, false);
        soluciones.Add(36, false);
        soluciones.Add(37, false);
        soluciones.Add(38, false);
        soluciones.Add(39, false);
        soluciones.Add(40, false);



        panel4.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona dos imagenes iguales";

    }
    public void eventoSeleccionNivel4(int id)
    {
        ImagenSleccionada.GetComponent<Image>().sprite = grupo1N4[id];
        if (idUltimo == id && soluciones[id]==false)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            tiempo = 1;
            numRespuestas++;
            ImagenSleccionada.GetComponent<Image>().sprite = nada;
            soluciones[id] = true;
            id = 0;            
        }
        idUltimo = id;

        if (numRespuestas > 10)
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de percepcion nivel 4 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 11 ";
            if (puntos == 11)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Todos los niveles ce percepcion completados";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.percepcion(5);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 4";
            }
        }
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


public class Pregunta1P
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

public class InfoBoton
{
    public InfoBoton(Sprite img, bool cor)
    {
        imagen = img;
        correcto = cor;
    }
    public Sprite imagen;
    public bool correcto ;
}

public class Pregunta2P{
    public Pregunta2P(int i,int gru)
    {
        id = i;
        grupo = gru;
    }
    public int id;
    public int grupo;
}
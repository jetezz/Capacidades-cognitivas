using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Atencion : MonoBehaviour
{
    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;
   
    private float tiempo = 0;
    private int numRespuestas = 0;

    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

    //Nivel1
    List<Pregunta1A> preguntas1 = new List<Pregunta1A>();
    public GameObject panel1;


    //Nivel2
    public GameObject panel2;
    int numNivel2 = 0;
    int numInicioN2;
    int numMaximoN2;
    bool primera = false;
    float tiempoEjercicio = 0.0f;
    int repeticiones = 0;
    int contadorRep = 0;

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

    void nivel1()
    {
        preguntas1.Add(new Pregunta1A("1", 0));
        preguntas1.Add(new Pregunta1A("2", 0));
        preguntas1.Add(new Pregunta1A("3", 0));
        preguntas1.Add(new Pregunta1A("4", 0));
        preguntas1.Add(new Pregunta1A("5", 0));
        preguntas1.Add(new Pregunta1A("6", 0));
        preguntas1.Add(new Pregunta1A("7", 0));
        preguntas1.Add(new Pregunta1A("8", 0));
        preguntas1.Add(new Pregunta1A("9", 0));
     



        panel1.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imagenes que son iguales";
        siguientePreguntaN1();
    }

    void siguientePreguntaN1()
    {
       
        if (contador < preguntas1.Count)
        {
            panel1.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = preguntas1[contador].imagen;
            generarBotones();
            
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de atencion nivel 1 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 36 ";
            if (puntos == 36)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 2";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(2);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 1";
            }

        }
    }

    void generarBotones()
    {
        List<string> aux = new List<string>();
        aux.Add(preguntas1[contador].imagen);        
        aux.Add(preguntas1[contador].imagen);
        aux.Add(preguntas1[contador].imagen);
        aux.Add(preguntas1[contador].imagen);

        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(0, 10);
            while(rand == int.Parse(preguntas1[contador].imagen))
            {
                rand = Random.Range(0, 10);
            }
            aux.Add(rand.ToString());           
        }

        aux = DesordenarLista<string>(aux);

        for(int i = 0; i < 8; i++)
        {
            panel1.transform.GetChild(i + 1).gameObject.SetActive(true);
            panel1.transform.GetChild(i + 1).GetChild(0).GetComponent<Text>().text = aux[i];
            if (aux[i] == preguntas1[contador].imagen)
            {
                panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = true;
            }
            else
            {
                panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = false;
            }
            

        }
    }
    public void botonPulsadoN1(int id)
    {
        if (panel1.transform.GetChild(id).GetComponent<IdSeleccion>().correcto)
        {
            panel1.transform.GetChild(id).gameObject.SetActive(false);
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }

        tiempo = 1;
        numRespuestas++;


        if (numRespuestas == 4)
        {
            numRespuestas = 0;
            contador++;            
            siguientePreguntaN1();
         

        }

    }

    void nivel2()
    {
        numInicioN2 = Random.Range(0, 10);
        numNivel2 = numInicioN2;
        numMaximoN2 = numInicioN2 + 12;
        repeticiones = 4;

        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona todos los numeras de menor a mayor";
        siguientePreguntaN2();
    }

    void siguientePreguntaN2()
    {
        if (numNivel2 < numMaximoN2)
        {
            panel2.transform.GetChild(0).GetChild(0).GetComponent<Text>().text = numNivel2.ToString();
            if (primera == false)
            {
                generarBotonesN2();
                primera=true;
            }
        }
        else
        {
            if (contadorRep == repeticiones)
            {

                panelFin.SetActive(true);
                textoPrincipal.GetComponent<Text>().text = "Ejercicio de atencion nivel 2 completado";
                panelFin.transform.GetChild(0).GetComponent<Text>().text = "tiempo";
                panelFin.transform.GetChild(1).GetComponent<Text>().text = tiempoEjercicio.ToString() + "s";
                panelFin.transform.GetChild(2).GetComponent<Text>().text = "el tiempo minimo para completar el nivel es 80s";
                if (tiempoEjercicio < 80)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 3";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(3);
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
                primera = false;
                for (int i = 0; i < 12; i++)
                {
                    panel2.transform.GetChild(i + 1).gameObject.SetActive(true);
                }
                contadorRep++;
                nivel2();
               
            }
        }
    }

    void generarBotonesN2()
    {
        List<int> aux = new List<int>();
        
        for (int i = 0; i < 12; i++)
        {
            aux.Add(numInicioN2 + i);
        }

        aux = DesordenarLista<int>(aux);
        for(int i = 0; i < 12; i++)
        {
            panel2.transform.GetChild(i + 1).GetChild(0).GetComponent<Text>().text = aux[i].ToString();
            panel2.transform.GetChild(i + 1).GetComponent<IdSeleccion>().id = aux[i];
        }
    }

    public void botonPulsadoN2(int id)
    {
        
        if(numNivel2 == panel2.transform.GetChild(id).GetComponent<IdSeleccion>().id)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            numNivel2++;
            panel2.transform.GetChild(id).gameObject.SetActive(false);

        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        tiempo = 1;
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
        tiempoEjercicio+= Time.deltaTime;
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


public class Pregunta1A
{
    public Pregunta1A(string img, int gru)
    {

        imagen = img;
        grupo = gru;
    }
    public string imagen;
    public int solucion;
    public int grupo;
}
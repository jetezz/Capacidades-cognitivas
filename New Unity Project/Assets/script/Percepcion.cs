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


    //nivel1
    List<Pregunta1P> preguntas1 = new List<Pregunta1P>();
    public GameObject panel1;
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
        if (respuesta)
        {
            panel1.transform.GetChild(id + 1).gameObject.SetActive(false);
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
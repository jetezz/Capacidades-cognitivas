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

    //grupo0N2
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


    //grupo1N2
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





    //nivel1
    List<Pregunta1P> preguntas1 = new List<Pregunta1P>();
    public GameObject panel1;



    //nivel2
    List<Pregunta2P> preguntas2 = new List<Pregunta2P>();
    public GameObject panel2;
    Dictionary<int, Sprite> grupo1N2=new Dictionary<int, Sprite>();
    Dictionary<int, Sprite> grupo2N2= new Dictionary<int, Sprite>();




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
        }else if (nivel==2)
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
        if (numRespuestas == numRespuestasNivel)
        {
            numRespuestas = 0;
            contador++;
            if (nivel == 1)
            {
                siguientePreguntaN1();
            }
            else if(nivel==2)
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

    }
  

    void generarBotonesN2()
    {
        List<InfoBoton> aux = new List<InfoBoton>();
        List<InfoBoton> botonesRand = new List<InfoBoton>();

        aux.Add(new InfoBoton(cogerImagenGrupoN2(),true));
        aux.Add(new InfoBoton(cogerImagenGrupoN2(), true));
        

        Dictionary<int, Sprite> aux2 = new Dictionary<int, Sprite>();

        if (preguntas2[contador].grupo == 0)
        {
            aux2 = grupo1N2;
        }
        else
        {
            aux2 = grupo2N2;
        }

       
        for(int i = 0; i < 6; i++)
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
        else
        {
            aux = grupo2N2[preguntas2[contador].id];
        }


        return aux;
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

public class Pregunta2P{
    public Pregunta2P(int i,int gru)
    {
        id = i;
        grupo = gru;
    }
    public int id;
    public int grupo;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Praxia : MonoBehaviour
{
    GameObject sonidos;
    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;
    private float tiempo = 0;

    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

    //grupo1 n1
    public Sprite desayunar;
    public Sprite comprar;
    public Sprite correr;
    public Sprite dormir;
    public Sprite duchar;
    public Sprite fregar;
    public Sprite lavarDientes;
    public Sprite ponerLavado;
    public Sprite preparaMesa;

    //grupo1 N2
    public Sprite zumo;
    public Sprite cesta;
    public Sprite depor;
    public Sprite almohada;
    public Sprite alcachofa;
    public Sprite estropajo;
    public Sprite pasta;
    public Sprite detergente;
    public Sprite tenedor;



    //nivel1
    public GameObject panel1;
    Dictionary<int, Sprite> grupo1N1;
    List<Praxia1> preguntas1;

    //nivel2
    public GameObject panel2;
    List<Praxia2> preguntas2;

    //nivel3
    public GameObject panel3;
    List<Praxia3> preguntas3;
    int numrespuestas = 0;

    //nivel4
    public GameObject panel4;
    public GameObject slotsN4;
    List<Praxia4> preguntas4;
    public bool[] resultados = new bool[6];
    public GameObject botonCorregir;
    public GameObject botonSiguiente;
    public GameObject panelBloqueo;
    public GameObject drags;


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
        managerEjercicios = GameObject.FindWithTag("MEje");
        sonidos = GameObject.FindWithTag("Sonido");


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
    void final(string nivel,int pMax,int siguienteNnivel)
    {
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel "+ siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.praxia(siguienteNnivel);
            GameObject managerUsuario = GameObject.FindWithTag("MUsu");
            managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
        }
        else
        {
           
            siguienteNnivel--;
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;
            
           
        }
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }

    void nivel1()
    {
        List<Praxia1> aux = new List<Praxia1>();
        grupo1N1 = new Dictionary<int, Sprite>();
        grupo1N1.Add(0, desayunar);
        grupo1N1.Add(1, comprar);
        grupo1N1.Add(2, correr);
        grupo1N1.Add(3, dormir);
        grupo1N1.Add(4, duchar);
        grupo1N1.Add(5, fregar);
        grupo1N1.Add(6, lavarDientes);
        grupo1N1.Add(7, ponerLavado);
        grupo1N1.Add(8, preparaMesa);

        preguntas1 = new List<Praxia1>();
        aux.Add(new Praxia1(0, "Desayunar"));
        aux.Add(new Praxia1(1, "Comprar en el supermercado"));
        aux.Add(new Praxia1(2, "Salir a correr"));
        aux.Add(new Praxia1(3, "Dormir"));
        aux.Add(new Praxia1(4, "Ducharse"));
        aux.Add(new Praxia1(5, "Fregar los platos"));
        aux.Add(new Praxia1(6, "Lavarse los dientes"));
        aux.Add(new Praxia1(7, "Poner la lavadora"));
        aux.Add(new Praxia1(8, "Peinarse el pelo"));

        aux = DesordenarLista<Praxia1>(aux);

        for(int i = 0; i < 5; i++)
        {
            preguntas1.Add(aux[i]);
        }

        panel1.SetActive(true);
        siguientePreguntaN1();

    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            textoPrincipal.GetComponent<Text>().text = preguntas1[contador].pregunta;
            generarBotones1();
        }
        else
        {
            final("Ejercicio praxia nivel 1 completado",5,2);
        }
    }
    void generarBotones1()
    {
        int rand;
        bool repetido = false;
        List<int> aux = new List<int>();

        aux.Add(preguntas1[contador].id);

        for (int i = 0; i < 2; i++)
        {
            rand = Random.Range(0, 9);
            for (int j = 0; j < aux.Count; j++)
            {
                if (aux[j] == rand)
                {
                    repetido = true;
                }
            }
            if (repetido)
            {
                i--;
            }
            else
            {
                aux.Add(rand);
            }
            repetido = false;
        }
        aux = DesordenarLista<int>(aux);
        for (int i = 0; i < 3; i++)
        {
            panel1.transform.GetChild(i).GetComponent<Image>().sprite = grupo1N1[aux[i]];
            if (preguntas1[contador].id == aux[i])
            {
                panel1.transform.GetChild(i).GetComponent<IdSeleccion>().correcto = true;
            }
            else
            {
                panel1.transform.GetChild(i).GetComponent<IdSeleccion>().correcto = false;
            }
        }
    
    }
    public void botonesN1(int id)
    {
       if (panel1.transform.GetChild(id).GetComponent<IdSeleccion>().correcto)
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
        contador++;
        siguientePreguntaN1();
    }

    void nivel2()
    {
        preguntas2 = new List<Praxia2>();
        List<Praxia2> aux = new List<Praxia2>();
        grupo1N1 = new Dictionary<int, Sprite>();
        grupo1N1.Add(0, desayunar);
        grupo1N1.Add(1, comprar);
        grupo1N1.Add(2, correr);
        grupo1N1.Add(3, dormir);
        grupo1N1.Add(4, duchar);
        grupo1N1.Add(5, fregar);
        grupo1N1.Add(6, lavarDientes);
        grupo1N1.Add(7, ponerLavado);
        grupo1N1.Add(8, preparaMesa);

        aux.Add(new Praxia2(0, zumo));
        aux.Add(new Praxia2(1, cesta));
        aux.Add(new Praxia2(2, depor));
        aux.Add(new Praxia2(3, almohada));
        aux.Add(new Praxia2(4, alcachofa));
        aux.Add(new Praxia2(5, estropajo));
        aux.Add(new Praxia2(6, pasta));
        aux.Add(new Praxia2(7, detergente));
        aux.Add(new Praxia2(8, tenedor));
        aux = DesordenarLista<Praxia2>(aux);

        for (int i = 0; i < 5; i++)
        {
            preguntas2.Add(aux[i]);
        }

        textoPrincipal.GetComponent<Text>().text = "Pulsa la acci�n relacionada con la imagen";
        preguntas2 = DesordenarLista<Praxia2>(preguntas2);
     
        panel2.SetActive(true);
        siguientePreguntaN2();
    }
    void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
            panel2.transform.GetChild(0).GetComponent<Image>().sprite = preguntas2[contador].imagen;
            generarBotones2();
        }
        else
        {
            final("Ejercicio praxia nivel 2 completado", 5, 3);
        }
    }
    void generarBotones2()
    {
       
        List<Praxia2> aux = new List<Praxia2>();

        int rand;
        bool repetido = false;

        aux.Add(new Praxia2(preguntas2[contador].id, grupo1N1[preguntas2[contador].id]));
        

        for(int i = 0; i < 2; i++)
        {
            rand = Random.Range(0, grupo1N1.Count);
            for(int j = 0; j < aux.Count; j++)
            {
                if (aux[j].id == rand)
                {
                    repetido = true;
                }
            }
            if (repetido)
            {
                i--;
            }
            else
            {
                aux.Add(new Praxia2(rand,grupo1N1[rand]));
            }
            repetido = false;
        }



        aux = DesordenarLista<Praxia2>(aux);
        for(int i = 0; i < 3; i++)
        {
            panel2.transform.GetChild(i + 1).GetComponent<Image>().sprite = aux[i].imagen;
            if (aux[i].id == preguntas2[contador].id)
            {
                panel2.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = true;
            }
            else
            {
                panel2.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = false;
            }
        }
    }
    public void botonesN2(int id)
    {
        if (panel2.transform.GetChild(id).GetComponent<IdSeleccion>().correcto)
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
        contador++;
        siguientePreguntaN2();

    }

    void nivel3()
    {
        textoPrincipal.GetComponent<Text>().text = "Pulsa las secuencia de la primera a la ultima";
        List<string> fase1 = new List<string>();
        List<string> fase2 = new List<string>();
        List<string> fase3 = new List<string>();
        List<string> fase4 = new List<string>();
        List<string> fase5 = new List<string>();
        List<string> fase6 = new List<string>();
        List<string> fase7 = new List<string>();
        List<string> fase8 = new List<string>();

        fase1.Add("Echar aceite a la sarten");
        fase1.Add("Romper el huevo");
        fase1.Add("Freir el huevo");
        fase1.Add("Comer el huevo");

        fase2.Add("Meter la camiseta en la lavadora");
        fase2.Add("Tender la camisa");
        fase2.Add("Planchar la camisa");
        fase2.Add("Guardar la camisa en el armario");

        fase3.Add("Meterse en la ducha");
        fase3.Add("Enjabonarse");
        fase3.Add("Secarse");
        fase3.Add("Vestirse");

        fase4.Add("Salir de casa");
        fase4.Add("Ir a la tienda");
        fase4.Add("Comprar");
        fase4.Add("Pagar");

        fase5.Add("Saltan al campo de futbol");
        fase5.Add("Meten un gol");
        fase5.Add("Pitan el final del partido");
        fase5.Add("Celebran la victoria");

        fase6.Add("Llegar a la peluqueria");
        fase6.Add("Lavarse el pelo");
        fase6.Add("Cortarse el pelo");
        fase6.Add("Peinarse el pelo");

        fase7.Add("Nos reunimos los amigos");
        fase7.Add("Compramos las entradas");
        fase7.Add("Vemos la pelicula");
        fase7.Add("Salimos del cine");

        fase8.Add("Sacamos la tarta");
        fase8.Add("Encendemos las velas");
        fase8.Add("Cantamos cumplea�os feliz");
        fase8.Add("Soplamos las velas");






        List<Praxia3> aux = new List<Praxia3>();
        preguntas3 = new List<Praxia3>();
        aux.Add(new Praxia3(fase1));
        aux.Add(new Praxia3(fase2));
        aux.Add(new Praxia3(fase3));
        aux.Add(new Praxia3(fase4));
        aux.Add(new Praxia3(fase5));
        aux.Add(new Praxia3(fase6));
        aux.Add(new Praxia3(fase7));
        aux.Add(new Praxia3(fase8));
        aux = DesordenarLista<Praxia3>(aux);
        for(int i = 0; i < 5; i++)
        {
            preguntas3.Add(aux[i]);
        }


        panel3.SetActive(true);
        siguientePreguntaN3();

    }
    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            generarBotones3();
        }
        else
        {
            final("Ejercicio praxia nivel 3 completado", 20, 4);
        }
    }
    void generarBotones3()
    {
        List<Praxia1> aux = new List<Praxia1>();
        for(int i = 0; i < preguntas3[contador].preguntas.Count; i++)
        {
            aux.Add(new Praxia1(i, preguntas3[contador].preguntas[i]));
        }
        aux = DesordenarLista<Praxia1>(aux);
        for(int i = 0; i < 4; i++)
        {
            panel3.transform.GetChild(i).gameObject.SetActive(true);
            panel3.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = aux[i].pregunta;
            panel3.transform.GetChild(i).GetComponent<IdSeleccion>().id = aux[i].id;
        }
    }

    public void botonesN3(int id)
    {
        if (panel3.transform.GetChild(id).GetComponent<IdSeleccion>().id == preguntas3[contador].contador)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);
            panel3.transform.GetChild(id).gameObject.SetActive(false);
            preguntas3[contador].contador++;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
        }
        numrespuestas++;
        if (numrespuestas == 4)
        {
            numrespuestas = 0;
            contador++;
            siguientePreguntaN3();
        }
        tiempo = 1;
      
    }
    void nivel4()
    {
        
        textoPrincipal.GetComponent<Text>().text = "Indica el orden de las secuencias";
        for (int i = 0; i < 6; i++)
        {
            resultados[i] = false;
            drags.transform.GetChild(i).GetComponent<Drag>().iniciarposicion();
        }
        preguntas4 = new List<Praxia4>();
        panel4.SetActive(true);

        List < Praxia1 > fase1= new List<Praxia1>();
        fase1.Add(new Praxia1(0, "Llamar a un restaurante"));
        fase1.Add(new Praxia1(1, "Reservar una mesa"));
        fase1.Add(new Praxia1(2, "Ir al restaurante"));
        fase1.Add(new Praxia1(3, "Aguardar en la entrada del restaurante"));
        fase1.Add(new Praxia1(4, "Leer el menu"));
        fase1.Add(new Praxia1(5, "Pedir los platos al camarero"));

        fase1 = DesordenarLista<Praxia1>(fase1);
        preguntas4.Add(new Praxia4(fase1));


        List<Praxia1> fase2 = new List<Praxia1>();
        fase2.Add(new Praxia1(1, "Esperar al tren en el anden"));
        fase2.Add(new Praxia1(2, "Subir al tren"));
        fase2.Add(new Praxia1(0, "Comprar los billetes"));
        fase2.Add(new Praxia1(5, "Salir de la estacion de trenes"));
        fase2.Add(new Praxia1(4, "Bajar del tren"));
        fase2.Add(new Praxia1(3, "Buscar el asiento"));

        fase2 = DesordenarLista<Praxia1>(fase2);
        preguntas4.Add(new Praxia4(fase2));

        List<Praxia1> fase3 = new List<Praxia1>();
        fase3.Add(new Praxia1(3, "Comer"));
        fase3.Add(new Praxia1(1, "Cocinar la comida"));
        fase3.Add(new Praxia1(2, "Poner la mesa"));
        fase3.Add(new Praxia1(4, "Tirar los restos de comida"));
        fase3.Add(new Praxia1(0, "Pensar la comida"));
        fase3.Add(new Praxia1(5, "Lavar los platos"));

        fase3 = DesordenarLista<Praxia1>(fase3);
        preguntas4.Add(new Praxia4(fase3));


        List<Praxia1> fase4 = new List<Praxia1>();
        fase4.Add(new Praxia1(1, "Salgo de casa"));
        fase4.Add(new Praxia1(4, "Meto la compra en la bolsa"));
        fase4.Add(new Praxia1(5, "Coloco la compra en su sitio"));
        fase4.Add(new Praxia1(3, "Paso por caja y pago"));
        fase4.Add(new Praxia1(2, "Cojo un carro"));
        fase4.Add(new Praxia1(0, "Elaboro una lista de la compra"));

        fase4 = DesordenarLista<Praxia1>(fase4);
        preguntas4.Add(new Praxia4(fase4));


        List<Praxia1> fase5 = new List<Praxia1>();
        fase5.Add(new Praxia1(0, "Meter la ropa en la lavadora"));
        fase5.Add(new Praxia1(3, "Esperar a que termina el lavado"));
        fase5.Add(new Praxia1(4, "Teder la ropa"));
        fase5.Add(new Praxia1(5, "Planchar la ropa"));
        fase5.Add(new Praxia1(2, "Seleccionar el programa de lavado"));
        fase5.Add(new Praxia1(1, "Echar el jabon y el suavante"));

        fase5 = DesordenarLista<Praxia1>(fase5);
        preguntas4.Add(new Praxia4(fase5));



        siguientePreguntaN4();

    }
    
    void siguientePreguntaN4()
    {
        
        botonSiguiente.SetActive(false);
        if (contador < preguntas4.Count)
        {
            generarBotones4();
        }
        else
        {
            final("Ejercicio praxia nivel 4 completado", 30, 5);
        }
    }
    void generarBotones4()
    {
        for(int i = 0; i < 6; i++)
        {
            panel4.transform.GetChild(i).GetComponent<Text>().text = preguntas4[contador].preguntas[i].pregunta;
            slotsN4.transform.GetChild(i).GetComponent<SlotPraxia>().id= preguntas4[contador].preguntas[i].id;
            slotsN4.transform.GetChild(i).GetComponent<Image>().color = Color.grey;
            drags.transform.GetChild(i).GetComponent<Drag>().resetPosition();
        }
    }
    public void corregirN4()
    {
        for(int i = 0; i < 6; i++)
        {
            if (resultados[i])
            {
                puntos++;
                slotsN4.transform.GetChild(i).GetComponent<Image>().color = Color.green;
            }
            else
            {
                slotsN4.transform.GetChild(i).GetComponent<Image>().color = Color.red;
            }
        }
        botonCorregir.SetActive(false);
        botonSiguiente.SetActive(true);
        panelBloqueo.SetActive(true);


    }
    public void siguienteN4()
    {
        numrespuestas = 0;
        contador++;
        siguientePreguntaN4();
        panelBloqueo.SetActive(false);

    }
    public void nuevaRespuesta()
    {
        numrespuestas++;
        if (numrespuestas > 5)
        {
            botonCorregir.SetActive(true);
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

class Praxia1
{
    public Praxia1(int i,string pre)
    {
        id=i;
        pregunta = pre;
    }
    public int id;
    public string pregunta;
   
}

class Praxia2
{
    public Praxia2(int i,Sprite img)
    {
        id=i;
        imagen = img;
    }
    public int id;
    public Sprite imagen;
}

class Praxia3
{
    public Praxia3(List<string> aux)
    {
        preguntas = new List<string>();
        preguntas = aux;
    }
    public List<string> preguntas;
    public int contador = 0;
    
}

class Praxia4
{
    public Praxia4(List<Praxia1> aux)
    {
        preguntas = new List<Praxia1>();
        preguntas = aux;
    }
    
    public List<Praxia1> preguntas;
    
}
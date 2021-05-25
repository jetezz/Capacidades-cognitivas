using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class Calculo : MonoBehaviour
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
    int preguntasTotales = 0;
    

    public Sprite c5;
    public Sprite c10;
    public Sprite c20;
    public Sprite c50;
    public Sprite e1;
    public Sprite e2;
    public Sprite e5;
    public Sprite e10;
    public Sprite e20;
    public Sprite e50;

    public Sprite etiqueta1;
    public Sprite etiqueta2;
    public Sprite etiqueta3;
    public Sprite etiqueta4;
    public Sprite etiqueta5;
    public Sprite etiqueta6;
    public Sprite etiqueta7;
    public Sprite etiqueta8;
    public Sprite etiqueta9;

    public Sprite img1;
    public Sprite img2;
    public Sprite img3;
    public Sprite img4;
    public Sprite img5;
    public Sprite img6;
    public Sprite img7;
    public Sprite img8;
    public Sprite img9;


    int puntosMaximos = 0;


    //nivel 1
    Dictionary<int, Sprite> imagenesN1;
    public GameObject panel1;
    List<Calculo1> preguntas1;
    // nivel2
    public GameObject panel2;
    List<Calculo2> preguntas2;
    public GameObject precio;
    float dinero;
    public int nivel;
    //nivel3
    public GameObject panel3;   
    List<Calculo3> preguntas3;
    List<Moneda> monedas;
    List<Billete> billetes;
    List<Calculo3> conjuntos;

    //nivel4
    public GameObject panel4;
    int preguntas4 = 5;
    List<Grupo2> conjunto2;
    public float precioTotal = 0;
    public GameObject botonesN4;
    
 
    public static List<T> DesordenarLista<T>(List<T> input)
    {
        List<T> arr = input;
        List<T> arrDes = new List<T>();
       

        while (arr.Count > 0)
        {
            int val = UnityEngine.Random.Range(0, arr.Count);
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

        }
        
        
    }
    void final(string nivel, int pMax,int pMin, int siguienteNnivel,bool ultimo)
    {
        textoPrincipal.GetComponent<Text>().text = "Finalizado los ejercicios de Cálculo nivel " + (siguienteNnivel - 1).ToString();
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos máximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.calculo(siguienteNnivel);
            GameObject managerUsuario = GameObject.FindWithTag("MUsu");
            managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
        }
        else
        {
            if(puntos< pMin)
            {
                if (!ultimo)
                {
                    siguienteNnivel--;
                }
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Bajas al nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.calculo(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.calculo(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            


        }
        sonidos.GetComponent<Sonidos>().repSonido(4);
    }
    void nivel1()
    {
        preguntasTotales = 0;
        imagenesN1 = new Dictionary<int, Sprite>();
        imagenesN1.Add(0, c5);
        imagenesN1.Add(1, c10);
        imagenesN1.Add(2, c20);
        imagenesN1.Add(3, c50);
        imagenesN1.Add(4, e5);
        imagenesN1.Add(5, e10);
        imagenesN1.Add(6, e20);
        imagenesN1.Add(7, e50);
 

        preguntas1 = new List<Calculo1>();
        preguntas1.Add(new Calculo1(0, "Pulsa la moneda de 5 céntimos",true));
        preguntas1.Add(new Calculo1(1, "Pulsa la moneda de 10 céntimos", true));
        preguntas1.Add(new Calculo1(2, "Pulsa la moneda de 20 céntimos", true));
        preguntas1.Add(new Calculo1(3, "Pulsa la moneda de 50 céntimos", true));
        preguntas1.Add(new Calculo1(4, "Pulsa el billete de 5 euros", false));
        preguntas1.Add(new Calculo1(5, "Pulsa el billete de 10 euros", false));
        preguntas1.Add(new Calculo1(6, "Pulsa el billete de 20 euros", false));
        preguntas1.Add(new Calculo1(7, "Pulsa el billete de 50 euros", false));
        preguntas1.Add(new Calculo1(0, "Pulsa la moneda de 5 céntimos", true));
        preguntas1.Add(new Calculo1(1, "Pulsa la moneda de 10 céntimos", true));
        preguntas1.Add(new Calculo1(2, "Pulsa la moneda de 20 céntimos", true));
        preguntas1.Add(new Calculo1(3, "Pulsa la moneda de 50 céntimos", true));
        preguntas1.Add(new Calculo1(4, "Pulsa el billete de 5 euros", false));
        preguntas1.Add(new Calculo1(5, "Pulsa el billete de 10 euros", false));
        preguntas1.Add(new Calculo1(6, "Pulsa el billete de 20 euros", false));
        preguntas1.Add(new Calculo1(7, "Pulsa el billete de 50 euros", false));




        preguntas1 = DesordenarLista<Calculo1>(preguntas1);

        panel1.SetActive(true);
        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            textoPrincipal.GetComponent<Text>().text = preguntas1[contador].pregunta;
            panel1.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            panel1.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
            panel1.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
            panel1.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
            

            generarBotonesN1();
        }
        else
        {
            final("Ejercicio de cálculo nivel1 completado", preguntasTotales,preguntasTotales/2, 2,false);
        }
    }
    public void generarBotonesN1()
    {
        List<Botones2> aux = new List<Botones2>();
        aux.Add(new Botones2(imagenesN1[preguntas1[contador].imagen], true,preguntas1[contador].moneta));
        bool auxmoneda = true;

        int rand = UnityEngine.Random.Range(0, imagenesN1.Count);
        while(rand== preguntas1[contador].imagen)
        {
            rand = UnityEngine.Random.Range(0, imagenesN1.Count);
        }
        if (rand > 3)
        {
            auxmoneda = false;
        }
        aux.Add(new Botones2(imagenesN1[rand], false,auxmoneda));

        aux = DesordenarLista<Botones2>(aux);

        for(int i = 0; i< 2; i++)
        {
            if (aux[i].moneda)
            {
                panel1.transform.GetChild(i).GetChild(1).gameObject.SetActive(true);
                panel1.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = aux[i].img;
            }
            else
            {
                panel1.transform.GetChild(i).GetChild(0).gameObject.SetActive(true);
                panel1.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = aux[i].img;
            }
            panel1.transform.GetChild(i).GetComponent<IdSeleccion>().correcto = aux[i].correc;
        }
    }
    public void respuestaN1(int respuesta)
    {
        if (panel1.transform.GetChild(respuesta).GetComponent<IdSeleccion>().correcto)
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
        preguntasTotales++;
        siguientePreguntaN1();

    }
    void nivel2()
    {
        preguntas3 = new List<Calculo3>();
        monedas = new List<Moneda>();
        billetes = new List<Billete>();

        monedas.Add(new Moneda(c5, 0.05f));
        monedas.Add(new Moneda(c10, 0.10f));
        monedas.Add(new Moneda(c20, 0.20f));
        monedas.Add(new Moneda(c50, 0.50f));
        monedas.Add(new Moneda(e1, 1f));
        monedas.Add(new Moneda(e2, 2f));



        billetes.Add(new Billete(e5, 5f));
        billetes.Add(new Billete(e10, 10f));
        billetes.Add(new Billete(e20, 20f));
        billetes.Add(new Billete(e50, 50f));

        conjuntos = new List<Calculo3>();

        //1
        List<Moneda> monedas1 = new List<Moneda>();
        List<Billete> billetes1 = new List<Billete>();
        monedas1.Add(monedas[4]);        
        preguntas3.Add(new Calculo3(monedas1, billetes1));

        //1
        List<Moneda> monedas2 = new List<Moneda>();
        List<Billete> billetes2 = new List<Billete>();
        monedas2.Add(monedas[3]);
        monedas2.Add(monedas[3]);
        conjuntos.Add(new Calculo3(monedas2, billetes2));

        //2
        List<Moneda> monedas3 = new List<Moneda>();
        List<Billete> billetes3 = new List<Billete>();
        monedas3.Add(monedas[5]);
      
        preguntas3.Add(new Calculo3(monedas3, billetes3));

        //2
        List<Moneda> monedas4 = new List<Moneda>();
        List<Billete> billetes4 = new List<Billete>();
        monedas4.Add(monedas[4]);
        monedas4.Add(monedas[4]);
        conjuntos.Add(new Calculo3(monedas4, billetes4));

        //3
        List<Moneda> monedas5 = new List<Moneda>();
        List<Billete> billetes5 = new List<Billete>();
        monedas5.Add(monedas[4]);
        monedas5.Add(monedas[5]);
        preguntas3.Add(new Calculo3(monedas5, billetes5));

        //3
        List<Moneda> monedas6 = new List<Moneda>();
        List<Billete> billetes6 = new List<Billete>();
        monedas6.Add(monedas[4]);
        monedas6.Add(monedas[4]);
        monedas6.Add(monedas[4]);       
        conjuntos.Add(new Calculo3(monedas6, billetes6));


        //20
        List<Moneda> monedas7 = new List<Moneda>();
        List<Billete> billetes7 = new List<Billete>();
        billetes7.Add(billetes[2]);
        preguntas3.Add(new Calculo3(monedas7, billetes7));

        //20
        List<Moneda> monedas8 = new List<Moneda>();
        List<Billete> billetes8 = new List<Billete>();
        billetes8.Add(billetes[1]);
        billetes8.Add(billetes[1]);
        conjuntos.Add(new Calculo3(monedas8, billetes8));


        //0.10
        List<Moneda> monedas9 = new List<Moneda>();
        List<Billete> billetes9 = new List<Billete>();
        monedas9.Add(monedas[1]);
      
        preguntas3.Add(new Calculo3(monedas9, billetes9));

        //0.10
        List<Moneda> monedas10 = new List<Moneda>();
        List<Billete> billetes10 = new List<Billete>();
        monedas10.Add(monedas[0]);
        monedas10.Add(monedas[0]);
        conjuntos.Add(new Calculo3(monedas10, billetes10));


        //0.20
        List<Moneda> monedas11 = new List<Moneda>();
        List<Billete> billetes11 = new List<Billete>();
        monedas11.Add(monedas[2]);       
        preguntas3.Add(new Calculo3(monedas11, billetes11));

        //0.20
        List<Moneda> monedas12 = new List<Moneda>();
        List<Billete> billetes12 = new List<Billete>();
        monedas12.Add(monedas[1]);
        monedas12.Add(monedas[1]);
        conjuntos.Add(new Calculo3(monedas12, billetes12));

        //0.30
        List<Moneda> monedas13 = new List<Moneda>();
        List<Billete> billetes13 = new List<Billete>();
        monedas13.Add(monedas[2]);
        monedas13.Add(monedas[1]);

        preguntas3.Add(new Calculo3(monedas13, billetes13));

        //0.30
        List<Moneda> monedas14 = new List<Moneda>();
        List<Billete> billetes14 = new List<Billete>();
        monedas14.Add(monedas[1]);
        monedas14.Add(monedas[1]);
        monedas14.Add(monedas[1]);
        conjuntos.Add(new Calculo3(monedas14, billetes14));


       


        panel3.SetActive(true);


        preguntas3 = DesordenarLista<Calculo3>(preguntas3);

        textoPrincipal.GetComponent<Text>().text = "Pulsa en el grupo que contenga el mismo dinero que el grupo de arriba";
        siguientePreguntaN3();


    }
    
    void nivel3()
    {
        preguntas3 = new List<Calculo3>();
        monedas = new List<Moneda>();
        billetes = new List<Billete>();

        monedas.Add(new Moneda(c5, 0.05f));
        monedas.Add(new Moneda(c10, 0.10f));
        monedas.Add(new Moneda(c20, 0.20f));
        monedas.Add(new Moneda(c50, 0.50f));
        monedas.Add(new Moneda(e1, 1f));
        monedas.Add(new Moneda(e2, 2f));



        billetes.Add(new Billete(e5, 5f));
        billetes.Add(new Billete(e10, 10f));
        billetes.Add(new Billete(e20, 20f));
        billetes.Add(new Billete(e50, 50f));

        conjuntos = new List<Calculo3>();

        //15,10
        List<Moneda> monedas1=new List<Moneda>();
        List<Billete> billetes1=new List<Billete>();       
        monedas1.Add(monedas[1]);
        billetes1.Add(billetes[0]);
        billetes1.Add(billetes[1]);
        preguntas3.Add(new Calculo3(monedas1, billetes1));
        //15,15
        List<Moneda> monedas2 = new List<Moneda>();
        List<Billete> billetes2 = new List<Billete>();
        monedas2.Add(monedas[1]);      
        billetes2.Add(billetes[0]);
        billetes2.Add(billetes[0]);
        billetes2.Add(billetes[0]);
        conjuntos.Add(new Calculo3(monedas2, billetes2));

        //20,20
        List<Moneda> monedas3 = new List<Moneda>();
        List<Billete> billetes3 = new List<Billete>();
        monedas3.Add(monedas[1]);
        monedas3.Add(monedas[1]);
        billetes3.Add(billetes[2]);
        preguntas3.Add(new Calculo3(monedas3, billetes3));

        //20,20
        List<Moneda> monedas4 = new List<Moneda>();
        List<Billete> billetes4 = new List<Billete>();
        monedas4.Add(monedas[2]);        
        billetes4.Add(billetes[1]);
        billetes4.Add(billetes[1]);
        conjuntos.Add(new Calculo3(monedas4, billetes4));       

        //20,50
        List<Moneda> monedas5 = new List<Moneda>();
        List<Billete> billetes5 = new List<Billete>();
        monedas5.Add(monedas[3]);
        billetes5.Add(billetes[1]);
        billetes5.Add(billetes[1]);
        preguntas3.Add(new Calculo3(monedas5, billetes5));

        //20,50
        List<Moneda> monedas6 = new List<Moneda>();
        List<Billete> billetes6 = new List<Billete>();
        monedas6.Add(monedas[2]);
        monedas6.Add(monedas[2]);
        monedas6.Add(monedas[1]);
        billetes6.Add(billetes[2]);
        conjuntos.Add(new Calculo3(monedas6, billetes6));


        //50
        List<Moneda> monedas7 = new List<Moneda>();
        List<Billete> billetes7 = new List<Billete>();        
        billetes7.Add(billetes[3]);
        preguntas3.Add(new Calculo3(monedas7, billetes7));


        //50
        List<Moneda> monedas8 = new List<Moneda>();
        List<Billete> billetes8 = new List<Billete>();
        billetes8.Add(billetes[2]);
        billetes8.Add(billetes[2]);
        billetes8.Add(billetes[1]);
        conjuntos.Add(new Calculo3(monedas8, billetes8));


        //5,30
        List<Moneda> monedas9 = new List<Moneda>();
        List<Billete> billetes9 = new List<Billete>();
        monedas9.Add(monedas[1]);
        monedas9.Add(monedas[2]);
        billetes9.Add(billetes[0]);
        preguntas3.Add(new Calculo3(monedas9, billetes9));

        //5,30
        List<Moneda> monedas10 = new List<Moneda>();
        List<Billete> billetes10 = new List<Billete>();
        monedas10.Add(monedas[1]);
        monedas10.Add(monedas[1]);
        monedas10.Add(monedas[1]);
        billetes10.Add(billetes[0]);
        conjuntos.Add(new Calculo3(monedas10, billetes10));


        //2,10
        List<Moneda> monedas11 = new List<Moneda>();
        List<Billete> billetes11 = new List<Billete>();
        monedas11.Add(monedas[4]);
        monedas11.Add(monedas[4]);
        monedas11.Add(monedas[1]);      
        preguntas3.Add(new Calculo3(monedas11, billetes11));

        //2,10
        List<Moneda> monedas12 = new List<Moneda>();
        List<Billete> billetes12 = new List<Billete>();
        monedas12.Add(monedas[5]);
        monedas12.Add(monedas[0]);
        monedas12.Add(monedas[0]);    
        conjuntos.Add(new Calculo3(monedas12, billetes12));

        //60
        List<Moneda> monedas13 = new List<Moneda>();
        List<Billete> billetes13 = new List<Billete>();
        billetes13.Add(billetes[3]);
        billetes13.Add(billetes[1]);
        preguntas3.Add(new Calculo3(monedas13, billetes13));

        //60
        List<Moneda> monedas14 = new List<Moneda>();
        List<Billete> billetes14 = new List<Billete>();
        billetes14.Add(billetes[2]);
        billetes14.Add(billetes[2]);
        billetes14.Add(billetes[2]);
        conjuntos.Add(new Calculo3(monedas14, billetes14));


        //3,10
        List<Moneda> monedas15 = new List<Moneda>();
        List<Billete> billetes15 = new List<Billete>();
        monedas15.Add(monedas[5]);
        monedas15.Add(monedas[4]);
        monedas15.Add(monedas[0]);
        monedas15.Add(monedas[0]);

        preguntas3.Add(new Calculo3(monedas15, billetes15));

        //60
        List<Moneda> monedas16 = new List<Moneda>();
        List<Billete> billetes16 = new List<Billete>();
        monedas16.Add(monedas[4]);
        monedas16.Add(monedas[4]);
        monedas16.Add(monedas[4]);
        monedas16.Add(monedas[1]);
        conjuntos.Add(new Calculo3(monedas16, billetes16));


        panel3.SetActive(true);


        preguntas3 = DesordenarLista<Calculo3>(preguntas3);

        textoPrincipal.GetComponent<Text>().text = "Pulsa en el grupo que contenga el mismo dinero que el grupo de arriba";
        siguientePreguntaN3();

    }

    void siguientePreguntaN3()
    {
      
        if (contador < preguntas3.Count)
        {
            instanciar(panel3.transform.GetChild(0).gameObject, preguntas3[contador].monedas, preguntas3[contador].billetes);
            generarGruposN3();
        }
        else
        {
            final("Ejercicio de cálculo nivel3 completado", puntosMaximos,puntosMaximos/2, nivel+1,false);
        }
    }
    void generarGruposN3()
    {
       
        List<Calculo3> aux=new List<Calculo3>();
        for(int i = 0; i < conjuntos.Count; i++)
        {
           
            if (preguntas3[contador].cantidad == conjuntos[i].cantidad)            {               
                aux.Add(conjuntos[i]);
                break;
            }
        }
     

        for(int i = 0; i < 3; i++)
        {
          for(int j = 0; j < conjuntos.Count; j++)
            {
                if (preguntas3[contador].cantidad != conjuntos[j].cantidad)
                {
                    bool repetido=false;
                    for(int y = 0; y < aux.Count; y++)
                    {
                        if (conjuntos[j].cantidad == aux[y].cantidad)
                        {
                            repetido = true;
                        }
                    }
                    if (repetido == false)
                    {
                        aux.Add(conjuntos[j]);
                        break;
                    }
                    
                }
            }
        }
        aux = DesordenarLista<Calculo3>(aux);
        for(int i = 0; i < 4; i++)
        {
            instanciar(panel3.transform.GetChild(i + 1).gameObject, aux[i].monedas, aux[i].billetes);
            if(aux[i].cantidad== preguntas3[contador].cantidad)
            {
                panel3.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = true;
            }
            else
            {
                panel3.transform.GetChild(i + 1).GetComponent<IdSeleccion>().correcto = false;
            }
        }

        
    }
    void instanciar(GameObject objeto,List<Moneda> mone, List<Billete> bille)
    {
        GameObject g;
        for(int i = 0; i < mone.Count; i++)
        {
            g = Instantiate(objeto.transform.GetChild(0).gameObject, objeto.transform);
            g.SetActive(true);
            g.GetComponent<Image>().sprite = mone[i].imagen;
            
        }
        for(int i = 0; i < bille.Count;i++)
        {
            g = Instantiate(objeto.transform.GetChild(1).gameObject, objeto.transform);
            g.SetActive(true);
            g.GetComponent<Image>().sprite = bille[i].imagen;
        }
    }
    public void pulsarGrupoN3(int i)
    {
        if (panel3.transform.GetChild(i).GetComponent<IdSeleccion>().correcto)
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
        puntosMaximos++;
        tiempo = 1;
        contador++;
        destruirObjetos();
        siguientePreguntaN3();
    }
    void destruirObjetos()
    {
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < panel3.transform.GetChild(i).childCount - 2; j++)
            {               
                DestroyImmediate(panel3.transform.GetChild(i).GetChild(2).gameObject);
                j--;
            }
        }
    }
    void nivel4()
    {
        conjunto2 = new List<Grupo2>();
        conjunto2.Add(new Grupo2(img1, etiqueta1, 10.50f));
        conjunto2.Add(new Grupo2(img2, etiqueta2, 5.30f));
        conjunto2.Add(new Grupo2(img3, etiqueta3, 3.60f));
        conjunto2.Add(new Grupo2(img4, etiqueta4, 1.80f));
        conjunto2.Add(new Grupo2(img5, etiqueta5, 15.50f));
        conjunto2.Add(new Grupo2(img6, etiqueta6, 20.30f));
        conjunto2.Add(new Grupo2(img7, etiqueta7, 30.50f));
        conjunto2.Add(new Grupo2(img8, etiqueta8, 40.50f));
        conjunto2.Add(new Grupo2(img9, etiqueta9, 50.35f));
        
        panel4.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Calcula la suma de estos objetos";
        siguientePreguntaN4();
    }
    void siguientePreguntaN4()
    {
        precioTotal = 0;
        if (contador < preguntas4)
        {
            generarGruposN4();
            generarBotonesN4();
        }
        else
        {
            final("Ejercicio de cálculo nivel4 completado", 5,4, 4,true);
        }
    }
    void generarGruposN4()
    {
        int rand = 0;
        for(int i = 0; i < 4; i++)
        {
            rand = UnityEngine.Random.Range(0, conjunto2.Count);
            panel4.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = conjunto2[rand].img;
            panel4.transform.GetChild(i).GetChild(1).GetComponent<Image>().sprite = conjunto2[rand].eti;
            precioTotal += conjunto2[rand].precio;

        }
        precioTotal = (float)(Math.Round(precioTotal * 100) / 100);
    }
    void generarBotonesN4()
    {
        List<float_bool> aux = new List<float_bool>();
        aux.Add(new float_bool(precioTotal, true));

        for(int i = 0; i < 2; i++)
        {
            float rando = UnityEngine.Random.Range(-10, 10);
            aux.Add(new float_bool(precioTotal + rando,false));
        }

        aux = DesordenarLista<float_bool>(aux);

        for(int i = 0; i < 3; i++)
        {
            botonesN4.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = aux[i].num.ToString() + "€";
            botonesN4.transform.GetChild(i).GetComponent<IdSeleccion>().correcto = aux[i].correcto;
        }


    }

   
    public void botonNivel4(int i)
    {
        
        if (botonesN4.transform.GetChild(i).GetComponent<IdSeleccion>().correcto)
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
        destruirObjetos();
        siguientePreguntaN4();
        
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

class Calculo1
{
    public Calculo1(int img, string pre, bool mo)
    {
        imagen = img;        
        pregunta = pre;
        moneta = mo;
    }

    public int imagen;
    public bool correcion;
    public string pregunta;
    public bool moneta;
}

class Calculo2
{
    public Calculo2(float pre, Sprite img, Sprite et)
    {
        precio = pre;
        imagen = img;
        etiqueta = et;
    }
    public float precio;
    public Sprite imagen;
    public Sprite etiqueta;
}

class Moneda
{
    public Moneda(Sprite img, float din)
    {
        imagen = img;
        dinero = din;
    }
    public Sprite imagen;
    public float dinero;
}

class Billete
{
    public Billete(Sprite img, float din)
    {
        imagen = img;
        dinero = din;
    }
    public Sprite imagen;
    public float dinero;

}

class Calculo3
{
    public Calculo3(List<Moneda> mon, List<Billete> bill)
    {
        monedas = new List<Moneda>();
        billetes = new List<Billete>();
        monedas = mon;
        billetes = bill;

        for (int i = 0; i < monedas.Count; i++)
        {
            cantidad += monedas[i].dinero;
        }
        for (int i = 0; i < billetes.Count; i++)
        {
            cantidad += billetes[i].dinero;
        }
       
    }


        
    public List<Moneda> monedas;
    public List<Billete> billetes;
    public float cantidad;
}

class Grupo2
{
    public Grupo2(Sprite im,Sprite et, float pre)
    {
        img = im;
        eti = et;
        precio = pre;
    }

    public Sprite img;
    public Sprite eti;
    public float precio;
}

class float_bool
{
    public float_bool(float nu,bool corr)
    {
        num = nu;
        correcto = corr;
    }

    public float num;
    public bool correcto;
}
class Botones2
{
    public Botones2(Sprite im, bool cor,bool mon)
    {
        img = im;
        correc = cor;
        moneda = mon;
    }
    public Sprite img;
    public bool correc;
    public bool moneda;
}
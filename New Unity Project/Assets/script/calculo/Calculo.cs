using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;




public class Calculo : MonoBehaviour
{

    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;
    private float tiempo = 0;

    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

    public Sprite c5;
    public Sprite c10;
    public Sprite c20;
    public Sprite c50;
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





    //nivel 1
    public GameObject panel1;
    List<Calculo1> preguntas1;
    // nivel2
    public GameObject panel2;
    List<Calculo2> preguntas2;
    public GameObject precio;
    float dinero;

    public static List<T> DesordenarLista<T>(List<T> input)
    {
        List<T> arr = input;
        List<T> arrDes = new List<T>();
        arr.Add(input[input.Count - 1]);

        while (arr.Count > 0)
        {
            int val = UnityEngine.Random.Range(0, arr.Count - 1);
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
    void final(string nivel, int pMax, int siguienteNnivel)
    {
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.calculo(siguienteNnivel);
            GameObject managerUsuario = GameObject.FindWithTag("MUsu");
            managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
        }
        else
        {

            siguienteNnivel--;
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;


        }
    }
    void nivel1()
    {
        preguntas1 = new List<Calculo1>();
        preguntas1.Add(new Calculo1(c5, true, "¿Es una moneda de 5 centimos?",true));
        preguntas1.Add(new Calculo1(c10, true, "¿Es una moneda de 10 centimos?",true));
        preguntas1.Add(new Calculo1(c20, true, "¿Es una moneda de 20 centimos?", true));
        preguntas1.Add(new Calculo1(c50, true, "¿Es una moneda de 50 centimos?", true));
        preguntas1.Add(new Calculo1(e5, true, "¿Es un billete de 5 euros?", false));
        preguntas1.Add(new Calculo1(e10, true, "¿Es un billete de 10 euros?", false));
        preguntas1.Add(new Calculo1(e20, true, "¿Es un billete de 20 euros?", false));
        preguntas1.Add(new Calculo1(e50, true, "¿Es un billete de 50 euros?", false));


        preguntas1.Add(new Calculo1(c10, false, "¿Es una moneda de 5 centimos?", true));
        preguntas1.Add(new Calculo1(c5, false, "¿Es una moneda de 10 centimos?", true));
        preguntas1.Add(new Calculo1(c50, false, "¿Es una moneda de 20 centimos?", true));
        preguntas1.Add(new Calculo1(c20, false, "¿Es una moneda de 50 centimos?", true));
        preguntas1.Add(new Calculo1(e50, false, "¿Es un billete de 5 euros?", false));
        preguntas1.Add(new Calculo1(e20, false, "¿Es un billete de 10 euros?", false));
        preguntas1.Add(new Calculo1(e10, false, "¿Es un billete de 20 euros?", false));
        preguntas1.Add(new Calculo1(e5, false, "¿Es un billete de 50 euros?", false));

        preguntas1 = DesordenarLista<Calculo1>(preguntas1);

        panel1.SetActive(true);
        siguientePreguntaN1();


    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            textoPrincipal.GetComponent<Text>().text = preguntas1[contador].pregunta;
            panel1.transform.GetChild(0).gameObject.SetActive(false);
            panel1.transform.GetChild(1).gameObject.SetActive(false);

            if (preguntas1[contador].moneta)
            {
                panel1.transform.GetChild(0).gameObject.SetActive(true);
                panel1.transform.GetChild(0).GetComponent<Image>().sprite = preguntas1[contador].imagen;
            }
            else
            {
                panel1.transform.GetChild(1).gameObject.SetActive(true);
                panel1.transform.GetChild(1).GetComponent<Image>().sprite = preguntas1[contador].imagen;
            }
           
        }
        else
        {
            final("Ejercicio de calculo nivel1 completado", 16, 2);
        }
    }
    public void respuestaN1(bool respuesta)
    {
        if (respuesta == preguntas1[contador].correcion)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        tiempo = 1;
        contador++;
        siguientePreguntaN1();

    }
    void nivel2()
    {
        preguntas2 = new List<Calculo2>();

        preguntas2.Add(new Calculo2(10.50f, img1, etiqueta1));
        preguntas2.Add(new Calculo2(5.30f, img2, etiqueta2));
        preguntas2.Add(new Calculo2(3.60f, img3, etiqueta3));
        preguntas2.Add(new Calculo2(1.80f, img4, etiqueta4));
        preguntas2.Add(new Calculo2(15.50f, img5, etiqueta5));
        preguntas2.Add(new Calculo2(20.30f, img6, etiqueta6));
        preguntas2.Add(new Calculo2(30.50f, img7, etiqueta7));
        preguntas2.Add(new Calculo2(40.50f, img8, etiqueta8));
        preguntas2.Add(new Calculo2(50.35f, img9, etiqueta9));

        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Pulsa las moneadas para llegar al precio justo y dale a pagar";
        siguientePreguntaN2();


    }
    void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
            panel2.transform.GetChild(0).GetComponent<Image>().sprite = preguntas2[contador].imagen;
            panel2.transform.GetChild(1).GetComponent<Image>().sprite = preguntas2[contador].etiqueta;
            dinero = 0.00f;
            precio.GetComponent<Text>().text = dinero.ToString() ;

        }
        else
        {
            final("Ejercicio de calculo nivel2 completado", 9, 3);
        }
        
    }

    public void botonPulsadoN2(float cantidad)
    {
       
        dinero += cantidad;
        dinero= (float)(Math.Round(dinero*100)/100);

        precio.GetComponent<Text>().text = dinero.ToString();
    }
    public void botonPagarN2()
    {
        if (dinero == preguntas2[contador].precio)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        tiempo = 1;
        contador++;
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

class Calculo1
{
    public Calculo1(Sprite img,bool corr, string pre, bool mo)
    {
        imagen = img;
        correcion = corr;
        pregunta = pre;
        moneta = mo;
    }

    public Sprite imagen;
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
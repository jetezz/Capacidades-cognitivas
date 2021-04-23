using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Atencion : MonoBehaviour
{
    GameObject sonidos;
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

    //nivel3
    public GameObject panel3;
    public GameObject numeros;
    List<int> preguntas3 = new List<int>();
    int respuestaN3;
    public GameObject inputNumero;

    //nivel4
    public GameObject panel4;
    public GameObject numeros4;
    List<Pregunta4A> preguntas4;
    int posicionNumN4 = 45;
    public GameObject inputNumero2;

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
    void final(string nivel, int pMax, int pMin, int siguienteNnivel,bool ultimo)
    {
        textoPrincipal.GetComponent<Text>().text = "Finalizado los ejercicios de Atención nivel " + (siguienteNnivel - 1).ToString();
        panelFin.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = nivel;
        panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
        panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son " + pMax;
        if (puntos == pMax)
        {
            panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel " + siguienteNnivel;
            managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(siguienteNnivel);
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
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                siguienteNnivel--;
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel " + siguienteNnivel;
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(siguienteNnivel);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }



        }
        sonidos.GetComponent<Sonidos>().repSonido(4);
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

        preguntas1 = DesordenarLista<Pregunta1A>(preguntas1);


        panel1.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imágenes que son iguales al ejemplo";
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
            final("Ejercicio de Atención nivel1 completado", 36, 15, 2,false);
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
            sonidos.GetComponent<Sonidos>().repSonido(2);
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
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
        repeticiones = 3;

        panel2.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona todos los numeros de menor a mayor";
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
                    if (tiempoEjercicio > 150)
                    {
                        panelFin.transform.GetChild(3).GetComponent<Text>().text = "Bajas al nivel 1";
                        managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(1);
                        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                        managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                    }
                    else
                    {
                        panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 2";
                        managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(2);
                        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                        managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                    }
                    
                }
                sonidos.GetComponent<Sonidos>().repSonido(4);
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
            sonidos.GetComponent<Sonidos>().repSonido(2);
            numNivel2++;
            panel2.transform.GetChild(id).gameObject.SetActive(false);

        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
        }
        tiempo = 1;
        siguientePreguntaN2();
    }

    void nivel3()
    {
        
        for (int i = 0; i < 2; i++) {
            preguntas3.Add(Random.Range(0, 36));
        }

        preguntas3.Add(Random.Range(30, 36));


        textoPrincipal.GetComponent<Text>().text = "Introduce el numero que falta 0-35";
        tiempoEjercicio = 0;
        panel3.SetActive(true);
        siguientePreguntaN3();
    }
    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            generarNumerosN3();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de atencion nivel 3 completado";
            panelFin.transform.GetChild(0).GetComponent<Text>().text = "tiempo";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = tiempoEjercicio.ToString() + "s";
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "el tiempo minimo para completar el nivel es 200s";
            if (tiempoEjercicio < 300)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 4";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(4);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                if (tiempoEjercicio > 400)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Bajas al nivel 2";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(2);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 3";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(3);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                
            }
            sonidos.GetComponent<Sonidos>().repSonido(4);
        }
    }
    void generarNumerosN3()
    {
        List<int> aux = new List<int>();

        for(int i =0; i< 36; i++)
        {
            if(i!= preguntas3[contador])
            {
                aux.Add(i);
            }
        }
        aux = DesordenarLista<int>(aux);
        for(int i = 0; i < aux.Count; i++)
        {
            numeros.transform.GetChild(i).GetComponent<Text>().text = aux[i].ToString();
        }
        numeros.transform.GetChild(35).GetComponent<Text>().text = "";
    }

    public void inputRespuestaN3(string res)
    {
       
          respuestaN3 = int.Parse(res);
       
    }
    public void botonComprobarN3()
    {
        if (respuestaN3 == preguntas3[contador])
        {
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);
            contador++;
            siguientePreguntaN3();
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
            tiempoEjercicio += 5;
        }

        tiempo = 1;
        inputNumero.GetComponent<InputField>().Select();
        inputNumero.GetComponent<InputField>().text = "";

    }

    void nivel4()
    {
        preguntas4 = new List<Pregunta4A>();
        List<int> aux = new List<int>();
     


       
        
        for (int i = 0; i < 4; i++)
        {
            aux.Add(Random.Range(0, 49));
          
        }        
             
        preguntas4.Add(new Pregunta4A(aux));     
      


        textoPrincipal.GetComponent<Text>().text = "Introduce el numero que falta 0-48";
        tiempoEjercicio = 0;
        panel4.SetActive(true);
        siguientePreguntaN4();

    }
    void siguientePreguntaN4()
    {
        if (contador < preguntas4.Count)
        {
            generarNumerosN4();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de atencion nivel 4 completado";
            panelFin.transform.GetChild(0).GetComponent<Text>().text = "tiempo";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = tiempoEjercicio.ToString() + "s";
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "el tiempo minimo para completar el nivel es 300s";
            if (tiempoEjercicio < 300)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "has completado todos los niveles de atencion";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(4);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                if (tiempoEjercicio > 600)
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Bajas al nivel 3";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(3);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
                else
                {
                    panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 4";
                    managerEjercicios.GetComponent<ManagerEjercicios>().usuario.atencion(4);
                    GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                    managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
                }
              
            }
            sonidos.GetComponent<Sonidos>().repSonido(4);
        }
    }
    void generarNumerosN4()
    {
        List<int> aux = new List<int>();
        bool esta = false;
        for (int i = 0; i < 49; i++)
        {
            for(int j = 0; j < preguntas4[contador].numeros.Count;j++)
            {
                if(i == preguntas4[contador].numeros[j])
                {
                    esta = true;
                }
            }
            if (esta==false)
            {
                aux.Add(i);
            }
            esta = false;
        }
        aux = DesordenarLista<int>(aux);
        for (int i = 0; i < aux.Count; i++)
        {
            numeros4.transform.GetChild(i).GetComponent<Text>().text = aux[i].ToString();
        }
        numeros4.transform.GetChild(45).GetComponent<Text>().text = "";
        numeros4.transform.GetChild(46).GetComponent<Text>().text = "";
        numeros4.transform.GetChild(47).GetComponent<Text>().text = "";
        numeros4.transform.GetChild(48).GetComponent<Text>().text = "";

    }

    public void botonComprobarN4()
    {
        bool esta = false;

        for (int i = 0; i < preguntas4[contador].numeros.Count; i++)
        {
            if (preguntas4[contador].numeros[i] == respuestaN3)
            {
                esta = true;
                preguntas4[contador].numeros.RemoveAt(i);
                break;
            }
        }

        if (esta)
        {
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            sonidos.GetComponent<Sonidos>().repSonido(2);
            numeros4.transform.GetChild(posicionNumN4).GetComponent<Text>().text = respuestaN3.ToString();
            posicionNumN4++;
            numRespuestas++;
            if (numRespuestas == 4)
            {
                numRespuestas = 0;
                contador++;
                posicionNumN4 = 45;
                siguientePreguntaN4();
            }
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
            sonidos.GetComponent<Sonidos>().repSonido(3);
            tiempoEjercicio += 5;
        }
        inputNumero2.GetComponent<InputField>().Select();
        inputNumero2.GetComponent<InputField>().text = "";
        tiempo = 1;
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
        
        sonidos.GetComponent<Sonidos>().repSonido(1);
        SceneManager.LoadScene(0);
    }
    public void siguienteEjercicio()
    {
        sonidos.GetComponent<Sonidos>().repSonido(0);
        managerEjercicios.GetComponent<ManagerEjercicios>().iniciarEjercicio();
    }
}


 class Pregunta1A
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

class Pregunta4A
{
    public Pregunta4A(List<int> nums)
    {
        numeros = new List<int>();
        numeros = nums;
    }
    public List<int> numeros;
}
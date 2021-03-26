using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gnoxias : MonoBehaviour
{
    private GameObject managerEjercicios;
    private int contador = 0;
    public int puntos = 0;

    private float tiempo = 0;
    //private int numRespuestas = 0;

    public GameObject textoPrincipal;
    public GameObject panelFin;
    public GameObject imagenCorreccion;
    public Sprite tick;
    public Sprite cruz;

    //grupo 1

    //imagenes
    public Sprite imagen1;
    public Sprite imagen2;
    public Sprite imagen3;
    public Sprite imagen4;
    public Sprite imagen5;
    public Sprite imagen6;
    public Sprite imagen7;
    public Sprite imagen8;
    public Sprite imagen9;
    //trozos
    public Sprite trozo1;
    public Sprite trozo2;
    public Sprite trozo3;
    public Sprite trozo4;
    public Sprite trozo5;
    public Sprite trozo6;
    public Sprite trozo7;
    public Sprite trozo8;
    public Sprite trozo9;
    // ////////////////////

    //grupo1 n2 animales    
    public Sprite f1;
    public Sprite f2;
    public Sprite f3;
    public Sprite f4;
    public Sprite f5;
    public Sprite f6;
    //grupo2 n2 cocina
    public Sprite f7;
    public Sprite f8;
    public Sprite f9;
    public Sprite f10;
    public Sprite f11;
    public Sprite f12;
    public Sprite f13;
    //grupo3 n2 fruta
    public Sprite f14;
    public Sprite f15;
    public Sprite f16;
    public Sprite f17;
    public Sprite f18;
    public Sprite f19;

    //grupo1 n2 animales   silueta
    public Sprite s1;
    public Sprite s2;
    public Sprite s3;
    public Sprite s4;
    public Sprite s5;
    public Sprite s6;
    //grupo2 n2 cocina
    public Sprite s7;
    public Sprite s8;
    public Sprite s9;
    public Sprite s10;
    public Sprite s11;
    public Sprite s12;
    public Sprite s13;
    //grupo3 n2 fruta
    public Sprite s14;
    public Sprite s15;
    public Sprite s16;
    public Sprite s17;
    public Sprite s18;
    public Sprite s19;

    //grupo4 n1 
    public Sprite puz1;
    public Sprite puz2;
    public Sprite puz3;
    public Sprite puz4;
    public Sprite puz5;
    public Sprite puz6;
    public Sprite puz7;
    public Sprite puz8;
    public Sprite puz9;
    public Sprite puz10;
    public Sprite puz11;
    public Sprite puz12;





    //nivel1
    public GameObject panel1;
    List<Pregunta1G> preguntas1;    
    Dictionary<int, Sprite> trozosN1;
    // nivel2
    public GameObject panel2;
    Dictionary<int, Sprite> imagenesN2;
    Dictionary<int, Sprite> siluetasN2;
    List<Pregunta2G> preguntas2;

    //Nivel3
    public GameObject panel3;
    List<Pregunta3G> preguntas3;
    int numRespuestas = 0;

    //Nivel4
    Dictionary<int, Sprite> grupo1N4;
    public GameObject panel4;
    List<Pregunta4G> preguntasN4;



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
        preguntas1 = new List<Pregunta1G>();
        List<Pregunta1G> aux = new List<Pregunta1G>();
        trozosN1 = new Dictionary<int, Sprite>();
       
       

        trozosN1.Add(0, trozo1);
        trozosN1.Add(1, trozo2);
        trozosN1.Add(2, trozo3);
        trozosN1.Add(3, trozo4);
        trozosN1.Add(4, trozo5);
        trozosN1.Add(5, trozo6);
        trozosN1.Add(6, trozo7);
        trozosN1.Add(7, trozo8);
        trozosN1.Add(8, trozo9);

        aux.Add(new Pregunta1G(imagen1, 0));
        aux.Add(new Pregunta1G(imagen2, 1));
        aux.Add(new Pregunta1G(imagen3, 2));
        aux.Add(new Pregunta1G(imagen4, 3));
        aux.Add(new Pregunta1G(imagen5, 4));
        aux.Add(new Pregunta1G(imagen6, 5));
        aux.Add(new Pregunta1G(imagen7, 6));
        aux.Add(new Pregunta1G(imagen8, 7));
        aux.Add(new Pregunta1G(imagen9, 8));


        aux = DesordenarLista<Pregunta1G>(aux);
        preguntas1.Add(aux[0]);
        preguntas1.Add(aux[1]);
        preguntas1.Add(aux[2]);
        preguntas1.Add(aux[3]);
        preguntas1.Add(aux[4]);

        panel1.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona el trozo que corresponde a la imagen";
        siguientePreguntaN1();

    }
    void siguientePreguntaN1()
    {
        if (contador < preguntas1.Count)
        {
            panel1.transform.GetChild(0).GetComponent<Image>().sprite = preguntas1[contador].imagen;
            generarBotonesN1();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de Gnoxia nivel 1 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 5 ";
            if (puntos == 5)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 2";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.gnosia(2);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 1";
            }
        }
    }
    void generarBotonesN1()
    {
        List<Pregunta1G> aux = new List<Pregunta1G>();
        int rand;
        bool repetido = false;
        aux.Add(new Pregunta1G(trozosN1[preguntas1[contador].id], preguntas1[contador].id));

        for (int i = 0; i < 3; i++)
        {
            rand = Random.Range(0, 9);
            while (rand==preguntas1[contador].id)
            {
                rand = Random.Range(0, 9);
            }
            for(int j = 0; j < aux.Count; j++)
            {
                if (rand == aux[j].id)
                {
                    repetido = true;
                }
            }

            if (!repetido)
            {
                aux.Add(new Pregunta1G(trozosN1[rand], rand));
            }
            else
            {
                i--;
            }
            repetido = false;       
        }
        aux = DesordenarLista<Pregunta1G>(aux);
        for(int i = 0; i < 4; i++)
        {
            panel1.transform.GetChild(i + 1).GetComponent<Image>().sprite = aux[i].imagen;
            panel1.transform.GetChild(i + 1).GetComponent<IdSeleccion>().id = aux[i].id;
        }
    }
    public void botonN1(int id)
    {
        if (panel1.transform.GetChild(id).GetComponent<IdSeleccion>().id == preguntas1[contador].id)
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
        imagenesN2 = new Dictionary<int, Sprite>();
        siluetasN2 = new Dictionary<int, Sprite>();

        imagenesN2.Add(0, f1);
        imagenesN2.Add(1, f2);
        imagenesN2.Add(2, f3);
        imagenesN2.Add(3, f4);
        imagenesN2.Add(4, f5);
        imagenesN2.Add(5, f6);
        imagenesN2.Add(6, f7);
        imagenesN2.Add(7, f8);
        imagenesN2.Add(8, f9);
        imagenesN2.Add(9, f10);
        imagenesN2.Add(10, f11);
        imagenesN2.Add(11, f12);
        imagenesN2.Add(12, f13);
        imagenesN2.Add(13, f14);
        imagenesN2.Add(14, f15);
        imagenesN2.Add(15, f16);
        imagenesN2.Add(16, f17);
        imagenesN2.Add(17, f18);
        imagenesN2.Add(18, f19);

        siluetasN2.Add(0, s1);
        siluetasN2.Add(1, s2);
        siluetasN2.Add(2, s3);
        siluetasN2.Add(3, s4);
        siluetasN2.Add(4, s5);
        siluetasN2.Add(5, s6);
        siluetasN2.Add(6, s7);
        siluetasN2.Add(7, s8);
        siluetasN2.Add(8, s9);
        siluetasN2.Add(9, s10);
        siluetasN2.Add(10, s11);
        siluetasN2.Add(11, s12);
        siluetasN2.Add(12, s13);
        siluetasN2.Add(13, s14);
        siluetasN2.Add(14, s15);
        siluetasN2.Add(15, s16);
        siluetasN2.Add(16, s17);
        siluetasN2.Add(17, s18);
        siluetasN2.Add(18, s19);


        preguntas2 = new List<Pregunta2G>();
        List<Pregunta2G> aux = new List<Pregunta2G>();

        aux.Add(new Pregunta2G(siluetasN2[0], 0, 1));
        aux.Add(new Pregunta2G(siluetasN2[1], 1, 1));
        aux.Add(new Pregunta2G(siluetasN2[2], 2, 1));
        aux.Add(new Pregunta2G(siluetasN2[3], 3, 1));
        aux.Add(new Pregunta2G(siluetasN2[4], 4, 1));
        aux.Add(new Pregunta2G(siluetasN2[5], 5, 1));

        aux.Add(new Pregunta2G(siluetasN2[6], 6, 2));
        aux.Add(new Pregunta2G(siluetasN2[7], 7, 2));
        aux.Add(new Pregunta2G(siluetasN2[8], 8, 2));
        aux.Add(new Pregunta2G(siluetasN2[9], 9, 2));
        aux.Add(new Pregunta2G(siluetasN2[10], 10, 2));
        aux.Add(new Pregunta2G(siluetasN2[11], 11, 2));
        aux.Add(new Pregunta2G(siluetasN2[12], 12, 2));

        aux.Add(new Pregunta2G(siluetasN2[13], 13, 3));
        aux.Add(new Pregunta2G(siluetasN2[14], 14, 3));
        aux.Add(new Pregunta2G(siluetasN2[15], 15, 3));
        aux.Add(new Pregunta2G(siluetasN2[16], 16, 3));
        aux.Add(new Pregunta2G(siluetasN2[17], 17, 3));
        aux.Add(new Pregunta2G(siluetasN2[18], 18, 3));

        aux = DesordenarLista<Pregunta2G>(aux);
        for(int i = 0; i < 12; i++)
        {
            preguntas2.Add(aux[i]);
        }
        

        panel2.SetActive(true);

        textoPrincipal.GetComponent<Text>().text = "Seleciona la imagen que corresponde a la silueta";
        siguientePreguntaN2();





    }
    void siguientePreguntaN2()
    {
        if (contador < preguntas2.Count)
        {
            panel2.transform.GetChild(0).GetComponent<Image>().sprite = preguntas2[contador].imagen;
            generarBotonesN2();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de Gnoxia nivel 2 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 12 ";
            if (puntos == 12)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 3";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.gnosia(3);
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
        List<Pregunta1G> aux = new List<Pregunta1G>();
        int rand = 0;
        bool repetido = false;
        aux.Add(new Pregunta1G(imagenesN2[preguntas2[contador].id], preguntas2[contador].id));

        for(int i = 0; i < 5; i++)
        {
            rand = randomGrupos(preguntas2[contador].grupo);
            while (rand==preguntas2[contador].id)
            {
                rand = randomGrupos(preguntas2[contador].grupo);
            }
            for(int j = 0; j < aux.Count; j++)
            {
                if (aux[j].id == rand)
                {
                    repetido = true;                    
                }
            }            
            if (!repetido)
            {
                aux.Add(new Pregunta1G(imagenesN2[rand], rand));
            }
            else
            {
                i--;
            }
            repetido = false;

        }
        aux = DesordenarLista<Pregunta1G>(aux);
        for (int i = 0; i < 6; i++)
        {
            panel2.transform.GetChild(i+1).GetComponent<Image>().sprite = aux[i].imagen;
            panel2.transform.GetChild(i+1).GetComponent<IdSeleccion>().id=aux[i].id;
        }
    }
    public void botonN2(int id)
    {
        if (preguntas2[contador].id == panel2.transform.GetChild(id).GetComponent<IdSeleccion>().id)
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

    int randomGrupos(int i)
    {
        int aux=0;
        if (i == 1)
        {
            aux = Random.Range(0, 6);
        }else if(i == 2)
        {
            aux = Random.Range(6, 13);
        }
        else if(i == 3)
        {
            aux = Random.Range(13, 19);
        }
        return aux;
    }
    void nivel3()
    {
        imagenesN2 = new Dictionary<int, Sprite>();
        siluetasN2 = new Dictionary<int, Sprite>();

        imagenesN2.Add(0, f1);
        imagenesN2.Add(1, f2);
        imagenesN2.Add(2, f3);
        imagenesN2.Add(3, f4);
        imagenesN2.Add(4, f5);
        imagenesN2.Add(5, f6);
        imagenesN2.Add(6, f7);
        imagenesN2.Add(7, f8);
        imagenesN2.Add(8, f9);
        imagenesN2.Add(9, f10);
        imagenesN2.Add(10, f11);
        imagenesN2.Add(11, f12);
        imagenesN2.Add(12, f13);
        imagenesN2.Add(13, f14);
        imagenesN2.Add(14, f15);
        imagenesN2.Add(15, f16);
        imagenesN2.Add(16, f17);
        imagenesN2.Add(17, f18);
        imagenesN2.Add(18, f19);

        siluetasN2.Add(0, s1);
        siluetasN2.Add(1, s2);
        siluetasN2.Add(2, s3);
        siluetasN2.Add(3, s4);
        siluetasN2.Add(4, s5);
        siluetasN2.Add(5, s6);
        siluetasN2.Add(6, s7);
        siluetasN2.Add(7, s8);
        siluetasN2.Add(8, s9);
        siluetasN2.Add(9, s10);
        siluetasN2.Add(10, s11);
        siluetasN2.Add(11, s12);
        siluetasN2.Add(12, s13);
        siluetasN2.Add(13, s14);
        siluetasN2.Add(14, s15);
        siluetasN2.Add(15, s16);
        siluetasN2.Add(16, s17);
        siluetasN2.Add(17, s18);
        siluetasN2.Add(18, s19);

        preguntas3 = new List<Pregunta3G>();
        List<Pregunta3G> aux = new List<Pregunta3G>();

   
        preguntas3.Add(generarPreguntas(1));
        preguntas3.Add(generarPreguntas(1));
        preguntas3.Add(generarPreguntas(2));
        preguntas3.Add(generarPreguntas(2));
        preguntas3.Add(generarPreguntas(3));
        preguntas3.Add(generarPreguntas(3));
        preguntas3.Add(generarPreguntas(1));
        preguntas3.Add(generarPreguntas(1));
        preguntas3.Add(generarPreguntas(2));
        preguntas3.Add(generarPreguntas(2));
        preguntas3.Add(generarPreguntas(3));
        preguntas3.Add(generarPreguntas(3));
   













        panel3.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona las imagenes que aparecen en la silueta";
        siguientePreguntaN3();

    }
    Pregunta3G generarPreguntas(int grupo)
    {
        List<int> imagenes = new List<int>();
        int rand;
        bool igual = false;
        while (imagenes.Count < 3)
        {
            rand = randomGrupos(grupo);
            for(int i = 0; i < imagenes.Count; i++)
            {
                if (imagenes[i] == rand)
                {
                    igual = true;
                }              
            }
            if (!igual)
            {
                imagenes.Add(rand);
            }
            igual = false;
        }

        List<Sprite> auxSprites = new List<Sprite>();
        List<int> auxIds = new List<int>();

        for(int i = 0; i < 3; i++)
        {
            auxSprites.Add(siluetasN2[imagenes[i]]);
            auxIds.Add(imagenes[i]);
        }

        Pregunta3G ejercicio = new Pregunta3G(auxSprites, auxIds, grupo);
        return ejercicio;
        
    }
    void siguientePreguntaN3()
    {
        if (contador < preguntas3.Count)
        {
            for (int i = 0; i < 3; i++)
            {
                panel3.transform.GetChild(0).GetChild(i).GetComponent<Image>().sprite = preguntas3[contador].silueta[i];
            }
            generarBotonesN3();
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de Gnosia nivel 3 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 36 ";
            if (puntos == 36)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Pasas al nivel 4";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.gnosia(4);
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
        List<Pregunta1G> aux = new List<Pregunta1G>();
        int rand;
        bool igual = false;
        for(int i = 0; i < 3; i++)
        {
            aux.Add(new Pregunta1G(imagenesN2[preguntas3[contador].ids[i]], preguntas3[contador].ids[i]));
        }

        for(int i = 0; i < 3; i++)
        {
            rand = randomGrupos(preguntas3[contador].grupo);
            for(int j = 0; j < aux.Count; j++)
            {
                if (rand == aux[j].id)
                {
                    igual = true;
                }
            }
            if (igual)
            {
                i--;
            }
            else
            {
                aux.Add(new Pregunta1G(imagenesN2[rand], rand));
            }
            igual = false;
        }
        aux = DesordenarLista<Pregunta1G>(aux);
        for (int i = 0; i < 6; i++)
        {
            panel3.transform.GetChild(i + 1).gameObject.SetActive(true);
            panel3.transform.GetChild(i + 1).GetComponent<Image>().sprite = aux[i].imagen;
            panel3.transform.GetChild(i + 1).GetComponent<IdSeleccion>().id= aux[i].id;

        }
    }

    public void botonesN3(int id)
    {
        bool acierto = false;
        for(int i = 0; i < 3; i++)
        {
            if (panel3.transform.GetChild(id).GetComponent<IdSeleccion>().id == preguntas3[contador].ids[i])
            {
                acierto = true;
                break;
            }
        }
        if (acierto)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            panel3.transform.GetChild(id).gameObject.SetActive(false);
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        tiempo = 1;
        numRespuestas++;
        if (numRespuestas == 3)
        {
            numRespuestas = 0;
            contador++;
            siguientePreguntaN3();
        }      
    }
    void nivel4()
    {
        grupo1N4 = new Dictionary<int, Sprite>();
        grupo1N4.Add(0, puz1);
        grupo1N4.Add(1, puz2);
        grupo1N4.Add(2, puz3);
        grupo1N4.Add(3, puz4);
        grupo1N4.Add(4, puz5);
        grupo1N4.Add(5, puz6);
        grupo1N4.Add(6, puz7);
        grupo1N4.Add(7, puz8);
        grupo1N4.Add(8, puz9);
        grupo1N4.Add(9, puz10);
        grupo1N4.Add(10, puz11);
        grupo1N4.Add(11, puz12);

        preguntasN4 = new List<Pregunta4G>();
        for (int i = 0; i < 12; i++)
        {
            preguntasN4.Add(new Pregunta4G(grupo1N4[i],i));
        }

        preguntasN4 = DesordenarLista<Pregunta4G>(preguntasN4);
        panel4.SetActive(true);
        textoPrincipal.GetComponent<Text>().text = "Selecciona la casilla a la que corresponde esta imagen ";
        siguientePreguntaN4();
    }
    void siguientePreguntaN4()
    {
        if (contador < preguntasN4.Count)
        {
            panel4.transform.GetChild(1).GetComponent<Image>().sprite = preguntasN4[contador].imagen;
            
        }
        else
        {
            panelFin.SetActive(true);
            textoPrincipal.GetComponent<Text>().text = "Ejercicio de Gnosia nivel 4 completado";
            panelFin.transform.GetChild(1).GetComponent<Text>().text = puntos.ToString();
            panelFin.transform.GetChild(2).GetComponent<Text>().text = "Los puntos maximos son 12 ";
            if (puntos == 12)
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Has completado todos los ejercicios de gnosias";
                managerEjercicios.GetComponent<ManagerEjercicios>().usuario.gnosia(5);
                GameObject managerUsuario = GameObject.FindWithTag("MUsu");
                managerUsuario.GetComponent<ManagerUsuario>().guardarUsuarios();
            }
            else
            {
                panelFin.transform.GetChild(3).GetComponent<Text>().text = "Te mantienes en el nivel 4";
            }
        }
    }
    public void botonN4(int id)
    {
        
        if (preguntasN4[contador].id+1 == id)
        {
            puntos++;
            imagenCorreccion.GetComponent<Image>().sprite = tick;
            panel4.transform.GetChild(id+1).GetComponent<Image>().sprite = preguntasN4[contador].imagen;           
        }
        else
        {
            imagenCorreccion.GetComponent<Image>().sprite = cruz;
        }
        contador++;
        tiempo = 1;
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
        SceneManager.LoadScene(0);
    }
}


class Pregunta1G
{
    public Pregunta1G(Sprite img, int i)
    {
        imagen = img;
        id = i;
    }

    public Sprite imagen;
    public int id;
     
}


class Pregunta2G
{
    public Pregunta2G(Sprite img, int i, int gru)
    {
        imagen = img;
        id = i;
        grupo = gru;
    }

    public Sprite imagen;
    public int id;
    public int grupo;

}

class Pregunta3G
{
    public Pregunta3G(List<Sprite>sil,List<int>id,int gru)
    {
        silueta = sil;
        ids = id;
        grupo = gru;
    }
    public List<Sprite> silueta;
    public List<int> ids;
    public int grupo;
}

class Pregunta4G
{
    public Pregunta4G(Sprite img, int i)
    {
        imagen = img;
        id = i;
    }
    public Sprite imagen;
    public int id;
    public bool activo = false;

}
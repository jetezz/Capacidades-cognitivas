using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

[System.Serializable]
public class ManagerUsuario : MonoBehaviour
{
    public static ManagerUsuario managerUsuario;       
    public List<Usuario> usuarios;  
    public Usuario usuarioSeleccionado;



    private void Awake()
    {
        if (managerUsuario == null)
        {
            managerUsuario = this;
            DontDestroyOnLoad(gameObject);
            usuarios = GameObject.FindWithTag("Json").GetComponent<Ejemplojson>().cargarUsuarios();
        }
        else if (managerUsuario != this)
        {
            Destroy(gameObject);
        }
    }

  


    public void addUser(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    public void guardarUsuarios()
    {
        GameObject.FindWithTag("Json").GetComponent<Ejemplojson>().guardarUsuario(usuarios);
    }

    public Usuario getUsuarioByid(int id)
    {
        for (int i = 0; i < usuarios.Count; i++)
        {            
            if (usuarios[i].id==id)
            {
                usuarioSeleccionado = usuarios[i];
                return usuarioSeleccionado;
            }
        }
        return new Usuario("error", "error");
    }
    public Usuario getUsuarioSeleccionado()
    {
        return usuarioSeleccionado;
    }

    public bool comprobarSiHayUsuarios()
    {
        if (usuarios.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   


}

[System.Serializable]
public class Usuario
{
    
   public Usuario(string nombre, string detalles)
   {
       Name = nombre;
       Description = detalles;
        estadisticas = new Estadisticas();
   }
    public string Name;
    public string Description;
    public Sprite Icon;
    public int id;
    public Estadisticas estadisticas;

    public void memoria(int valor)
    {
        estadisticas.memoria.Add(new Dato("1", valor));
    }
    public void lenguaje(int valor)
    {
        estadisticas.lenguaje.Add(new Dato("1", valor));
    }
    public void percepcion(int valor)
    {
        estadisticas.percepcion.Add(new Dato("1", valor));
    }
    public void atencion(int valor)
    {
        estadisticas.atencion.Add(new Dato("1", valor));
    }
    public void gnosia(int valor)
    {
        estadisticas.gnosias.Add(new Dato("1", valor));
    }
    public void praxia(int valor)
    {
        estadisticas.praxias.Add(new Dato("1", valor));
    }
    public void orientacion(int valor)
    {
        estadisticas.orientacion.Add(new Dato("1", valor));
    }
    public void calculo(int valor)
    {
        estadisticas.calculo.Add(new Dato("1", valor));
    }

    public string getMemoria()
    {
        return estadisticas.memoria.Last().valor.ToString();
    }
    public string getLenguaje()
    {
        return estadisticas.lenguaje.Last().valor.ToString();
    }
    public string getPercepcion()
    {
        return estadisticas.percepcion.Last().valor.ToString();
    }
    public string getAtencion()
    {
        return estadisticas.atencion.Last().valor.ToString();
    }
    public string getGnosias()
    {
        return estadisticas.gnosias.Last().valor.ToString();
    }
    public string getPraxias()
    {
        return estadisticas.praxias.Last().valor.ToString();
    }
    public string getOrientacion()
    {
        return estadisticas.orientacion.Last().valor.ToString();
    }
    public string getCalculo()
    {
        return estadisticas.calculo.Last().valor.ToString();
    }

    public List<int> getPeorEstadistica()
    {
        
        List<int> listaEjercicios = new List<int>();

        int nivel = estadisticas.memoria.Last().valor;

        if (estadisticas.lenguaje.Last().valor < nivel)
        {            
            nivel = estadisticas.lenguaje.Last().valor;
        }

        if (estadisticas.percepcion.Last().valor < nivel)
        {            
            nivel = estadisticas.percepcion.Last().valor;
        }

        if (estadisticas.atencion.Last().valor < nivel)
        {            
            nivel = estadisticas.atencion.Last().valor;
        }
        if (estadisticas.gnosias.Last().valor < nivel)
        {            
            nivel = estadisticas.gnosias.Last().valor;
        }
        if (estadisticas.praxias.Last().valor < nivel)
        {            
            nivel = estadisticas.praxias.Last().valor;
        }
        if (estadisticas.orientacion.Last().valor < nivel)
        {            
            nivel = estadisticas.orientacion.Last().valor;
        }
        if (estadisticas.calculo.Last().valor < nivel)
        {            
            nivel = estadisticas.calculo.Last().valor;
        }



        if(estadisticas.memoria.Last().valor == nivel)
        {
            listaEjercicios.Add(0);
        }
        if (estadisticas.lenguaje.Last().valor == nivel)
        {
            listaEjercicios.Add(1);
        }
        if (estadisticas.percepcion.Last().valor == nivel)
        {
            listaEjercicios.Add(2);
        }
        if (estadisticas.atencion.Last().valor == nivel)
        {
            listaEjercicios.Add(3);
        }
        if (estadisticas.gnosias.Last().valor == nivel)
        {
            listaEjercicios.Add(4);
        }
        if (estadisticas.praxias.Last().valor == nivel)
        {
            listaEjercicios.Add(5);
        }
        if (estadisticas.orientacion.Last().valor == nivel)
        {
            listaEjercicios.Add(6);
        }
        if (estadisticas.calculo.Last().valor == nivel)
        {
            listaEjercicios.Add(7);
        }

        return listaEjercicios;
    }

    public int getNivelEstadistica(int est)
    {
        if (est == 0)
        {
            return estadisticas.memoria.Last().valor;
        }else if (est == 1)
        {
            return estadisticas.lenguaje.Last().valor;
        }else if (est == 2)
        {
            return estadisticas.percepcion.Last().valor;
        }else if(est == 3)
        {
            return estadisticas.atencion.Last().valor;
        }else if (est == 4)
        {
            return estadisticas.gnosias.Last().valor;
        }else if (est == 5)
        {
            return estadisticas.praxias.Last().valor;
        }
        else if (est == 6)
        {
            return estadisticas.orientacion.Last().valor;
        }
        else if (est == 7)
        {
            return estadisticas.calculo.Last().valor;
        }
        return 0;
    }
    public int getNumIntentos(int est)
    {
        if (est == 0)
        {
            return estadisticas.memoria.Count;
        }
        else if (est == 1)
        {
            return estadisticas.lenguaje.Count;
        }
        else if (est == 2)
        {
            return estadisticas.percepcion.Count;
        }
        else if (est == 3)
        {
            return estadisticas.atencion.Count;
        }
        else if (est == 4)
        {
            return estadisticas.gnosias.Count;
        }
        else if (est == 5)
        {
            return estadisticas.praxias.Count;
        }
        else if (est == 6)
        {
            return estadisticas.orientacion.Count;
        }
        else if (est == 7)
        {
            return estadisticas.calculo.Count;
        }
        return 0;
    }
    public int getNivelMax(int est)
    {
        if (est == 0)
        {
            return numMas(estadisticas.memoria);
        }
        else if (est == 1)
        {
            return numMas(estadisticas.lenguaje);
        }
        else if (est == 2)
        {
            return numMas(estadisticas.percepcion);
        }
        else if (est == 3)
        {
            return numMas(estadisticas.atencion);
        }
        else if (est == 4)
        {
            return numMas(estadisticas.gnosias);
        }
        else if (est == 5)
        {
            return numMas(estadisticas.praxias);
        }
        else if (est == 6)
        {
            return numMas(estadisticas.orientacion);
        }
        else if (est == 7)
        {
            return numMas(estadisticas.calculo);
        }
        return 0;

    }
    int numMas(List <Dato> list)
    {
        int inicial = 0;
        for(int i = 0; i < list.Count; i++)
        {
            if (list[i].valor > inicial)
            {
                inicial = list[i].valor;
            }
        }
        return inicial;
    }
    public List<int> getTabla(int est)
    {
        List<int> aux = new List<int>();
        if (est == 0)
        {
            return generarLista(estadisticas.memoria);
        }
        else if (est == 1)
        {
            return generarLista(estadisticas.lenguaje);
        }
        else if (est == 2)
        {
            return generarLista(estadisticas.percepcion);
        }
        else if (est == 3)
        {
            return generarLista(estadisticas.atencion);
        }
        else if (est == 4)
        {
            return generarLista(estadisticas.gnosias);
        }
        else if (est == 5)
        {
            return generarLista(estadisticas.praxias);
        }
        else if (est == 6)
        {
            return generarLista(estadisticas.orientacion);
        }
        else if (est == 7)
        {
            return generarLista(estadisticas.calculo);
        }

        return aux;
    }
    public List<int> generarLista(List<Dato> datos)
    {
        List<int> aux = new List<int>();

        for(int i = 0; i < datos.Count; i++)
        {
            aux.Add(datos[i].valor);
        }
        return aux;
    }

    }

[System.Serializable]
public class Estadisticas
{
   public  bool textInicial = false;
   public List<Dato> memoria=new List<Dato>();
   public List<Dato> lenguaje = new List<Dato>();
   public List<Dato> percepcion = new List<Dato>();
   public List<Dato> atencion = new List<Dato>();
   public List<Dato> gnosias = new List<Dato>();
   public List<Dato> praxias = new List<Dato>();
   public List<Dato> orientacion = new List<Dato>();
   public List<Dato> calculo = new List<Dato>();
}

[System.Serializable]
public class Dato
{
    public Dato(string Fecha, int Valor)
    {
        fecha = Fecha;
        valor = Valor;
    }
    public string fecha;
    public int valor;
}
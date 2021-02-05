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
    public int usuarioSeleccionado=-1;



    private void Awake()
    {
        if (managerUsuario == null)
        {
            managerUsuario = this;
            DontDestroyOnLoad(gameObject);
        }else if (managerUsuario != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
      
        usuarios = GameObject.FindWithTag("Json").GetComponent<Ejemplojson>().cargarUsuarios();        
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
                usuarioSeleccionado = i;
                return usuarios[i];
            }
        }
        return new Usuario("error", "error");
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
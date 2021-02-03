using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ManagerUsuario : MonoBehaviour
{
    public static ManagerUsuario managerUsuario;       
    public List<Usuario> usuarios;




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
            Debug.Log(i);
            if (usuarios[i].id==id)
            {
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
   

}

[System.Serializable]
public class Estadisticas
{
   public  bool textInicial = false;
   public  int[] estadistica1;
   public int[] estadistica2;
}


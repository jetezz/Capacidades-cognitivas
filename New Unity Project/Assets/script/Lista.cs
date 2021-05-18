using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class Lista : MonoBehaviour
{
   
    private GameObject managerUsuarios;
    public GameObject panelEliminarUsuario;
    public GameObject canvas;
    public GameObject panelCaracteristicas;
    public GameObject panelCapacidades;

    public string nombre;
    public string descripcion;
    public bool borrar = false;

    public int idSeleccion = 0;

    GameObject sonidos;



    void Start()
    {
        sonidos = GameObject.FindWithTag("Sonido");
        managerUsuarios = GameObject.FindWithTag("MUsu");
        crearLista();
    }

      public void crearLista()
    {
       
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;        
        GameObject g;
        int N = usuarios.Count;        

        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        for (int i = 0; i < N; i++)
        {            
            g = Instantiate(buttonTemplate, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = usuarios[i].Name;
            g.transform.GetChild(1).GetComponent<Text>().text = usuarios[i].Description;
            g.transform.GetChild(2).GetComponent<Image>().sprite = usuarios[i].Icon;            
            g.SetActive(true);
            g.GetComponent<IdUsuario>().id = usuarios[i].id;
        }
        
    }
    public void anadieUsuario()
    {
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        GameObject g;
        GameObject buttonTemplate = transform.GetChild(0).gameObject;
        g = Instantiate(buttonTemplate, transform);
        g.transform.GetChild(0).GetComponent<Text>().text = usuarios[usuarios.Count-1].Name;
        g.transform.GetChild(1).GetComponent<Text>().text = usuarios[usuarios.Count-1].Description;
        g.transform.GetChild(2).GetComponent<Image>().sprite = usuarios[usuarios.Count-1].Icon;
        int newId= darId();
        usuarios[usuarios.Count - 1].id = newId;
        g.GetComponent<IdUsuario>().id = newId;


        g.SetActive(true);
    }
    public void borrarLista()
    {
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        int N = usuarios.Count;
        for (int i = 0; i < N-1; i++)
        {            
            Destroy(gameObject.transform.GetChild(i+1).gameObject);
        }
    }
    public void alertaBorrarUsuario(int id)
    {
        idSeleccion = id;
        panelEliminarUsuario.SetActive(true);       
        Usuario usuario = managerUsuarios.GetComponent<ManagerUsuario>().getUsuarioByid(idSeleccion);
        panelEliminarUsuario.transform.GetChild(2).GetComponent<Text>().text = usuario.Name;
        panelEliminarUsuario.transform.GetChild(3).GetComponent<Text>().text = usuario.Description;
    }
    public void borrarUsuario()
    {
        
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        int N = usuarios.Count;
        

            for (int i = 0; i < N; i++)
            {            
                if(gameObject.transform.GetChild(i+1).gameObject.GetComponent<IdUsuario>().id == idSeleccion)
                {               
                Destroy(gameObject.transform.GetChild(i+1).gameObject);
                }
            }
        borrar = false;

        for (int i = 0; i < N; i++)
        {
            if (usuarios[i].id == idSeleccion)
            {                
                managerUsuarios.GetComponent<ManagerUsuario>().usuarios.Remove(managerUsuarios.GetComponent<ManagerUsuario>().usuarios[i]);
                break;
            }
            
        }
        managerUsuarios.GetComponent<ManagerUsuario>().guardarUsuarios();
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        canvas.transform.GetChild(6).gameObject.SetActive(true);
        panelEliminarUsuario.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(8);
    }
    public int darId()
    {
        int id = 0;
        List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
        int N = usuarios.Count;

        for(int i = 0; i < N; i++)
        {
            if(usuarios[i].id == id)
            {
                id++;
                i = -1;
            }
        }
        
        return id;
    }

    public void botonNuevoUsuario()
    {
        if (nombre.Length != 0)
        {
            List<Usuario> usuarios = managerUsuarios.GetComponent<ManagerUsuario>().usuarios;
            managerUsuarios.GetComponent<ManagerUsuario>().addUser(new Usuario(nombre, descripcion));            
            anadieUsuario();
            managerUsuarios.GetComponent<ManagerUsuario>().guardarUsuarios();
            sonidos.GetComponent<Sonidos>().repSonido(8);

        }
        else
        {
            sonidos.GetComponent<Sonidos>().repSonido(3);

        }
    }


    public void userNom(string n)
    {
        
        nombre = n;
    }
    public void userDesc(string d)
    {
        descripcion = d;
    }

    public void botonBorrarUsuario()
    {
        borrar = true;       

        canvas.transform.GetChild(3).gameObject.SetActive(false);
        canvas.transform.GetChild(4).gameObject.SetActive(false);
        canvas.transform.GetChild(5).gameObject.SetActive(false);
        canvas.transform.GetChild(6).gameObject.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(8);

    }
    public void botonSalirPanelUsuarios()
    {
        panelEliminarUsuario.SetActive(false);
        canvas.transform.GetChild(3).gameObject.SetActive(true);
        canvas.transform.GetChild(4).gameObject.SetActive(true);
        canvas.transform.GetChild(5).gameObject.SetActive(true);
        canvas.transform.GetChild(6).gameObject.SetActive(true);
        sonidos.GetComponent<Sonidos>().repSonido(1);

    }
    public void abrirPanelCaracteristicas(int id)
    {
        panelCaracteristicas.SetActive(true);
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        Usuario usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        panelCaracteristicas.transform.GetChild(2).GetComponent<Text>().text = usuario.Name;
        panelCaracteristicas.transform.GetChild(3).GetComponent<Text>().text = usuario.Description;
        if (usuario.estadisticas.textInicial)
        {           
            panelCapacidades.SetActive(true);
            string valoresCapacidades = string.Format(usuario.getMemoria() + "{0}{0}" + usuario.getLenguaje() + "{0}{0}" + usuario.getPercepcion() + "{0}{0}" + usuario.getAtencion() + "{0}{0}" + usuario.getGnosias() + "{0}{0}" + usuario.getPraxias() + "{0}{0}" + usuario.getOrientacion() + "{0}{0}" + usuario.getCalculo(), Environment.NewLine);

            panelCapacidades.transform.GetChild(2).GetComponent<Text>().text = valoresCapacidades;           
        }
    }
    public void cerrarCaracteristicas()
    {
        panelCaracteristicas.SetActive(false);
        sonidos.GetComponent<Sonidos>().repSonido(2);
    }

}

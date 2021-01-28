using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ejemplojson : MonoBehaviour
{
    string filePath;
    string jsonString;
    ListaUsuarios listausuarios;

    public void Start()
    {
        listausuarios = new ListaUsuarios();
    }
    public List<Usuario> cargarUsuarios()
    {

        filePath = Application.dataPath + "/TextFile1.json";
        jsonString = File.ReadAllText(filePath);
        listausuarios = JsonUtility.FromJson<ListaUsuarios>(jsonString);

        return listausuarios.usuarios;

    }
   public void guardarUsuario(List<Usuario> usu)
    {
        ListaUsuarios LUsu = new ListaUsuarios();
        LUsu.usuarios = usu;
        
        filePath = Application.dataPath + "/TextFile1.json";
        jsonString = JsonUtility.ToJson(LUsu,true);
        File.WriteAllText(filePath, jsonString);
    }
}
[System.Serializable]
public class ListaUsuarios
{
  
    public List<Usuario> usuarios;

}
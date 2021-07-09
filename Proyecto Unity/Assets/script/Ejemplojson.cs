using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Ejemplojson : MonoBehaviour
{
    string filePath;
    string jsonString;
    ListaUsuarios listausuarios;

    
    public List<Usuario> cargarUsuarios()
    {

        listausuarios = new ListaUsuarios();
        

        
        string patch = Application.persistentDataPath;
        string json = File.ReadAllText(patch + "/" + "TextFile1.json");
        JsonUtility.FromJsonOverwrite(json, listausuarios);
        return listausuarios.usuarios;
        

        /*
        filePath = Application.dataPath + "/TextFile1.json";
        jsonString = File.ReadAllText(filePath);
        listausuarios = JsonUtility.FromJson<ListaUsuarios>(jsonString);

        if (listausuarios==null)
        {
            return new List<Usuario>();
        }
        else
        {
            return listausuarios.usuarios;
        }

        */

    }
   public void guardarUsuario(List<Usuario> usu)
    {

        ListaUsuarios LUsu = new ListaUsuarios();
        LUsu.usuarios = usu;

        
        string patch = Application.persistentDataPath;
        string json = JsonUtility.ToJson(LUsu);
        File.WriteAllText(patch+"/" + "TextFile1.json", json);
        

        
        /*
        filePath = Application.dataPath + "/TextFile1.json";
        jsonString = JsonUtility.ToJson(LUsu,true);
        File.WriteAllText(filePath, jsonString);
        */
    }
}
[System.Serializable]
public class ListaUsuarios
{
  
    public List<Usuario> usuarios;

}
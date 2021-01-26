using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Usuario 
{
    public Usuario(string nombre, string detalles)
    {
        Name = nombre;
        Description = detalles;
    }
    public string Name;
    public string Description;
    public Sprite Icon;
    public int id;
   
}


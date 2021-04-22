using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EsEstadiscitcas : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelDatos;
    int id;
    Usuario usuario;


    public void usuarioPulsado(int i)
    {
        id = i;
        panel.SetActive(true);
        GameObject managerUsuario = GameObject.FindWithTag("MUsu");
        usuario = managerUsuario.GetComponent<ManagerUsuario>().getUsuarioByid(id);
        panel.transform.GetChild(0).GetComponent<Text>().text= usuario.Name;
    }
    public void pulsarCapacidad(int num)
    {
        panelDatos.SetActive(true);
        panelDatos.transform.GetChild(1).GetComponent<Text>().text = usuario.getNumIntentos(num).ToString();
        panelDatos.transform.GetChild(3).GetComponent<Text>().text = usuario.getNivelMax(num).ToString();
        panelDatos.transform.GetChild(5).GetComponent<Text>().text = usuario.getNivelEstadistica(num).ToString();
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgregarObjetosPorLinea : MonoBehaviour
{
    public GameObject linea; // Objeto que se agregará debajo de cada línea de texto

    void Start()
    {
        // Obtener el texto del objeto de texto
        string texto = GetComponent<Text>().text;

        // Dividir el texto en líneas
        string[] lineas = texto.Split('\n');

        // Posición inicial del primer objeto
        Vector3 posicion = transform.position;

        // Crear un objeto para cada línea
        for (int i = 0; i < lineas.Length; i++) {
            // Crear la instancia del objeto
            GameObject objeto = Instantiate(linea);

            // Posicionar el objeto debajo de la línea anterior
            posicion.y -= 1;

            // Asignar la posición al objeto
            objeto.transform.position = posicion;

            // Asignar el padre del objeto
            objeto.transform.parent = transform;

            // Obtener el componente Text del objeto
            Text textoObjeto = objeto.GetComponent<Text>();

            // Asignar el texto al objeto
            textoObjeto.text = lineas[i];
        }
    }
}
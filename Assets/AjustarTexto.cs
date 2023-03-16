using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjustarTexto : MonoBehaviour
{
    public Text texto;
    public int lineasMaximas = 10000; // número máximo de líneas permitidas
    public float alturaLinea = 25f; // altura de una línea de texto en píxeles

    void Start()
    {
        AjustarAlturaTexto();
    }

    void AjustarAlturaTexto()
    {
        int numLineas = texto.cachedTextGenerator.lineCount; // obtiene el número de líneas de texto generado
        int numLineasAjustadas = Mathf.Clamp(numLineas, 27, lineasMaximas); // limita el número de líneas permitidas
        float alturaTexto = numLineasAjustadas * alturaLinea; // calcula la altura total del texto
        texto.rectTransform.sizeDelta = new Vector2(texto.rectTransform.sizeDelta.x, alturaTexto); // ajusta la altura del rectángulo del texto
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Game : MonoBehaviour
{
    private float tiempoTranscurrido = 0.0f;
    public TextMeshProUGUI textoTiempo; // Usa TextMeshProUGUI en lugar de Text

    private void Update()
    {
        tiempoTranscurrido += Time.deltaTime;
        ActualizarTextoTiempo();
    }

    private void ActualizarTextoTiempo()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}

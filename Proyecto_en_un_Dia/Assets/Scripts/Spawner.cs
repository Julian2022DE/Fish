using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private float spawnTime;

    [SerializeField]public GameObject [] pezPrefabs;

    void Start()
    {
        
    }

    void Update()
    {
        spawnTime -= Time.deltaTime;

        if (spawnTime <= 0)
        {
            // Elije un índice aleatorio del array pezPrefabs
            int indiceAleatorio = Random.Range(0, pezPrefabs.Length);

            // Instancia el prefab seleccionado en la posición aleatoria
            Instantiate(pezPrefabs[indiceAleatorio], GetSpawnposition(), Quaternion.identity);

            Debug.Log("aparece");
            spawnTime = 2f;
        }
    }

    private Vector3 GetSpawnposition() 
    {
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        float aleatorioVertical = Random.Range(-limitesPantalla.y, limitesPantalla.y);
        float aleatorioHorizontal = Random.Range(0, 2) == 0 ? -limitesPantalla.x -1 : limitesPantalla.x + 1;

    
        return new Vector3(aleatorioHorizontal, aleatorioVertical, 0);
    }
}

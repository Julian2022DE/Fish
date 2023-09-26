using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]private float spawnTime;

    [SerializeField]private GameObject pezPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;

        if (spawnTime <= 0)
        {
            Instantiate(pezPrefab, GetSpawnposition(), Quaternion.identity);
            spawnTime = 1.5f;
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

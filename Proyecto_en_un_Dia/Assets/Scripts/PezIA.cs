using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezIA : MonoBehaviour
{
    [Header("Estadisticas")]
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Transform pezSpriteIA;
    private int dir = 1;

    Vector2 limitesPantalla;

    // Start is called before the first frame update
    void Start()
    {
        Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));


        if (transform.position.x <= limitesPantalla.x / 2)
        {
            dir = 1;
            pezSpriteIA.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else 
        {
            dir = -1;
            pezSpriteIA.rotation = Quaternion.Euler(new Vector3(0, 100, 0));
        }

        float size = Random.Range(0.5f, 3f);

        transform.localScale = new Vector3(size, size, size);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.right * dir * Time.deltaTime * speed);

        if (transform.position.x <= - limitesPantalla.x -2 || transform.position.x > limitesPantalla.x + 2)
        {
            Destroy(gameObject);
        }
    }
}

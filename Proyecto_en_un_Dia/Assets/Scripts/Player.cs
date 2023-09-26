using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    //[SerializeField] private float velocidad = 3;

    [Header("Referencias")]
    [SerializeField] private Transform pezSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();

        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, limitesPantalla.x * -1, limitesPantalla.x), Mathf.Clamp(transform.position.y, limitesPantalla.y * -1, limitesPantalla.y), 0);
    }

    public void Movimiento() 
    {
        float inputVertical = Input.GetAxis("Vertical") * Time.deltaTime;
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime;

        transform.position = transform.position + new Vector3(inputHorizontal, inputVertical, 0);

        Rotacion(inputHorizontal);
    }
    public void Rotacion(float inputHorizontal) 
    {
        if (inputHorizontal == 0) return;
        if (inputHorizontal < 0)
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 100, 0));
        }
        else
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}

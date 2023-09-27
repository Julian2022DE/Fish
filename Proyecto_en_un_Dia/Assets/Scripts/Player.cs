using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float velocidad = 5.0f;
    [SerializeField] private int pecesComidos = 0;
    [SerializeField] private float tamano;

    [Header("Referencias")]
    [SerializeField] private Transform pezSprite;
    [SerializeField] private SpriteRenderer pezSprite_render;

    [SerializeField] private TextMeshProUGUI textoPecesComidos;

    public AudioClip comer;
    public GameObject Ganar;
    public GameObject Perder;
    public GameObject Game;
    public GameObject GameManager;


    private void Start()
    {
        tamano = transform.localScale.x;
    }
    void Update()
    {
        Movimiento();
        LimitarPosicionPantalla();
    }

    public void Movimiento()
    {
        float inputVertical = Input.GetAxis("Vertical");
        float inputHorizontal = Input.GetAxis("Horizontal");

        // Multiplicamos por la velocidad para ajustar la velocidad de movimiento
        Vector3 movimiento = new Vector3(inputHorizontal, inputVertical, 0) * velocidad * Time.deltaTime;

        // Aplicamos el movimiento
        transform.Translate(movimiento);

        Rotacion(inputHorizontal);
    }

    public void Rotacion(float inputHorizontal)
    {
        if (inputHorizontal == 0) return;

        // Rotamos el sprite
        if (inputHorizontal < 0)
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }

    public void LimitarPosicionPantalla()
    {
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        // Limitamos la posición del pez a los bordes de la pantalla
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -limitesPantalla.x, limitesPantalla.x),
            Mathf.Clamp(transform.position.y, -limitesPantalla.y, limitesPantalla.y),
            0
        );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Pez"))
        {
            PezIA pezAI = collision.gameObject.GetComponent<PezIA>();
            if(tamano >= pezAI.GetTamano())
            {
                pecesComidos++;
                ActualizarTextoPecesComidos();

                transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
                tamano = transform.localScale.x;
                AudioSource.PlayClipAtPoint(comer, gameObject.transform.position);
                Destroy(collision.gameObject);

                if(pecesComidos >= 25)
                {
                    Ganar.SetActive(true);
                    GameManager.SetActive(false);
                    Game.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Game Over");
                Destroy(gameObject);
                Perder.SetActive(true);
                GameManager.SetActive(false);
                Game.SetActive(false);

            }

        }
    }
    private void ActualizarTextoPecesComidos()
    {
        if (textoPecesComidos != null)
        {
            textoPecesComidos.text = pecesComidos.ToString();
        }
    }
}
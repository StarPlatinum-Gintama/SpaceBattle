using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    Rigidbody2D rb;

    //Referenciamos el prefab de la bala y el de los enemigos para poder utilizarlos
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject enemyShip;

    [SerializeField] float speed;
    void Start()
    {
        //Almacenamos el RigidBody de las balas en una variable y la inicializamos
        rb = bullet.GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        //Le aplicamos una fuerza al Rigidbody2D hacia arriba para q vaya volando 
        rb.AddForce(Vector2.up * speed); 
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.tag == "ColliderTop")
        {
            //Si colisiona con la parte superior de la pantalla, se destruye la bala
            Destroy (gameObject);
        }

        if (collision.gameObject.tag == "Enemy")
        {
            //Si colisiona con un enemigo, se destruye el enemigo
            Destroy (collision.gameObject);
        }
    }
}

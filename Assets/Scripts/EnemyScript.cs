using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rbEnemy;
    [SerializeField] GameObject enemy;
    [SerializeField] float enemySpeed = 5;

    void Start()
    {
        rbEnemy = enemy.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
       
        rbEnemy.AddForce (Vector2.down * enemySpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ColliderBottom")
        {
           
            Destroy(enemy);
            Time.timeScale = 0f; //Pauso el tiempo para que se pare el juego 
        }

        if (collision.gameObject.tag == "Spaceship")
        {

            Destroy(enemy);
            Time.timeScale = 0f; //Pauso el tiempo para que se pare el juego 
        }
    }

}

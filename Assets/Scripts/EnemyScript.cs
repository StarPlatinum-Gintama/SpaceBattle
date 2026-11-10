using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Rigidbody2D rbEnemy;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject spaceship;
    [SerializeField] GameObject enemyBullet;
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
            Destroy(gameObject);
            Debug.Log("Game Over");

            //Me gustaria destruir la nave y mostrar un texto q diga game over, igual con otra escena 

        }
    }
}

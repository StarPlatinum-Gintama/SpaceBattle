using System.Collections;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject controller;
    [SerializeField] GameObject enemies;
    Rigidbody2D rbEnemy;

    bool CanSpawn = true;

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(5f);
        CanSpawn = true;
    }

    private void InstantiateEnemy()
    {
        GameObject newEnemies = Instantiate(enemies, new Vector2(Random.Range(-7f,7f), 8), Quaternion.identity);
        CanSpawn = false;

        StartCoroutine(SpawnEnemy());
    }


    void Start()
    {
        rbEnemy = enemies.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanSpawn)
        {
            InstantiateEnemy();
        }
    }


}

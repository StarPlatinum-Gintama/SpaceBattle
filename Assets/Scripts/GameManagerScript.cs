using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] GameObject controller;
    [SerializeField] GameObject enemies;
    [SerializeField] GameObject spaceship;
    [SerializeField] GameObject gameOver;
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
        Time.timeScale = 1f;
        rbEnemy = enemies.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (CanSpawn)
        {
            InstantiateEnemy();
        }

        if (Time.timeScale == 0f)
        {
            spaceship.SetActive(false);
            gameOver.SetActive(true);

        }

    }
   
    public void StartNewGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}

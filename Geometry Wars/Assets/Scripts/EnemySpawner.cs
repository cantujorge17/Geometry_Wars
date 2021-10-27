using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] spawnPoints;

    private bool playerNear;
    private bool enemiesSpawning;

    // Start is called before the first frame update
    void Start()
    {
        playerNear = false;
        enemiesSpawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNear)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !enemiesSpawning)
            {
                enemiesSpawning = true;
                SpawnEnemies();
            }
        }

    }

    private void SpawnEnemies()
    {
        int spot = 0;

        while (spot < enemies.Length)
        {
            Instantiate(enemies[spot], spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)].transform.position, transform.rotation);
            spot++;
        }
        enemiesSpawning = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerNear = false;
        }
    }
}

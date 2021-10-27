using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int[] enemiesLeft;   //Enemy number - 1 is the amount of enemies left
    private bool levelComplete;
    private bool objectiveComplete;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        levelComplete = false;
        objectiveComplete = false;
        index = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerMovement.alive)
        {
            StartCoroutine(RestartLevel());
        }

        if(levelComplete)
        {
            StartCoroutine(NextLevel());
        }

        //Skip level
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(index < 19)
            {
                SceneManager.LoadScene(index + 1);
            }
            else
            {
                SceneManager.LoadScene(0);
            }
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(index > 0)
            {
                SceneManager.LoadScene(index - 1);
            }
            else
            {
                SceneManager.LoadScene(19);
            }
        }
    }

    private void CheckEnemiesLeft()
    {
        objectiveComplete = true;
        for(int i = 0; i < enemiesLeft.Length; i++)
        {
            if(enemiesLeft[i] > 0)
            {
                objectiveComplete = false;
            }
        }

        if(objectiveComplete)
        {
            levelComplete = true;
        }
    }

    public void EnemyOneKilled()
    {
        enemiesLeft[0] -= 1;
        CheckEnemiesLeft();
    }

    public void EnemyTwoKilled()
    {
        enemiesLeft[1] -= 1;
        CheckEnemiesLeft();
    }

    public void EnemyThreeKilled()
    {
        enemiesLeft[2] -= 1;
        CheckEnemiesLeft();
    }

    public void EnemyFourKilled()
    {
        enemiesLeft[3] -= 1;
        CheckEnemiesLeft();
    }

    public void EnemyFiveKilled()
    {
        enemiesLeft[4] -= 1;
        CheckEnemiesLeft();
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

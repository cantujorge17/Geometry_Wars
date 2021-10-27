using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThreeMovement : MonoBehaviour
{
    private float speed;
    private int health;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.05f;
        health = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.alive = false;
        }
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            health--;

            if(health <= 0)
            {
                gameManager.GetComponent<GameManager>().EnemyThreeKilled();
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoMovement : MonoBehaviour
{
    private float speed;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.03f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector2(speed, 0));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.alive = false;
        }
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            gameManager.GetComponent<GameManager>().EnemyTwoKilled();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFourMovement : MonoBehaviour
{
    public GameObject player;
    private float speed;
    private bool charging;
    public GameObject gameManager;


    // Start is called before the first frame update
    void Start()
    {
        speed = 0.02f;
        charging = false;
        StartCoroutine(TimeBeforeCharging());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(PlayerMovement.alive)
        {
            if (!charging)
            {
                var direction = player.transform.position - transform.position;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

                transform.Translate(Vector2.right * speed);
            }
            else
            {
                Charging();
            }
        }
    }

    IEnumerator TimeBeforeCharging()
    {
            yield return new WaitForSeconds(3f);
            charging = true;
    }

    void Charging()
    {
        speed += 0.01f;
        transform.Translate(Vector2.right * speed);

        if(speed > 0.5f)
        {
            charging = false;
            speed = 0.02f;
            StartCoroutine(TimeBeforeCharging());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerMovement.alive = false;
        }
        if (collision.gameObject.tag == "PlayerProjectile")
        {
            gameManager.GetComponent<GameManager>().EnemyFourKilled();
            Destroy(gameObject);
        }
    }
}

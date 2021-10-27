using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFiveMovement : MonoBehaviour
{
    public GameObject projectile;
    public GameObject[] points;
    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 0.1f));
    }

    IEnumerator Shoot()
    {
        while(1 == 1)
        {
            yield return new WaitForSeconds(3f);

            int spot = 0;
            while(spot < points.Length)
            {
                Instantiate(projectile, points[spot].transform.position, points[spot].transform.rotation);
                spot++;
            }
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
            gameManager.GetComponent<GameManager>().EnemyFiveKilled();
            Destroy(gameObject);
        }
    }
}

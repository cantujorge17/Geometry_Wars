using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "EnemyProjectile")
        {
            speed = 0.12f;
        }
        else
        {
            speed = 0.2f;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && gameObject.tag == "EnemyProjectile")
        {
            PlayerMovement.alive = false;
        }

        StartCoroutine(GetReadyToDie());
    }

    //Possibly remove this
    IEnumerator GetReadyToDie()
    {
        yield return new WaitForSeconds(0.01f);
        Destroy(gameObject);
    }

}

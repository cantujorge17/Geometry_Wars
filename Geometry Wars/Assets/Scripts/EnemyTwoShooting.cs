using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTwoShooting : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        while (1 == 1)   //Change the condition
        {
            yield return new WaitForSeconds(2f);
            Instantiate(projectile, transform.position, transform.rotation);
        }
    }
}

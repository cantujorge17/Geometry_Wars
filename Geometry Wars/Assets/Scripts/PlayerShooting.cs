using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private int cooldown;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0) && cooldown <= 0)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            cooldown = 30;
        }

        if (cooldown > 0)
        {
            cooldown--;
        }
    }
}

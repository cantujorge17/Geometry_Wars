using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEnemiesLeft : MonoBehaviour
{
    public int enemy;
    public GameObject gameManager;
    public TMP_Text txt;

    // Start is called before the first frame update
    void Start()
    {
        txt.text = "x " + gameManager.GetComponent<GameManager>().enemiesLeft[enemy - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.GetComponent<GameManager>().enemiesLeft[enemy - 1] > 0)
        {
            txt.text = "x " + gameManager.GetComponent<GameManager>().enemiesLeft[enemy - 1];
        }
        else
        {
            txt.text = "x 0";
        }
    }
}

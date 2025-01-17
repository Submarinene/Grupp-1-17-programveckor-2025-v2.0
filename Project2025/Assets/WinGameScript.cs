using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGameScript : MonoBehaviour
{
    GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (boss.GetComponent<EnemyHealth>().currentHealth <= 0)
        {
            
        }
    }
}

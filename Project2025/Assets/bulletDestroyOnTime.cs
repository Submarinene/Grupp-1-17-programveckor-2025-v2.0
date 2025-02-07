using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class bulletDestroyOnTime : MonoBehaviour
{

    public float timer = 5f;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = timer;
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0) { Destroy(gameObject); }
    }
}

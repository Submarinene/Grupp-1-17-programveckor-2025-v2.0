using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleParticleSystemMovement : MonoBehaviour
{
    public GameObject followingThruster;
    Transform thrusterTransform;

    // Start is called before the first frame update
    void Start()
    {
        thrusterTransform = followingThruster.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = thrusterTransform.position;
        transform.rotation = thrusterTransform.rotation;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterFire : MonoBehaviour
{
    public GameObject mainBody;
    MainBodyMovement mainBodyMovement;
    SpriteRenderer spriteRenderer;

    public float fireScale = 0;

    private void Start()
    {
        mainBodyMovement = mainBody.GetComponent<MainBodyMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = new Vector3(mainBodyMovement.gravityScale * 0.5f, mainBodyMovement.gravityScale * 5, 1);
        transform.localPosition = new Vector3(0, mainBodyMovement.gravityScale * -0.8f - 1, 0);
        spriteRenderer.color = new Color(0, 1, 1, mainBodyMovement.gravityScale);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodySpotlight : MonoBehaviour
{
    public GameObject mainBody;
    public Vector3 relativeToBody;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = mainBody.transform.rotation;
        transform.position = new Vector3(mainBody.transform.position.x + transform.up.x * relativeToBody.x, mainBody.transform.position.y + transform.up.y * relativeToBody.y, mainBody.transform.position.z + transform.up.z * relativeToBody.z);
    }
}

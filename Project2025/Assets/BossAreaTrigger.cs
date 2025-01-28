using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BossAreaTrigger : MonoBehaviour
{
    TheodorBossShooting theodorBossShooting;
    public GameObject cancerCell;

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject collisionObject = other.gameObject;

        theodorBossShooting = cancerCell.GetComponent<TheodorBossShooting>();

        theodorBossShooting.EnterTrigger(collisionObject);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject collisionObject = other.gameObject;

        theodorBossShooting = cancerCell.GetComponent<TheodorBossShooting>();

        theodorBossShooting.ExitTrigger(collisionObject);
    }
}

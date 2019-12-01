using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotaeParts : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Finish")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}

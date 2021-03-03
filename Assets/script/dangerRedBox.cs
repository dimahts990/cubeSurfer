using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangerRedBox : MonoBehaviour
{
    private bool active = true;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<box>() && !collision.transform.GetComponent<box>().free && active)
        {
            active = false;
            Transform box = collision.transform;
            box.SetParent(null);
            box.GetComponent<box>().free = true;
        }
    }
}

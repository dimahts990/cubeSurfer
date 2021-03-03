using UnityEngine;

public class bezierZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("вошел в зону");
        other.transform.parent.parent.GetComponent<playerMove>().rotate = true;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.parent.parent.GetComponent<playerMove>().rotate = false;
    }
}

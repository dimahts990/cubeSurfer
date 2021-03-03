using UnityEngine;

public class addBoxTrigger : MonoBehaviour
{
    [SerializeField]
    private boxAdd _boxAdd;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
    }

    private void OnTriggerEnter(Collider other) =>
        _boxAdd.AddBoxSys(other.transform);

}

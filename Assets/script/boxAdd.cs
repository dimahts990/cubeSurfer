using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxAdd : MonoBehaviour
{
    [SerializeField]
    private Transform player;
   
    public void AddBoxSys(Transform _box)
    {
        if (_box.GetComponent<box>() && _box.GetComponent<box>().free)
        {
            _box.GetComponent<box>().free = false;
            player.position += Vector3.up;
            _box.SetParent(player);
            _box.position = new Vector3(player.position.x, player.position.y - 1.1f, player.position.z);
            
        }
    }
}

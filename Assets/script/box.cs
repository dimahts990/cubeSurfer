using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    public bool free = true;

    private void Update()
    {
        if (!free)
        {
            Transform _player = transform.parent;
            transform.position = new Vector3(_player.position.x, transform.position.y, _player.position.z);
            transform.rotation = Quaternion.identity;
        }
    }

    /*private bool free=true;
    private Transform player;

    private void Update()
    {
        if (!free)
        {
            transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<boxAdd>() && free)
        {
            player = collision.transform;
            player.position += Vector3.up * 2f;
            transform.localPosition = Vector3.zero;
            transform.SetParent(player);
            free = false;
        }
        *//*if (collision.transform.GetComponent<boxAdd>() && free)
        {
            player = collision.transform;
            free = false;
            player.position += new Vector3(0, 1f, 0);
            //transform.localPosition = new Vector3(0, transform.position.y, 0);
    '''''''''''''''''''''''''''''''''''''''''
            transform.SetParent(player);
            
        }else if(collision.transform.GetComponent<box>() && free)
        {
            player = collision.transform.parent;
            free = false;
            player.position += new Vector3(0, 1f, 0);
            //transform.localPosition = new Vector3(0, transform.position.y, 0);
            transform.SetParent(player);
        }*//*
    }*/
}
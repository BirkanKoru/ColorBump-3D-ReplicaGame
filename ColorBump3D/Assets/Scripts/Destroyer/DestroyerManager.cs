using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerManager : MonoBehaviour
{
    private CollideManager collideManager;

    private void Start()
    {
        collideManager = GameObject.FindWithTag("Player").GetComponent<CollideManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destroys every object that touches

        if (other.tag == "Player")
        {
            collideManager.playerIsAlive = false;
        }

        Destroy(other.gameObject);
    }
}

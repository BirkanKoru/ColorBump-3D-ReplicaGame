using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollideManager : MonoBehaviour
{
    public bool playerIsAlive = true;
    public bool finishStage = false;

    private Material playerMat;
    private Material objectMat;

    [SerializeField] private GameObject playerCracked = null;
    private Renderer[] playerCrackedPieces;

    private void Start()
    {
        playerMat = GetComponent<Renderer>().material;
        playerCrackedPieces = playerCracked.GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player touches object
        if(other.tag == "Enemy")
        {
            PlayerTouchDifferentMaterial(other.gameObject);
        }

        //While playing game If player changes the color
        if(other.tag == "Ally")
        {
            PlayerTouchDifferentMaterial(other.gameObject);
        }

        //When player finish the level
        if(other.tag == "Finish")
        {
            finishStage = true;
            Time.timeScale = 0.1f;
        }
    }

    private void PlayerTouchDifferentMaterial(GameObject otherObject)
    {
        playerMat = GetComponent<Renderer>().material;
        objectMat = otherObject.GetComponent<Renderer>().material;

        if (playerMat.name != objectMat.name)
        {

            //Painting CrackedObject Materials
            foreach (Renderer piece in playerCrackedPieces)
            {
                piece.material = playerMat;
            }

            playerIsAlive = false;
            //Destroy player and create cracked player
            Instantiate(playerCracked, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

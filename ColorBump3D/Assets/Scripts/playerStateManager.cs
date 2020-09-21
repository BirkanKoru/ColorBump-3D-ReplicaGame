using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStateManager : MonoBehaviour
{
    private GameObject player;
    private CollideManager collideManager;

    private ForwardMovement cameraMovement;

    [SerializeField] private GameObject restartButton = null;
    [SerializeField] private GameObject nextLevelButton = null;
    

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        collideManager = player.GetComponent<CollideManager>();
    }
    

    void Update()
    {
        //If the player dies
        if (!collideManager.playerIsAlive)
        {
            cameraMovement = Camera.main.GetComponent<ForwardMovement>();
            cameraMovement.enabled = false;
            StartCoroutine(restartGame());
        }

        //If the player finishes the level
        if (collideManager.finishStage)
        {
            StartCoroutine(finishStage());
        }
    }

    private IEnumerator restartGame()
    {
        //Restart Button SetActive
        yield return new WaitForSeconds(2f);
        restartButton.SetActive(true);
    }

    private IEnumerator finishStage()
    {
        //Next Level Button SetActive
        yield return new WaitForSeconds(0.3f);
        nextLevelButton.SetActive(true);
    }
}

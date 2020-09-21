using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private ColorManager colorManager;
    private Material playerAndAllyMat;
    private Material enemyMat;
    
    void Start()
    {
        colorManager = GameObject.FindWithTag("ColorController").GetComponent<ColorManager>();
        playerAndAllyMat = colorManager.playerAndAllyMat;
        enemyMat = colorManager.enemyMat;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Switching playerAndAllyMat And enemyMat
        if(other.tag == "Player" || other.tag == "Ally")
        {
            other.GetComponent<Renderer>().material = enemyMat;
        }

        if(other.tag == "Enemy")
        {
            other.GetComponent<Renderer>().material = playerAndAllyMat;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Material[] colors = null;
    public Material playerAndAllyMat;
    public Material enemyMat;
    private int randomNum, randomNum2;

    private GameObject player;
    private GameObject[] allyObjects;
    private GameObject[] enemyObjects;

    private void Awake()
    {
        //Restart Time Scale
        Time.timeScale = 1f;

        //Picking randomly Player-Ally And Enemy Colors
        randomNum = Random.Range(0, colors.Length);
        playerAndAllyMat = colors[randomNum];
        randomNum2 = Random.Range(0, colors.Length);
        while (randomNum == randomNum2)
        {
            randomNum2 = Random.Range(0, colors.Length);
        }
        enemyMat = colors[randomNum2];

        //Painting Player-Ally Materials
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Renderer>().material = playerAndAllyMat;

        allyObjects = GameObject.FindGameObjectsWithTag("Ally");
        foreach(GameObject allyObject in allyObjects)
        {
            allyObject.GetComponent<Renderer>().material = playerAndAllyMat;
        }

        //Painting Enemy Materials
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemyObject in enemyObjects)
        {
            enemyObject.GetComponent<Renderer>().material = enemyMat;
        }
    }
}

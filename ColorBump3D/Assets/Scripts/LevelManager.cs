using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private int totalScene;
    private int currentSceneIndex;
    [SerializeField] private Text infoTxt = null;

    void Update()
    {
        totalScene = SceneManager.sceneCountInBuildSettings;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        //If player finish the last level
        if(totalScene == (currentSceneIndex + 1))
        {
            infoTxt.text = "CONGRATULATIONS";
        }
        else
        {
            infoTxt.text = "NEXT LEVEL";
        }
    }
}

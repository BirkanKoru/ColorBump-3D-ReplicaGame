using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricColorManager : MonoBehaviour
{
    private ColorManager colorManager;
    private LineRenderer lineRenderer;

    private Material enemyMat;

    // Start is called before the first frame update
    void Start()
    {
        //Painting electric color
        colorManager = GameObject.FindWithTag("ColorController").GetComponent<ColorManager>();
        enemyMat = colorManager.enemyMat;

        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = enemyMat.color;
        lineRenderer.endColor = enemyMat.color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyAttack : MonoBehaviour
{
    [SerializeField] private GameObject monkeyPrefab = null;
    private bool isRaining = true;

    private Material enemyMaterial;
    private float timer = 0f;

    private ForwardMovement forwardMovement = null;
    private bool isPlaying = false;

    //Time between attack
    [SerializeField] private int minTime = 2;
    [SerializeField] private int maxTime = 6;
    
    void Start()
    {
        enemyMaterial = GameObject.FindWithTag("ColorController").GetComponent<ColorManager>().enemyMat;
        forwardMovement = GameObject.FindWithTag("Player").GetComponent<ForwardMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //When player is playing, it starts
        isPlaying = forwardMovement.isPlaying;

        if (isPlaying)
        {
            if (isRaining)
            {
                StartCoroutine(MonkeyAttackManager());
                isRaining = false;
            }
        }
    }

    private IEnumerator MonkeyAttackManager()
    {
        //Random position, Painting monkeys
        for (int i = 0; i < 5; i++)
        {
            Vector3 dropPoint = new Vector3(Random.Range(5, -5), transform.position.y, Random.Range(transform.position.z + 10, transform.position.z - 10));
            monkeyPrefab.GetComponent<Renderer>().material = enemyMaterial;
            Instantiate(monkeyPrefab, dropPoint, Quaternion.Euler(-90, 180, 0));
        }

        timer = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(timer);
        isRaining = true;
    }
}

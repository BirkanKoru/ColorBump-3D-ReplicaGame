using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForwardMovement : MonoBehaviour
{

    private float speed = 2.5f;
    public bool isPlaying = false;

    // Update is called once per frame
    void Update()
    {
        //For monkeyAttack
        if(Input.touchCount > 0)
        {
            isPlaying = true;
        }

        //Camera, Player and MonkeyAttack Movement
        if (isPlaying)
        {
            transform.position += new Vector3(0, 0, 1f) * speed * Time.deltaTime;
        }
    }
}

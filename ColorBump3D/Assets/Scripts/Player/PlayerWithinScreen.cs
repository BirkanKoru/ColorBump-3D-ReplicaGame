using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWithinScreen : MonoBehaviour
{

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y,
            Mathf.Clamp(transform.position.z, Camera.main.transform.position.z + 27f, Camera.main.transform.position.z + 52f));
    }
}

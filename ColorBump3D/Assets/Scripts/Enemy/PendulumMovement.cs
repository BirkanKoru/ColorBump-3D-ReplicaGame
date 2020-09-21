using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMovement : MonoBehaviour
{

    Quaternion start, end;

    [SerializeField] private float angle = 90f;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float startTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        start = pendulumRotation(angle);
        end = pendulumRotation(-angle);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(start, end, (Mathf.Sin(startTime * speed + Mathf.PI / 2) + 1f) / 2f);
    }

    private Quaternion pendulumRotation(float angle)
    {
        Quaternion pendulumRotation = transform.rotation;
        float angleZ = pendulumRotation.eulerAngles.z + angle;
        if(angleZ > 180)
        {
            angleZ -= 360;
        } else if(angleZ < -180)
        {
            angleZ += 360;
        }

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }
}

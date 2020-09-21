using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Touch touch;
    [SerializeField] private float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                rb.AddForce(new Vector3(touch.deltaPosition.x * speed * Time.deltaTime, 
                    0f, touch.deltaPosition.y * speed * Time.deltaTime));
            }
        }

    }
}

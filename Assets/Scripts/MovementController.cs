using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Move();
       Rotation();
    }

    void Move()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift))
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 100, Time.deltaTime * 2);
            transform.position += transform.forward * vertical * 3f * Time.deltaTime;
            transform.position += transform.right * horizontal * 3f * Time.deltaTime;
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 70, Time.deltaTime * 2);
            transform.position += transform.forward * vertical  * Time.deltaTime;
            transform.position += transform.right * horizontal  * Time.deltaTime;
        }
    }

    void Rotation()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(0, Input.GetAxis("Mouse X") * 10f, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator ctr;
    private Rigidbody rig;
    void Start()
    {
        rig = GetComponent<Rigidbody>();
        ctr.SetBool("space", false);
        ctr.SetBool("shift", false);
        ctr.SetBool("isMove", false);
    }

    // Update is called once per frame
    void Update()
    {
        ctr.SetFloat("yAxis" , transform.position.y);
        ctr.SetFloat("vertical", Input.GetAxis("Vertical"));
        ctr.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) 
        {
            ctr.SetBool("isMove", true);
        }
        else
        {
            ctr.SetBool("isMove", false);
        }
        ctr.SetBool("shift" , Input.GetKey(KeyCode.LeftShift));
        if (Input.GetKeyDown(KeyCode.Space) && !ctr.GetCurrentAnimatorStateInfo(0).IsTag("jump"))
        {
            rig.AddForce(transform.up * 3f, ForceMode.Impulse);
            ctr.SetBool("space" , true);
            
        }
        else
        {
            ctr.SetBool("space" , false);
        }
    }
}

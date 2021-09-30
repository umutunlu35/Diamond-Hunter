using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public FloatingJoystick floatingJoystick;
    private Rigidbody rigidBody;
    private float h1 , v1;
    private Animator animator;
    Vector3 direction;

    private void Start()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void FixedUpdate()
    {

        //player movement//
        h1 = floatingJoystick.Horizontal;
        v1 = floatingJoystick.Vertical;
        
        direction = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        transform.position = transform.position + direction * speed * Time.fixedDeltaTime;


        //player rotate to move direction//
        if (h1 == 0f && v1 == 0f)
        {
            Vector3 currentRotation = rigidBody.transform.localEulerAngles;
            Vector3 homeRotation = Vector3.zero;
        }
        else
        {
            rigidBody.transform.localEulerAngles = new Vector3(0f, Mathf.Atan2(h1, v1) * 180 / Mathf.PI, 0f);
        }

        //Player Run Animation//
        if ((Mathf.Abs(h1) > 0.2 || Mathf.Abs(v1) > 0.2) && animator.GetCurrentAnimatorStateInfo(0).IsName("idle")) 
        {
            animator.SetTrigger("Run");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Diamond")
        {
            direction = new Vector3(0, 0, 0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public FloatingJoystick floatingJoystick;
    public DynamicJoystick dynamicJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 directionVar = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(directionVar * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        Vector3 directionFlo = Vector3.forward * floatingJoystick.Vertical + Vector3.right * floatingJoystick.Horizontal;
        rb.AddForce(directionFlo * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        Vector3 directionDyn = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        rb.AddForce(directionDyn * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}
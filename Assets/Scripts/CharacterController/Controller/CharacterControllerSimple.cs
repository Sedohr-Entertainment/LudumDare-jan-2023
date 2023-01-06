using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControllerSimple : CharacterControlerBase
{
    [SerializeField] private float speed = 5f;

    [Header("Jump Settings")]
    private float ySpeed = 0;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float gravity = 1f;
    [SerializeField] private float maxFallSpeed = 5f;

    [Header("Rotation Settings")]
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float turnSmoothDamp;
    private float angle, targetAngle;

    protected override void Update()
    {
        ApplyGravity();
    }

    protected override void ApplyGravity()
    {
        if (IsGrounded)
        {
            ySpeed = 0;
            return;
        }

        if (Physics.Raycast(transform.position, -upVector, out RaycastHit hit, gravity * Time.deltaTime))
        {
            Controller.Move(hit.point - transform.position);
            ySpeed = 0;
            return;
        }

        if (ySpeed > -maxFallSpeed)
        {
            ySpeed -= gravity * Time.deltaTime;
        }
        else
        {
            ySpeed = -maxFallSpeed;
        }

        Controller.Move(transform.up * ySpeed * Time.deltaTime);
    }


    protected override void ApplyRotation()
    {
        targetAngle = Mathf.Atan2(Controller.velocity.normalized.x, Controller.velocity.normalized.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothDamp, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
    }

    public override void ApplyMovement(Vector3 direction)
    {
        ApplyRotation();
        Controller.Move(direction * speed * Time.deltaTime);
    }

    public override void Jump()
    {
        ySpeed = jumpForce;
        Controller.Move(transform.up * ySpeed * Time.deltaTime);
    }
}

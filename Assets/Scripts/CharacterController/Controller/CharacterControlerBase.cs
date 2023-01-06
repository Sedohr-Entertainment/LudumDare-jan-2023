using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public abstract class CharacterControlerBase : MonoBehaviour
{
    private CharacterController controller;
    public CharacterController Controller => controller ??= GetComponent<CharacterController>() ?? gameObject.AddComponent<CharacterController>();

    [Header("Ground Check Settings")]
    [SerializeField] protected float groundCheckDistance = 0.1f;
    [SerializeField] protected LayerMask groundLayer;

    protected abstract void Update();
    protected abstract void ApplyGravity();
    protected abstract void ApplyRotation();
    public abstract void ApplyMovement(Vector3 direction);
    public abstract void Jump();

    private Ray ray;
    private RaycastHit hit;
    protected Vector3 upVector = Vector3.up;

    [SerializeField] protected Transform cam;

    protected bool IsGrounded
    {
        get
        {
            // Cast a ray down from the center of the character controller
            ray = new Ray(transform.position, -upVector);

            // If the ray hits the ground within the ground check distance, the character is grounded
            if (Physics.Raycast(ray, out hit, Controller.height / 2 + groundCheckDistance))
            {
                return true;
            }

            return false;
        }
    }
}

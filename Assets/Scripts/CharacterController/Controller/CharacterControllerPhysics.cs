using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterControlerPhysics : CharacterControlerBase
{
    public float gravity = -9.81f;
    public float drag = 0.1f;
    public float mass = 1f;
    public float jumpForce = 10f;

    private Vector3 velocity;
    private bool isGrounded;

    protected override void Update()
    {
        // Check if the character is grounded
        isGrounded = IsGrounded;

        // Apply gravity
        ApplyGravity();

        // Apply drag
        velocity -= velocity * drag * Time.deltaTime;

        // Move the character controller
        Controller.Move(velocity * Time.deltaTime);
    }

    public override void ApplyMovement(Vector3 moveDirection)
    {
        // Add the input to the velocity
        velocity += moveDirection;
    }

    public override void Jump()
    {
        // Only jump if the character is grounded
        if (isGrounded)
        {
            velocity.y = jumpForce;
        }
    }

    protected override void ApplyGravity()
    {
        if (!isGrounded)
        {
            // Calculate the force of gravity based on the object's mass
            float gravityForce = mass * gravity;

            // If the player is falling, apply double gravity
            if (velocity.y < 0)
            {
                gravityForce *= 2;
            }

            velocity.y += gravityForce * Time.deltaTime;
        }
    }

    protected override void ApplyRotation()
    {
        // Rotate the character to face the direction of movement
        transform.rotation = Quaternion.LookRotation(velocity.normalized);
    }
}

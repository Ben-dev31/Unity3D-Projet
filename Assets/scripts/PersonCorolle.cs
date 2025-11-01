using UnityEngine;
using UnityEngine.InputSystem;

public class PersonCorolle : MonoBehaviour
{
    public float runSpeed = 5f;
    public float walkSpeed = 2f;
    public float rotationSpeed = 100f;
    public float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update() 
    {
        
        if (Keyboard.current.upArrowKey.isPressed && Keyboard.current.leftShiftKey.isPressed)
        {
            run(1);
        }
        if (Keyboard.current.upArrowKey.isPressed)
        {
            walk(1);
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            walk(-1);
        }
        
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rotate(-1);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rotate(1);
        }
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            jump();
        }

    }

    void walk(int direction)
    {
        // Implementation for walking in the specified direction
        transform.Translate(Vector3.forward * direction * walkSpeed * Time.deltaTime);

    }
    void run(int direction)
    {
        // Implementation for running in the specified direction
        transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
    }

    void rotate(int direction)
    {
        // Implementation for rotating in the specified direction
        transform.Rotate(Vector3.up * direction * rotationSpeed * Time.deltaTime);
    }

    void jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


}
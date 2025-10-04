using UnityEngine;
using UnityEngine.InputSystem;
public class personagemov : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float WalkSpeed;
    public float RunSpeed;
    public float RotateSpeed;
    private Vector3 position;
    private Quaternion rotation;


    void Start()
    {
        WalkSpeed = 5.9f;
        RotateSpeed = 5.9f;
        position = new Vector3(0, 0, 0);
        position = transform.position;
        rotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y,transform.rotation.z); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.upArrowKey.isPressed)
        {
            position.z += WalkSpeed * Time.deltaTime;
            transform.position = position;
        }
        if (Keyboard.current.downArrowKey.isPressed)
        {
            position.z -= WalkSpeed * Time.deltaTime;
            transform.position = position;
        }
        if (Keyboard.current.leftArrowKey.isPressed)
        {
            rotation.y += RotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
        }
        if (Keyboard.current.rightArrowKey.isPressed)
        {
            rotation.y -= RotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime) ;
        }
    }
}

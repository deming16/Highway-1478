using UnityEngine;

public class MenuPlayerMovement : MonoBehaviour
{
    
    public float forwardSpeed;

    void FixedUpdate()
    {
        transform.position += Vector3.forward * Time.deltaTime * forwardSpeed;
    }
    
}

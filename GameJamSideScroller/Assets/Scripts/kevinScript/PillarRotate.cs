using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = -30.0f; // Adjust this value to control the rotation speed.

    void Update()
    {
        // Check if the player is moving to the right (positive horizontal input).
        if (Input.GetAxis("Horizontal") > 0)
        {
            // Rotate the object around its Y-axis using Time.deltaTime to make it frame rate independent.
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            // Rotate the object around its Y-axis using Time.deltaTime to make it frame rate independent.
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
    }
}

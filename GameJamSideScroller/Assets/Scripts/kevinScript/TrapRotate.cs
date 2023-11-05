using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public float rotationSpeed = 60.0f; // Adjust the speed of rotation as needed.

    private void Update()
    {
        // Rotate the trap continuously around the Z-axis based on the rotation speed.
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}

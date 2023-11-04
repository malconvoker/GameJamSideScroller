using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionOnRightEnd : MonoBehaviour
{
    public float offsetX = 1.0f; // Adjust this value to control the offset from the right end.

    void Start()
    {
        // Find the camera's right boundary in world space.
        float cameraRightBoundary = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

        // Set the column's position to the right boundary with an offset.
        Vector3 newPosition = new Vector3(cameraRightBoundary + offsetX, transform.position.y, transform.position.z);
        transform.position = newPosition;
    }
}


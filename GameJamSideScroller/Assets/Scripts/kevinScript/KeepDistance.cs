using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform.
    public float xOffset = 11.1f;  // The desired constant distance in the X-axis.

    void Update()
    {
        // Ensure the object maintains a constant distance from the player in the X-axis.
        Vector3 newPosition = transform.position;
        newPosition.x = player.position.x + xOffset;
        transform.position = newPosition;
    }
}

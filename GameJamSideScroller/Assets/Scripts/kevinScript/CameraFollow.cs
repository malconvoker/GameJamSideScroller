using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    public float yOffset = 3f;
    public float xOffset = 1f;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(playerTransform.position.x + xOffset, transform.position.y, transform.position.z);
    }
}

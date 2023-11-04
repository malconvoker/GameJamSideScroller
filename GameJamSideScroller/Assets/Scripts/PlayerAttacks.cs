using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private GameObject meleeAttack;
    [SerializeField] private GameObject rangedAttack;
    public Transform attackLocation;
    public Vector2 facingDirection = Vector2.right;
    public float fireballSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(meleeAttack, attackLocation.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            // Make a fireball, make it fly in the facing direction
            Instantiate(rangedAttack, attackLocation.position, transform.rotation)
                .gameObject.GetComponent<Rigidbody2D>().velocity = facingDirection.normalized * fireballSpeed;
        }
    }
}

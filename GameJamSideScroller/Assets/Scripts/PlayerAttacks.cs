using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    [SerializeField] private GameObject meleeAttack;
    [SerializeField] private GameObject rangedAttack;
    [SerializeField] private PlayerMovement playerMove;
    [SerializeField] Transform attackLocationRight;
    [SerializeField] Transform attackLocationLeft;
    private Transform attackLocation;
    public Vector2 facingDirection = Vector2.right;
    public float fireballSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerMove.facingRight)
        {
            attackLocation = attackLocationRight;
            facingDirection = Vector2.right;
        } 
        else
        {
            attackLocation = attackLocationLeft;
            facingDirection = Vector2.left;
        }

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

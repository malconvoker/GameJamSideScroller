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
    public float castCost = 5f;
    public float cooldown = 0.5f;
    private float cooldownTimer;
    public HealthManager health;

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
            if (cooldownTimer <= 0 )
            {
                Instantiate(rangedAttack, attackLocation.position, transform.rotation)
                .gameObject.GetComponent<Rigidbody2D>().velocity = facingDirection.normalized * fireballSpeed;
                cooldownTimer = cooldown;
                health.TakeDamage(castCost);
            }
            // Make a fireball, make it fly in the facing direction
            
        }
        cooldownTimer -= Time.deltaTime;
    }
}

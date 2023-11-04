using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hazard
{
    /// <summary>
    /// Something that deals damage to the player on contact
    /// </summary>
    public class ContactDamage : MonoBehaviour
    {
        public float damage = 10f;
        public float knockback = 1f;
        public float cooldown = 1f;
        private float cdTimer = 0f;
        private Vector2 knockbackDirection;
        
        /*[SerializeField] private PlayerHealth health;
        [SerializeField] private PlayerMovement move;*/

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // if colliding thing is player
            if (collision.gameObject.name == "Player")
            {
                if (cdTimer > 0f)
                {
                    Debug.Log("Contact damage for " + gameObject.name + " on cooldown");
                }
                else
                {
                    Debug.Log("Hit player");
                    collision.gameObject.GetComponent<HealthManager>().TakeDamage(damage);

                    if (collision.gameObject.transform.position.x < transform.position.x)
                    {
                        knockbackDirection = new Vector2(-2, 1).normalized;
                    }
                    else
                    {
                        knockbackDirection = new Vector2(2, 1).normalized;
                    }

                    collision.gameObject.GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockback, ForceMode2D.Impulse);

                    cdTimer = cooldown;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (cdTimer > 0f)
            {
                cdTimer -= Time.deltaTime;
            }
        }
    }

}
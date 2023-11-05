using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Hazard
{
    [RequireComponent(typeof(ContactDamage))]
    [RequireComponent(typeof(Enemy))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class WalkBackAndForth : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [Tooltip("Time to wait at turn point")]
        [SerializeField] private float waitTime = 1f;
        private float waitTimer = 0f;
        [SerializeField] private bool movingRight = false;
        [SerializeField] private bool movingVertical = false;

        private Rigidbody2D rb;

        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            //if not turning around
            if (waitTimer <= 0f)
            {
                rb.velocity = movingVertical ?
                    movingRight ? (Vector2.up * moveSpeed) : (Vector2.down * moveSpeed)
                    :
                    movingRight ? (Vector2.right * moveSpeed) : (Vector2.left * moveSpeed);
            }
            else
            {
                waitTimer -= Time.deltaTime;
            }
        }

        public void TurnAround(float waitMult)
        {
            // flip direction and wait
            movingRight = !movingRight;
            rb.velocity = Vector2.zero;
            waitTimer = waitTime * waitMult;
        }
    }

}
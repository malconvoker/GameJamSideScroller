using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Hazard
{
    public class WalkBackAndForth : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [Tooltip("Time to wait at turn point")]
        [SerializeField] private float waitTime = 1f;
        private float waitTimer = 0f;
        [SerializeField] private bool movingRight = false;

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
                if (movingRight)
                {
                    rb.velocity = Vector2.right * moveSpeed;
                    //rb.MovePosition(rb.position += new Vector2(moveSpeed * Time.fixedDeltaTime, 0));
                    //transform.position += new Vector3(moveSpeed * Time.deltaTime, 0);
                }
                else
                {
                    rb.velocity = Vector2.left * moveSpeed;
                    //rb.MovePosition(rb.position += new Vector2(-moveSpeed * Time.fixedDeltaTime, 0));
                    //transform.position -= new Vector3(moveSpeed * Time.deltaTime, 0);
                }
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
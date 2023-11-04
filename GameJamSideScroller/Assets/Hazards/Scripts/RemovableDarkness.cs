using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hazard
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(ContactDamage))]
    public class RemovableDarkness : MonoBehaviour
    {
        private BoxCollider2D coll;
        // Start is called before the first frame update
        void Start()
        {
            coll = GetComponent<BoxCollider2D>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.GetComponent<PlayerLight>() != null)
            {
                Fade();
            }
        }

        private void Fade()
        {
            Destroy(gameObject, 0f);
        }
    }

}
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
        public int damage = 1;
        public float knockback = 1f;

        // Start is called before the first frame update
        void Start()
        {

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            // TODO: trigger methods to damage and knockback(?) player
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
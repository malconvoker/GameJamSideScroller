using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Hazard
{
    /// <summary>
    /// Base class for enemies, hazards that can move and be killed
    /// </summary>
    public class Enemy : MonoBehaviour
    {
        public int hp = 1;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void TakeDamage(int damage)
        {
            hp -= damage;
            if (hp <= 0) { Die(); }
        }

        // Method to handle death animation and stuff
        private void Die()
        {
            Destroy(gameObject, 0f);
        }
    }

}
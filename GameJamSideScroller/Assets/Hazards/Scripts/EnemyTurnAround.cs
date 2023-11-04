using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hazard
{
    public class EnemyTurnAround : MonoBehaviour
    {
        private WalkBackAndForth walker;
        [SerializeField] private float waitMultiplier = 1f;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.name);
            // check if colliding object is back-and-forth enemy
            if (other.gameObject.GetComponent<WalkBackAndForth>() != null)
            {
                walker = other.gameObject.GetComponent<WalkBackAndForth>();
                walker.TurnAround(waitMultiplier);
            }
        }
    }

}
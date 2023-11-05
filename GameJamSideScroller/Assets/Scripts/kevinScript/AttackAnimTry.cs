using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimTry : MonoBehaviour
{
    [SerializeField] private Animator anim; // Reference to the Animator component.

    void Start()
    {
        // Get the Animator component attached to the player object.
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the "J" key is pressed.
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("Attack");
        }

        anim.SetBool("Is Attacking", false);
    }
}
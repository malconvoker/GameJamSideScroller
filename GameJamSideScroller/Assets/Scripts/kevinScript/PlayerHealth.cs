using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maximum health.
    public Transform spawnPoint; // Player's spawn point.

    private int currentHealth;
    private bool isDead = false; // Flag to track if the player has already died.

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to max health.
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision Detected with: " + collision.gameObject.name);

        if (isDead) return; // Don't take damage if the player is already dead.

        /*if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Player touched a trap.");
            TakeDamage(1); // Reduce health by 1 when the player touches a trap.
        }*/
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Reduce the player's health.
        Debug.Log("Current health is " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true; // Set the flag to prevent further damage.
        Debug.Log("Player died.");

        // Reset the player's position to the spawn point.
        transform.position = spawnPoint.position;


        // You can reset the health here if needed.
        // currentHealth = maxHealth;

        // Restart the game by reloading the current scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

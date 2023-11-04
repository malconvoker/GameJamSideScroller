using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float health = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // some condition like if collides with enemy or traps

        if (health <= 0f)
        {
            // do something like die
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            TakeDamage(10f);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Heal(10f);
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthBar.fillAmount = health / 100f;
    }

    public void Heal(float healAmount)
    {
        health += healAmount;
        healthBar.fillAmount = Mathf.Clamp(healAmount, 0, 100);

        healthBar.fillAmount = healAmount / 100f;
    }
}
    
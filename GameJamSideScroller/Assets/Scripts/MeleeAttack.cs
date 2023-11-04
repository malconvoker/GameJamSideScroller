using Hazard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 0.5f;
    public float timeLeft = 0f;
    private bool dealtDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = lifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>() != null)
        {
            if (!dealtDamage)
            {
                collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
                Debug.Log("Dealt " + damage + " damage to " + collision.gameObject.name);
                dealtDamage = true;
            }
        }
    }
}

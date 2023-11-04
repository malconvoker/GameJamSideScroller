using Hazard;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage = 1;
    public float lifeTime = 0.5f;
    public float timeLeft = 0f;
    private bool dealtDamage = false;
    [SerializeField] private bool ranged = false;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        if (ranged)
        {
            rb = GetComponent<Rigidbody2D>();
            lifeTime = 5f;
        }
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

    public void Fly(Vector2 direction, float velocity)
    {
        rb.velocity = direction.normalized * velocity;
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

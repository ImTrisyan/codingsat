using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 direction;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private float damage;
    [SerializeField] private float health;
    [SerializeField] private int experienceToGive;
    [SerializeField] private float pushTime;
    private float pushCounter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { if (PlayerController.Instance.gameObject.activeSelf) {
        if (PlayerController.Instance.transform.position.x > transform.position.x)
            {
            spriteRenderer.flipX = true;
            }
        else
        {
            spriteRenderer.flipX = false;
        }

        if (pushCounter > 0)
        {
            pushCounter -= Time.deltaTime;
            if (moveSpeed > 0)
            {
                moveSpeed = moveSpeed * -1;
            }

            if (pushCounter <=0)
            {
                moveSpeed = Mathf.Abs(moveSpeed);
            }
        }

        direction = (PlayerController.Instance.transform.position - transform.position);
        rb.linearVelocity = new Vector2 (direction.x * moveSpeed, direction.y * moveSpeed);

    } else {
        rb.linearVelocity = Vector2.zero;


    }


        
    }

      void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController.Instance.TakeDamage(damage);
            
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        pushCounter = pushTime;

        if (health <=0)
        {
            Destroy(gameObject);
            Instantiate(destroyEffect,transform.position, transform.rotation);
            PlayerController.Instance.GetExperience(experienceToGive);
        }
    }

}


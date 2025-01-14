using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    Animator animator;
    Rigidbody2D rigidbody2d;
    public bool vertical;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;
    bool broken = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        timer = changeTime;

        animator = GetComponent<Animator>();
        
    }
   //arigato
    // FixedUpdate has the same call rate as the physics system
    
    void Update()
    {
      timer -= Time.deltaTime;

      if (timer < 0)
       {
           direction = -direction;
           timer = changeTime;
       }
    }
    
    
    void FixedUpdate()
    {
         if(!broken)
        {
            return;
        }

       Vector2 position = rigidbody2d.position;

        if  (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", 0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0 );
        }

        rigidbody2d.MovePosition(position);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
   {
       broken = false;
       rigidbody2d.simulated = false;
   }

      
}

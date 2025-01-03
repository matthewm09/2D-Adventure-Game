using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputAction moveAction;
    Rigidbody2D rigidbody2d;
    Vector2 move;
    
    //Variables related to health system
    public int maxHealth = 5;
    int currentHealth;
    public float speed = 3.0f;
    public float timeInvincible = 2.0f;
    bool isInvincible;
    float damageCooldown; 
    
    Animator animator;
    Vector2 moveDirection = new Vector2(1,0); 

    public int health
    {
      get 
      {
        return currentHealth;
      }
    }
    // Start is called before the first frame update
    void Start()
    {   
        
        moveAction.Enable();

        //QualitySettings.vSyncCount =0;
       // Application.targetFrameRate = 120;
       rigidbody2d = GetComponent<Rigidbody2D>();

       
       currentHealth = 2;
       animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Display the current a variable called position and add the move value from InputAction
         move = moveAction.ReadValue<Vector2>();

        Debug.Log(move);
        
        if (isInvincible)
        {
          damageCooldown-= Time.deltaTime;
          if (damageCooldown < 0)
          {
            isInvincible = false;
          }
        }
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y,0.0f))
        {
          moveDirection.Set(move.x, move.y);
          moveDirection.Normalize();
        }

        animator.SetFloat("Look X", moveDirection.x);
        animator.SetFloat("Look Y", moveDirection.y);
        animator.SetFloat("Speed", move.magnitude);
    }
    
    void FixedUpdate()
    {
         Vector2 position = (Vector2)transform.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

    }

    public void ChangeHealth (int amount)
    {
      if (amount < 0)
      {
        if (isInvincible)
        {
          return;
        
        }
        isInvincible = true;
        damageCooldown = timeInvincible;

      }

        currentHealth = Mathf.Clamp(currentHealth + amount,0, maxHealth);
        UIHealthBar.instance.SetValue(currentHealth / (float)maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }

  
} 
    

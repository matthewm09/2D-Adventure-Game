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

    // Start is called before the first frame update
    void Start()
    {   
        
        moveAction.Enable();

        //QualitySettings.vSyncCount =0;
       // Application.targetFrameRate = 120;
       rigidbody2d = GetComponent<Rigidbody2D>();
       currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Display the current a variable called position and add the move value from InputAction
         move = moveAction.ReadValue<Vector2>();

        Debug.Log(move);

       
        
       

    }
    
    void FixedUpdate()
    {
         Vector2 position = (Vector2)transform.position + move * speed * Time.deltaTime;
        rigidbody2d.MovePosition(position);

    }

    void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount,0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }

  
} 
    

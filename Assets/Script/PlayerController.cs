using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    public InputAction moveAction;
    // Start is called before the first frame update
    void Start()
    {   
        leftAction.Enable();
        moveAction.Enable();

        //QualitySettings.vSyncCount =0;
       // Application.targetFrameRate = 120;
    }

    // Update is called once per frame
    void Update()
    {
        //Display the current a variable called position and add the move value from InputAction
        Vector2 move = moveAction.ReadValue<Vector2>();

        Debug.Log(move);

        Vector2 position = (Vector2)transform.position + move * 5f * Time.deltaTime;
        transform.position = position;
        
       

    }
} 
    

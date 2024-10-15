using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Creating variable for horizontal inputs
        float horizontal = 0.0f;
        if(Keyboard.current.rightArrowKey.isPressed)
        {
            horizontal = .50f;
        }
        else if(Keyboard.current.leftArrowKey.isPressed)
        {
            horizontal = -.50f;
        } 
        Debug.Log(horizontal);
        
        float vertical = 0.0f;
        if(Keyboard.current.downArrowKey.isPressed)
        {
            vertical = -.50f;
        }
        else if(Keyboard.current.upArrowKey.isPressed)
        {
            vertical = .50f;
        }
        Debug.Log(vertical);

        Vector2 position = transform.position;
        position.x = position.x + 0.1f  *  horizontal;
        position.y = position.y + 0.1f * vertical;
        transform.position = position;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
 public AudioClip hurtSound; 
    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController controller = other.GetComponent<PlayerController>();  
        
        if (controller != null && controller.health > 0)
        {
            controller.PlaySound(hurtSound);
            controller.ChangeHealth(-1);          
        }
      
    }
}

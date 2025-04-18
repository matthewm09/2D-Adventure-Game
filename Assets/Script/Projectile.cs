using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Projectile : MonoBehaviour
{

   Rigidbody2D rigidbody2d;
   AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }

    public void Launch(Vector2 direction, float force)
    {     
      rigidbody2d.AddForce(direction * force);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile collision with" + other.gameObject);
         EnemyController enemy = other.GetComponent<EnemyController>();
       if (enemy != null)
        {
            enemy.Fix();
            Destroy(other.gameObject);
        }

        
        Destroy(gameObject);
    }

    public void PlaySound(AudioClip clip)
  {
   audioSource.PlayOneShot(clip);
  }
  
}

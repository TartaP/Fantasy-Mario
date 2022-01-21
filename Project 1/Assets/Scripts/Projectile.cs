using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
     [SerializeField] private float speed;
     [SerializeField] private float bounceSpeed;
     private float direction;
     [SerializeField] private float maxlifetime;
     private float lifetime;
     private Animator anim;
     private BoxCollider2D boxCollider;
     private Rigidbody2D rb;


     private void Awake()
     {
         anim = GetComponent<Animator>();
         boxCollider = GetComponent<BoxCollider2D>();
         rb = GetComponent<Rigidbody2D> (); 
         
     }

     private void Update()
     {
         //if(hit) return;
         float movementSpeed = speed * direction;

         rb.velocity = new Vector2(movementSpeed, rb.velocity.y);

         lifetime += Time.deltaTime;
         if(lifetime > maxlifetime) gameObject.SetActive(false);
     }
     private void OnCollisionEnter2D(Collision2D collision)
     {
          
         for (int i = 0; i < collision.contactCount; i++)
         {
             if (Vector2.Dot(Vector2.up, collision.GetContact(i).normal) > 0.5f)
             {
                 rb.velocity = new Vector2(rb.velocity.x, bounceSpeed);
             }

             if (Vector2.Dot(Vector2.left, collision.GetContact(i).normal) > 0.5f)
             {
                 if (direction > 0)
                    direction = -direction;
             }

             if (Vector2.Dot(Vector2.right, collision.GetContact(i).normal) > 0.5f)
             {
                if (direction < 0)
                    direction = -direction;
             }
              Debug.Log("test");

         }


         //boxCollider.enabled = false;
         //anim.SetTrigger("Explode");
     }
     public void SetDerection(float _direction)
     {
         lifetime = 0;
         direction = _direction;
         gameObject.SetActive(true);
         boxCollider.enabled = true;

         //float localScaleX = transform.localScale.x;
         //if (Mathf.Sign(localScaleX) != _direction)
            //localScaleX = -localScaleX;

         //transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);


     }

     private void Deactivate()
     {
         gameObject.SetActive(false);
     }
}

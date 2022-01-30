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
     public LayerMask enemyLayer;



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
         

        fireBall();

         
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


         }

         //boxCollider.enabled = false;
         //anim.SetTrigger("Explode");
     }
     public void fireBall()
     {
         RaycastHit2D rayLeft = Physics2D.Raycast(transform.position, -transform.right, .3f, enemyLayer);
         RaycastHit2D rayRight = Physics2D.Raycast(transform.position, transform.right, .3f, enemyLayer);
         if (rayLeft.collider != null) 
         {
             Destroy(rayLeft.collider.gameObject);
            Debug.Log("leftcontact");
             this.gameObject.SetActive(false); 

             ScoreManager.instance.goblinscore();
         }
         else if (rayRight.collider != null) 
         {
            Destroy(rayRight.collider.gameObject);           
            Debug.Log("rightcontact");
            this.gameObject.SetActive(false);
            ScoreManager.instance.goblinscore();
         }
         
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

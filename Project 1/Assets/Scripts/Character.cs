using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float runPower;
    [SerializeField] private float bouncePower;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private bool grounded;

    private bool canFire;

    public void TakeDamage()
    {
        anim.SetBool("big", false);
        canFire = false;
        anim.SetBool("firebig", false);
    }





    public List<string> inventory;

    private void Awake()
    {
        inventory = new List<string>();
        enabled = true; 
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    private void Update()
    {
    
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Z))
        {
            body.velocity = new Vector2(horizontalInput * runPower, body.velocity.y);
        }
        else 
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

        


        if (horizontalInput > 0)
                spriteRenderer.flipX = false;
            else if (horizontalInput < 0)
                spriteRenderer.flipX = true;

            if (Input.GetKey(KeyCode.X) && grounded)
                Jump(jumpPower);

            anim.SetBool("run", horizontalInput != 0);
            anim.SetBool("grounded", grounded);

        

       
    }

    private void Jump(float power)
    {
        body.velocity = new Vector2(body.velocity.x, power);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    
    }
    
    public bool canAttack()
    {
        return canFire;

    }


    private void OnCollisionEnter2D(Collision2D collision)
     {
          
         for (int i = 0; i < collision.contactCount; i++)
         {
             if (Vector2.Dot(Vector2.up, collision.GetContact(i).normal) > 0.5f)
             { 
                 if (collision.collider.tag == "enemy")
                 {
                     Jump(bouncePower);
                     Destroy(collision.gameObject);
                 }
                grounded = true;
             }

         }
         
     }

     private void OnTriggerEnter2D(Collider2D collision)
     {
         
         if (collision.CompareTag("Item"))
         {
             collision.gameObject.GetComponent<Collectible>().pickUP(this);
             string itemType = collision.gameObject.GetComponent<Collectible>().itemType;
             print("we hyave collected a:" + itemType);

             inventory.Add(itemType);
             print("Inventory length:" + inventory.Count);

             Destroy(collision.gameObject);
         }

     }


    

     public float isdirection()
     {
         if (spriteRenderer.flipX)
         {
             return -1;
         }
         return 1;
     }

     public void gainLife()
     {
         GetComponent<Life>().GainLife();
     }

     public void growUP()
     {
         anim.SetBool("big", true);
         GetComponent<Health>().gainHealth();
     }
     public void diamondUP()
     {
         
     }
     public void attackUP()
     {
         canFire = true;
         anim.SetBool("firebig", true);
         

     }

  
}

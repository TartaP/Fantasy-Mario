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

    [SerializeField] private GameObject flagPole;
    private Rigidbody2D body;
    private Animator anim;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;
    private float horizontalInput;
    private bool grounded;

    private bool canFire;

    private bool ctrlActive;
    private bool isDead;
    private Collider2D playercol;
    public float shockForce;

    public Timelimemanager timelinemanager;

    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource growthSound;
    [SerializeField] private AudioSource FireUP;
    [SerializeField] private AudioSource enemydeadSound;
    [SerializeField] private AudioSource shrinkSound;
    [SerializeField] private AudioSource deathSound;

    


    public void TakeDamage()
    {
        anim.SetBool("big", false);
        canFire = false;
        anim.SetBool("firebig", false);
        shrinkSound.Play();
    }





    public List<string> inventory;

    private void Awake()
    {
        timelinemanager.enabled = false;
        inventory = new List<string>();
        enabled = true; 
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playercol = GetComponent<Collider2D>();

        ctrlActive = true;

    }
    
    private void Update()
    {
      if (ctrlActive == false)
      return;

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
                {Jump(jumpPower);
                jumpSound.Play();}

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
                     enemydeadSound.Play();
                     Destroy(collision.gameObject);
                     ScoreManager.instance.goblinscore();
                     return;
                 }
                grounded = true;
             }

         }
         if (collision.collider.CompareTag("Item"))
         {
             collision.collider.gameObject.GetComponent<Collectible>().pickUP(this);
             string itemType = collision.collider.gameObject.GetComponent<Collectible>().itemType;
             print("we hyave collected a:" + itemType);

             inventory.Add(itemType);
             print("Inventory length:" + inventory.Count);

             Destroy(collision.collider.gameObject);

             
         }

         if (collision.collider.CompareTag("flagpole"))
         {
             ctrlActive = false;
             anim.SetTrigger("Grab");
             transform.Translate(0, -1.93f, 0);
             
             timelinemanager.StartTimeline();
             Debug.Log("grabsuccess");

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
         growthSound.Play();
     }

     public void growUP()
     {
         anim.SetBool("big", true);
         GetComponent<Health>().gainHealth();
         growthSound.Play();

         ScoreManager.instance.growth();
     }
     public void diamondUP()
     {
         ScoreManager.instance.AddPoint();
         ScoreManager.instance.diamonds();
         
     }
     public void attackUP()
     {
         canFire = true;
         anim.SetBool("firebig", true);
         FireUP.Play();
         
         ScoreManager.instance.attackup();
     }

     public void PlayerDeath()
     {
         isDead = true;
         anim.SetBool("Dead", isDead);

         deathSound.Play();

         ctrlActive = false;

         playercol.enabled = false;

         body.gravityScale = 2.5f;
         body.AddForce(transform.up * shockForce, ForceMode2D.Impulse);

         StartCoroutine("PlayerRespawn");
        
     }

     public IEnumerator PlayerRespawn()
     {
         yield return new WaitForSeconds(1.5f);
         isDead = false;
         anim.SetBool("Dead", isDead);

         playercol.enabled = true;
         

         body.gravityScale = 1.8f;

         yield return new WaitForSeconds(0.1f);
         ctrlActive = true;

         GetComponent<Life>().LoseLife();

     }
  
}

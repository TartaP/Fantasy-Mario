using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    private Animator anim;
    private Character playerMovement;
    private float cooldownTimer = Mathf.Infinity;
    private float offSet;
    [SerializeField] private AudioSource fireSound;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<Character>();
        offSet = firePoint.transform.localPosition.x;
    }

    private void Update()
    {
        firePoint.localPosition = new Vector3(offSet * playerMovement.isdirection(), firePoint.localPosition.y, firePoint.localPosition.z);

        if  (playerMovement.canAttack() && Input.GetKeyDown(KeyCode.Z) && cooldownTimer > attackCooldown)
            Attack();
            

        cooldownTimer += Time.deltaTime;


    }

    

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;
        fireSound.Play();
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDerection(playerMovement.isdirection());
        Debug.Log(firePoint.localPosition);

        
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if(!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}

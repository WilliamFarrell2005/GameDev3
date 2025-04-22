using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Windows;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] private Animator anim;

    [SerializeField] private float meleeSpeed;

    [SerializeField] private float damage;

    

    
    float timeUntilMelee;

    private float x;
    private float y;


    private Vector2 moveValues;
    private bool moving;


    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        Animate();
        x = UnityEngine.Input.GetAxisRaw("Horizontal");
        y = UnityEngine.Input.GetAxisRaw("Vertical");

        moveValues = new Vector2(x, y);

        if (moveValues.magnitude > 0.1f || moveValues.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if (moving)
        {
            anim.SetFloat("x", x);
            anim.SetFloat("y", y);
        }

        anim.SetBool("Moving", moving);

        






    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            //other.GetComponent<Enemy>().TakeDamage(damage);

       
       }
    }

    private void Animate()
    {
        if (timeUntilMelee <= 0)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {

                anim.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            }
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;

        }
    }

    
}

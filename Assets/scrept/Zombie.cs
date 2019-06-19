using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public int Helth = 3;
    private bool isdead;
    Animator animator;

    Rigidbody2D rigidbody;

    int loop = 0;

    bool inputright = false;
    bool inputleft = false;

    Vector3 moveVelocity = Vector3.zero;

    public bool isclone = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        inputleft = true;
    }

    private void Update()
    {
        if (!isdead)
        {
            Move();
            Dead();
            Automove();
        }
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("충돌 =" + collision.gameObject.tag);

        //if (collision.gameObject.tag == "MainMen" || collision.gameObject.tag == "magic" || collision.gameObject.tag == "effect" )
        //{
        //    Helth--;

           
        //}
    }

    void Dead()
    {
        if (Helth <= 0 && !isdead)
        {
            isdead = true;
            animator.SetTrigger("dead");
            if (isclone)
            {
                Destroy(this.gameObject, 1.3f);
            }
        }


    }

    public void reciveDamege(int Damege)
    {
        if (Helth > 0 && !isdead)
        {
            animator.SetTrigger("coll");
        }
    }

    void Move()
    {

        if (!inputleft && !inputright)
        {
            animator.SetBool("isworking", false);
        }
        else if (inputleft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            moveVelocity = Vector3.left;
            animator.SetBool("isworking", true);

            transform.position += moveVelocity * 2* Time.deltaTime;
        }
        else if (inputright)
        {
            transform.localScale = new Vector3(1, 1, 1);
            moveVelocity = Vector3.right;
            animator.SetBool("isworking", true);

            transform.position += moveVelocity * 2 * Time.deltaTime;
        }
    }

    void Automove()
    {
        if (inputleft)
        {
            loop++;
            if (loop == 100)
            {
                loop = 0;
                inputleft = false;
                inputright = true;
            }
        }
        else if (inputright)
        {
            loop++;
            if (loop == 100)
            {
                loop = 0;
                inputleft = false;
                inputright = false;
            }
        }
        else
        {
            loop++;
            if (loop == 300)
            {
                loop = 0;
                inputleft = true;
                inputright = false;
            }
        }
    }
}

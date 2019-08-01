using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainguy : MonoBehaviour
{
    public int speed = 3;
    public int jumppower = 3;
    public int power = 3;

    public int Helth = 3;
    bool isdead = false;

    Animator animator;
    Rigidbody2D rigidbody;

    private bool Ground;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    GameObject Anermy;
    GameObject Damege;
    GameObject Fireball;
    GameObject Werter;

    GameObject wp;



    List<string> itemList = new List<string>();


    public bool inputright = false;
    public bool inputleft = false;
    public bool inputAtteck2 = false;
    public bool inpuAtteck = false;
    public bool inputMagic = false;


    bool coll = false;

    public GameObject Wp;


    int Anermycount = 0;

    bool isanermycreate = false;

    Vector3 moveVelocity = Vector3.zero;
    Vector3[] position = new Vector3[5];
    int rand;
    // Start is called before the first frame update
    private void Awake()
    {
        //Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        Anermy = Resources.Load<GameObject>("Cheriter/Anermi/zobie");
        Damege = Resources.Load<GameObject>("font/Damege");
        Fireball = Resources.Load<GameObject>("effect/fire_ball");
        Werter = Resources.Load<GameObject>("effect/werter");
        wp = GameObject.FindGameObjectWithTag("wp");

        Move ui = GameObject.FindGameObjectWithTag("Manager").GetComponent<Move>();
        ui.Init();

         rand = Random.Range(0, position.Length);


        isanermycreate = true;
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(10,9);
    }
    private void FixedUpdate()
    {
        move();
        Jump();
        Atteck();
        Magic();
        Dead();
        GroundCheck();
        //CreateAner();
    }

    void move()
    {

        if (!inputleft && !inputright)
        {
            animator.SetBool("isrunning", false);
        }else if (inputleft)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            moveVelocity = Vector3.left;
            animator.SetBool("isrunning", true);

            transform.position += moveVelocity *speed* Time.deltaTime;
        }else if (inputright)
        {
            transform.localScale = new Vector3(1, 1, 1);
            moveVelocity = Vector3.right;
            animator.SetBool("isrunning", true);

            transform.position += moveVelocity *speed* Time.deltaTime;
        }
    }
    void Jump()
    {
        if (inputAtteck2)
        {
            inputAtteck2 = false;
            animator.SetTrigger("atteck2");
        }
          
    }
    void Atteck()
    {
        if (inpuAtteck)
        {
            inpuAtteck = false;
            animator.SetTrigger("atteck");

            //if (transform.localScale.x == -1)
            //{
            //    GameObject werter = Instantiate(Werter, new Vector3(transform.position.x - 4, transform.position.y, 49), Quaternion.identity);
            //    werter.GetComponent<Werter>().init();
            //    werter.GetComponent<Werter>().isclone = true;

            //    Destroy(werter, 0.4f);
            //}
            //else
            //{
            //    GameObject werter = Instantiate(Werter, new Vector3(transform.position.x + 4, transform.position.y, 49), Quaternion.identity);
            //    werter.GetComponent<Werter>().isclone = true;
            //    werter.GetComponent<Werter>().init();
            //    werter.GetComponent<Werter>().input_darection = true;

            //    Destroy(werter, 0.4f);
            //}

        }
    }

    void GroundCheck()
    {
        Ground = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (Ground)
        {
            animator.SetBool("isground", true);
        }
        else
        {
            animator.SetBool("isground", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("충돌 했습니.");

        if(collision.gameObject.tag == "anermy")
        {
            Helth--;
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("트리거 충돌 = "+ collision.gameObject.tag);
        if(collision.gameObject.tag == "anermy")
        {
            if(!(collision.gameObject.GetComponent<Zombie>().Helth <= 0))
            {
                collision.gameObject.GetComponent<Zombie>().Helth = collision.gameObject.GetComponent<Zombie>().Helth - power;
                collision.gameObject.GetComponent<Zombie>().reciveDamege(power);

                GameObject clone = Instantiate(Damege, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.1f, 49), Quaternion.identity);
                clone.GetComponent<damege>().Init(power);
                Destroy(clone, 0.5f);
            }
        }
        //else if(collision.gameObject.tag == "UnderGround")
        //{
        //    collision.GetComponent<Entery>().CreateLoglike();


        //    transform.position = new Vector3(0, -250, 49);
        //}
    }

    void Dead()
    {
        if(Helth == 0 && !isdead)
        {
            isdead = true;
            animator.SetTrigger("dead");
        }
    }

    void Magic()
    {
        if (inputMagic)
        {
            inputMagic = false;

            if(transform.localScale.x == -1)
            {
                GameObject fireball = Instantiate(Fireball, new Vector3(transform.position.x - 1, transform.position.y, 49), Quaternion.identity);
                fireball.GetComponent<Magic_fire>().init();
                fireball.GetComponent<Magic_fire>().isclone = true;

                Destroy(fireball, 2);
            }
            else
            {
                GameObject fireball = Instantiate(Fireball, new Vector3(transform.position.x + 1, transform.position.y, 49), Quaternion.identity);
                fireball.GetComponent<Magic_fire>().init();
                fireball.GetComponent<Magic_fire>().isclone = true;
                fireball.GetComponent<Magic_fire>().input_darection = true;

                Destroy(fireball, 2);
            }

          
        }
    }



    void CreateAner()
    {
        if(isanermycreate)
        {
            Anermycount++;
            GameObject zombie = Instantiate(Anermy, new Vector3(-30, -14, 49), Quaternion.identity);
            zombie.GetComponent<Zombie>().isclone = true;

            if(Anermycount == 10)
            {
                Anermycount = 0;
                isanermycreate = false;
            }

        }
        else
        {
            //Anermycount++;

            if(Anermycount == 1000)
            {
                Anermycount = 0;
                isanermycreate = true;
            }
        }
    }


    void wpchenge()
    {
        wp.GetComponent<wp>().Init("all_set_Animation 1_15");
    }

    public void additem(string itemname)
    {
        itemList.Add(itemname);

        GameObject Text = Instantiate(Damege, new Vector3(transform.position.x, transform.position.y + 1, 49), Quaternion.identity);
        Text.GetComponent<damege>().Init(" Add Itme in Inventory !   "+ itemname);
        Destroy(Text, 1);
    }
}

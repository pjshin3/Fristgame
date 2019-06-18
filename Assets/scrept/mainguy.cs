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

    GameObject wp;



    public bool inputright = false;
    public bool inputleft = false;
    public bool inpuJump = false;
    public bool inpuAtteck = false;
    public bool inputMagic = false;


    public GameObject Wp;


    int Anermycount = 0;

    bool isanermycreate = false;

    Vector3 moveVelocity = Vector3.zero;
    Vector3[] position = new Vector3[5];
    int rand;
    // Start is called before the first frame update
    private void Awake()
    {
        Screen.SetResolution(Screen.width, (Screen.width * 16) / 9, true);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();

        Anermy = GameObject.FindGameObjectWithTag("anermy");
        Damege = GameObject.FindGameObjectWithTag("Damege");
        wp = GameObject.FindGameObjectWithTag("wp");

        Move ui = GameObject.FindGameObjectWithTag("Manager").GetComponent<Move>();
        ui.Init();

         rand = Random.Range(0, position.Length);


        isanermycreate = true;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void FixedUpdate()
    {
        move();
        Jump();
        Atteck();
        Magic();
        Dead();
        GroundCheck();
        CreateAner();
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
        if (inpuJump && (animator.GetBool("isground")))
        {
            inpuJump = false;
            animator.SetTrigger("jump");
            rigidbody.AddForce(Vector3.up * jumppower, ForceMode2D.Impulse);
        }
    }
    void Atteck()
    {
        if (inpuAtteck)
        {
            inpuAtteck = false;
            animator.SetTrigger("atteck");
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

        Debug.Log("메인 충돌 =");

        if(collision.gameObject.tag != "ground")
        {
            Helth--;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 충돌 = "+ collision.gameObject.tag);
        if(collision.gameObject.tag == "anermy")
        {
            collision.gameObject.GetComponent<Zombie>().Helth = collision.gameObject.GetComponent<Zombie>().Helth - power;
            collision.gameObject.GetComponent<Zombie>().reciveDamege(power);
            GameObject clone = Instantiate(Damege, new Vector3(collision.transform.position.x, collision.transform.position.y + 1.1f, 49), Quaternion.identity);
            clone.GetComponent<damege>().Init(power);
            Destroy(clone,0.5f);

        }
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
            animator.SetTrigger("Magic");

            wpchenge();
        }
    }



    void CreateAner()
    {
        if(isanermycreate)
        {
            Anermycount++;
            GameObject zombie = Instantiate(Anermy, new Vector3(-7, 9, 49), Quaternion.identity);
            zombie.GetComponent<Zombie>().isclone = true;

            if(Anermycount == 10)
            {
                Anermycount = 0;
                isanermycreate = false;
            }

        }
        else
        {
            Anermycount++;

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
}
